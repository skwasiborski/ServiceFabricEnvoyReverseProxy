using System;

namespace EnvoyControlPlane
{
    public class EndpointInstance
    {
        public EndpointType Type { get; }
        public Uri NetworkAddress { get; }
        public string NodeName { get; }

        public EndpointInstance(EndpointType type, Uri networkAddress, string nodeName)
        {
            Type = type;
            NetworkAddress = networkAddress;
            NodeName = nodeName;
        }
    }
}