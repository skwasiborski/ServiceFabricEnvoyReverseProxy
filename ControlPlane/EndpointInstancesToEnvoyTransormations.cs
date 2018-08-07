
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Fabric;
using System.Linq;
using Envoy.Api.V2;
using Envoy.Api.V2.Core;
using Envoy.Api.V2.Endpoint;
using Envoy.Api.V2.ListenerNS;
using Envoy.Api.V2.Route;
using Envoy.ControlPlane.Server.Cache;
using Envoy.Type;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;

namespace ControlPlane
{
    public static class EndpointInstancesToEnvoyTransormations
    {
        public const int IngressPort = 29082;
        public const int EgressPort = 29083;

        public static Dictionary<string, Snapshot> CreateEnvoySnapshots(
           Dictionary<string, string> nodeAdresses,
           IEnumerable<EndpointInstance> endpointInstances)
        {
            var egressEndpoints = new Dictionary<EndpointType, List<EndpointInstance>>();
            var ingrssEndpoints = new Dictionary<string, List<EndpointInstance>>();

            foreach (var endpointInstance in endpointInstances)
            {
                egressEndpoints.GetOrAdd(endpointInstance.Type, _ => new List<EndpointInstance>())
                    .Add(endpointInstance);
                ingrssEndpoints.GetOrAdd(endpointInstance.NodeName, _ => new List<EndpointInstance>())
                    .Add(endpointInstance);
            }

            var envoyEgressClusters = egressEndpoints.Select(e => e.Key.ToEnvoyEgressCluster()).ToImmutableDictionary(c => c.Name, c => (IMessage)c);

            var envoyEgressClusterLoadAssignments = egressEndpoints
                .Select(egressEndpoint => egressEndpoint.Value.ToEnvoyEgressClusterLoadAssignment(nodeAdresses))
                .ToImmutableDictionary(e => e.ClusterName, e => (IMessage)e);

            var envoyIngressClusters = ingrssEndpoints
                .ToDictionary(kv => kv.Key, kv => kv.Value.Select(e => e.ToEnvoyIngressCluster()).ToDictionary(c => c.Name, c => (IMessage)c));

            var envoyEgressRoute = egressEndpoints.Select(e => e.Key.ToEnvoyRoute(e.Key.EgressId)).ToRouteConfiguration("egress");

            var envoyIngressRoutes = ingrssEndpoints
                .ToDictionary(
                    kv => kv.Key,
                    kv => kv.Value.Select(e => e.Type.ToEnvoyRoute(e.Type.IngressId)).ToRouteConfiguration("ingress"));

            var endpoints = new Resources(Guid.NewGuid().ToString(), envoyEgressClusterLoadAssignments);

            var ingressListiner = CreateListener(IngressPort, "ingress");
            var egressListiner = CreateListener(EgressPort, "egress");
            var listiners = new Resources(Guid.NewGuid().ToString(), new Dictionary<string, IMessage> { { ingressListiner.Name, ingressListiner }, { egressListiner.Name, egressListiner } });

            return nodeAdresses.ToDictionary(n => n.Key, n =>
            {
                var clusters = envoyEgressClusters;
                if (envoyIngressClusters.TryGetValue(n.Key, out var envoyIngressCluster))
                {
                    clusters = clusters.AddRange(envoyIngressCluster);
                }

                var routes = new Dictionary<string, IMessage>
                {
                    {envoyEgressRoute.Name, envoyEgressRoute},
                };

                if (envoyIngressRoutes.TryGetValue(n.Key, out var envoyIngressRoute))
                {
                    routes.Add(envoyIngressRoute.Name, envoyIngressRoute);
                }

                return new Snapshot(endpoints, new Resources(Guid.NewGuid().ToString(), clusters), new Resources(Guid.NewGuid().ToString(), routes), listiners);
            });
        }

        private static Listener CreateListener(uint port, string name)
        {
            var filter = new Filter()
            {
                Name = "envoy.http_connection_manager",
                Config = Google.Protobuf.JsonParser.Default.Parse<Google.Protobuf.WellKnownTypes.Struct>(
                    $"{{ \"stat_prefix\":\"{name}\",\"codec_type\" : \"AUTO\", \"rds\": {{ \"route_config_name\":\"{name}\", \"config_source\": {{\"ads\": {{}}}}}}, \"http_filters\" : [ {{ \"name\" : \"envoy.router\" }} ] }}")
            };

            var listener = new Listener()
            {
                Name = name,
                Address = new Address() { SocketAddress = new SocketAddress() { Address = "0.0.0.0", PortValue = port } },
                FilterChains = { new FilterChain() }
            };

            listener.FilterChains[0].Filters.Add(filter);
            return listener;
        }

