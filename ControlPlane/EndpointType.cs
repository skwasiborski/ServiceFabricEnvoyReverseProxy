using System;
using System.Fabric;

namespace ControlPlane
{
    public class EndpointType
    {
        private readonly string _key;
        public string ServiceAbsolutePath { get; }
        public Guid PartitionId { get; }
        public string EndpointName { get; }
        public ServiceEndpointRole Role { get; }
        public string EgressId { get; }
        public string IngressId { get; }
        public bool DefaultEndpoint { get; }
        public ServicePartitionKind PartitionKind { get; }
        public long? PartitionLow { get; }
        public long? PartitionHigh { get; }
        public string PartitionKey { get; }

        private EndpointType(string serviceAbsolutePath, Guid partitionId, string endpointName,
            bool defaultEndpoint, ServiceEndpointRole role, ServicePartitionKind partitionKind, long? partitionLow,
            long? partitionHigh, string partitionKey)
        {
            ServiceAbsolutePath = serviceAbsolutePath;
            PartitionId = partitionId;
            EndpointName = endpointName;
            DefaultEndpoint = defaultEndpoint;
            Role = role;
            PartitionKind = partitionKind;
            PartitionLow = partitionLow;
            PartitionHigh = partitionHigh;
            PartitionKey = partitionKey;
            _key = $"{serviceAbsolutePath}|{partitionId}|{endpointName}|{role}";

            IngressId = $"I|{_key}";
            EgressId = $"E|{_key}";
        }

        public static EndpointType CreateStateless(string serviceAbsolutePath, Guid partitionId,
            string endpointName, bool defaultEndpoint)
        {
            return new EndpointType(serviceAbsolutePath,
                partitionId, endpointName, defaultEndpoint, ServiceEndpointRole.Stateless,
                ServicePartitionKind.Singleton, null, null, null);
        }

        public static EndpointType CreateSingleton(string serviceAbsolutePath, Guid partitionId,
            string endpointName, bool defaultEndpoint, ServiceEndpointRole role)
        {
            return new EndpointType(serviceAbsolutePath,
                partitionId, endpointName, defaultEndpoint, role, ServicePartitionKind.Singleton, null, null, null);
        }

        public static EndpointType CreateInt64Partitioned(string serviceAbsolutePath, Guid partitionId,
            string endpointName, bool defaultEndpoint, ServiceEndpointRole role, long partitionLow,
            long partitionHigh)
        {
            return new EndpointType(serviceAbsolutePath,
                partitionId, endpointName, defaultEndpoint, role, ServicePartitionKind.Int64Range, partitionLow,
                partitionHigh, null);
        }

        public static EndpointType CreateNamedPartitioned(string serviceAbsolutePath, Guid partitionId,
            string endpointName, bool defaultEndpoint, ServiceEndpointRole role, string partitionName)
        {
            return new EndpointType(serviceAbsolutePath,
                partitionId, endpointName, defaultEndpoint, role, ServicePartitionKind.Named, null, null,
                partitionName);
        }

        protected bool Equals(EndpointType other)
        {
            return string.Equals(_key, other._key);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((EndpointType)obj);
        }

        public override int GetHashCode()
        {
            return (_key != null ? _key.GetHashCode() : 0);
        }
    }
}