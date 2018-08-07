using System;
using System.Collections.Generic;
using System.Fabric;
using System.Fabric.Query;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Grpc.Core.Logging;
using Newtonsoft.Json.Linq;

namespace ControlPlane
{
    internal static class ServiceFabricToEndpointInstancesTransformations
    {
        public static async Task<(List<EndpointInstance> endpointInstances, Dictionary<string, string> nodes)> GetEndpointInstances(this FabricClient client, ILogger logger)
        {
            var queryManager = client.QueryManager;

            ApplicationList applications = null;
            try
            {
                applications = await queryManager.GetApplicationListAsync();
            }
            catch (Exception e)
            {
                logger.Debug("GetApplicationListAsync failed");
                logger.Debug((FormattableString)$"Error={e.Message}");
                logger.Debug((FormattableString)$"Error={e.StackTrace}");
                Environment.FailFast("GetApplicationListAsync failed");
            }

            var endpointInstances = new List<EndpointInstance>();

            foreach (var application in applications)
            {
                var services = await queryManager.GetServiceListAsync(application.ApplicationName);
                foreach (var service in services)
                {
                    var partitions = await queryManager.GetPartitionListAsync(service.ServiceName);
                    foreach (var partition in partitions)
                    {
                        var replicas = await queryManager.GetReplicaListAsync(partition.PartitionInformation.Id);
                        endpointInstances.AddRange(ExtractEndpoints(replicas, partition, service.ServiceName));
                    }
                }
            }

            var nodes = await queryManager.GetNodeListAsync();
            var nodeAdresses = nodes.ToDictionary<Node, string, string>(n => n.NodeName, n => GetIpAddress(n.IpAddressOrFQDN));

            return (endpointInstances, nodeAdresses);
        }

        private static string GetIpAddress(string ipAddressOrFQDN)
        {
            if (IPAddress.TryParse(ipAddressOrFQDN, out _))
            {
                return ipAddressOrFQDN;
            }

            var ipaddrs = Dns.GetHostAddresses(ipAddressOrFQDN);
            foreach (var ipaddr in ipaddrs)
            {
                if (ipaddr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    var saddrstring = ipaddr.ToString();
                    if (saddrstring.StartsWith("172"))
                    {
                        return saddrstring;
                    }
                }
            }

            return null;
        }

        private static List<EndpointInstance> ExtractEndpoints(ServiceReplicaList replicas, Partition partition,
            Uri service)
        {
            List<EndpointInstance> endpointInstances = new List<EndpointInstance>();
            foreach (var replica in replicas)
            {
                if (replica.ReplicaAddress.Length == 0)
                {
                    continue;
                }

                JObject addresses;
                try
                {
                    addresses = JObject.Parse(replica.ReplicaAddress);
                }
                catch
                {
                    continue;
                }

                var endpoints = addresses["Endpoints"].Value<JObject>();
                foreach (var endpoint in endpoints)
                {
                    var endpointName = endpoint.Key;
                    var endpointAddress = endpoint.Value.ToString();

                    if (!endpointAddress.StartsWith("http", StringComparison.InvariantCultureIgnoreCase))
                    {
                        continue;
                    }

                    EndpointType endpointType = null;

                    if (partition.ServiceKind == ServiceKind.Stateful)
                    {
                        var statefulRole = ((StatefulServiceReplica)replica).ReplicaRole;
                        ServiceEndpointRole role;
                        switch (statefulRole)
                        {
                            case ReplicaRole.Primary:
                                role = ServiceEndpointRole.StatefulPrimary;
                                break;
                            case ReplicaRole.ActiveSecondary:
                                role = ServiceEndpointRole.StatefulSecondary;
                                break;
                            default:
                                role = ServiceEndpointRole.Invalid;
                                break;
                        }

                        switch (partition.PartitionInformation.Kind)
                        {
                            case ServicePartitionKind.Singleton:
                                endpointType = EndpointType.CreateSingleton(service.AbsolutePath,
                                    partition.PartitionInformation.Id, endpointName, endpoints.Count == 1, role);
                                break;
                            case ServicePartitionKind.Int64Range:
                                var rangePartitionInformation =
                                    (Int64RangePartitionInformation)partition.PartitionInformation;
                                endpointType = EndpointType.CreateInt64Partitioned(service.AbsolutePath,
                                    partition.PartitionInformation.Id, endpointName, endpoints.Count == 1, role,
                                    rangePartitionInformation.LowKey, rangePartitionInformation.HighKey);
                                break;
                            case ServicePartitionKind.Named:
                                var namedPartitionInformation =
                                    (NamedPartitionInformation)partition.PartitionInformation;
                                endpointType = EndpointType.CreateNamedPartitioned(service.AbsolutePath,
                                    partition.PartitionInformation.Id, endpointName, endpoints.Count == 1, role,
                                    namedPartitionInformation.Name);
                                break;
                            case ServicePartitionKind.Invalid:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                    else
                    {
                        endpointType = EndpointType.CreateStateless(service.AbsolutePath,
                            partition.PartitionInformation.Id, endpointName, endpoints.Count == 1);
                    }

                    if (endpointType != null)
                    {
                        var endpointInstanceObject =
                            new EndpointInstance(endpointType, new Uri(endpointAddress), replica.NodeName);
                        endpointInstances.Add(endpointInstanceObject);
                    }
                }
            }

            return endpointInstances;
        }
    }
}