        public static Cluster ToEnvoyIngressCluster(this EndpointInstance e)
        {
            var cluster = new Cluster()
            {
                Name = e.Type.IngressId,
                LbPolicy = Cluster.Types.LbPolicy.RoundRobin,
                Type = Cluster.Types.DiscoveryType.Static,
                ConnectTimeout = Duration.FromTimeSpan(TimeSpan.FromMilliseconds(250)),
            };

            cluster.Hosts.Add(new Address()
            {
                SocketAddress = new SocketAddress
                {
                    Address = e.NetworkAddress.Host,
                    PortValue = (uint)e.NetworkAddress.Port
                }
            });

            return cluster;
        }

        public static Cluster ToEnvoyEgressCluster(this EndpointType endpointType)
        {
            return new Cluster()
            {
                Name = endpointType.EgressId,
                LbPolicy = Cluster.Types.LbPolicy.RoundRobin,
                Type = Cluster.Types.DiscoveryType.Eds,
                ConnectTimeout = Duration.FromTimeSpan(TimeSpan.FromMilliseconds(250)),
                EdsClusterConfig =
                    new Cluster.Types.EdsClusterConfig()
                    {
                        EdsConfig = new ConfigSource() { Ads = new AggregatedConfigSource() { } }
                    }
            };
        }

        public static ClusterLoadAssignment ToEnvoyEgressClusterLoadAssignment(this List<EndpointInstance> endpoints, Dictionary<string, string> nodeAdresses)
        {
            var assignment = new ClusterLoadAssignment()
            {
                ClusterName = endpoints.First().Type.EgressId,
            };

            var envoyEndpoint = new LocalityLbEndpoints();

            envoyEndpoint.LbEndpoints.AddRange(endpoints.Select(e =>
                new LbEndpoint
                {
                    Endpoint = new Endpoint
                    {
                        Address = new Address
                        {
                            SocketAddress =
                                new SocketAddress { Address = nodeAdresses[e.NodeName], PortValue = IngressPort }
                        }
                    }
                }));

            assignment.Endpoints.Add(envoyEndpoint);
            return assignment;
        }

        public static Route ToEnvoyRoute(this EndpointType e, string clusterName)
        {
            var match = new RouteMatch()
            {
                Prefix = e.ServiceAbsolutePath +
                         (e.ServiceAbsolutePath.EndsWith("/") ? string.Empty : "/"),
            };

            if (!e.DefaultEndpoint)
            {
                match.Headers.Add(new HeaderMatcher() { Name = "EndpointName", ExactMatch = e.EndpointName });
            }

            if (e.Role == ServiceEndpointRole.StatefulSecondary)
            {
                match.Headers.Add(new HeaderMatcher() { Name = "Replica", ExactMatch = "Secondary" });
            }

            switch (e.PartitionKind)
            {
                case ServicePartitionKind.Int64Range:
                    match.Headers.Add(new HeaderMatcher()
                    {
                        Name = "PartitionKey",
                        RangeMatch = new Int64Range() { Start = e.PartitionLow.Value, End = e.PartitionHigh.Value }
                    });
                    break;
                case ServicePartitionKind.Named:
                    match.Headers.Add(new HeaderMatcher() { Name = "PartitionKey", ExactMatch = e.PartitionKey });
                    break;
            }

            return new Route
            {
                Route_ = new RouteAction()
                {
                    Cluster = clusterName,
                },
                Match = match
            };


        }

        public static RouteConfiguration ToRouteConfiguration(this IEnumerable<Route> routes, string name)
        {
            var envoyEgressRoute = new RouteConfiguration() { Name = name };
            var vHost = new VirtualHost { Name = $"{name}Services" };
            vHost.Domains.Add("*");
            vHost.Routes.AddRange(routes);
            envoyEgressRoute.VirtualHosts.Add(vHost);
            return envoyEgressRoute;
        }
    }
}