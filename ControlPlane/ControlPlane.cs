using System;
using System.Collections.Generic;
using System.Fabric;
using System.Fabric.Description;
using System.Threading;
using System.Threading.Tasks;
using Envoy.ControlPlane.Server;
using Envoy.ControlPlane.Server.Cache;
using Envoy.Service.Discovery.V2;
using Grpc.Core;
using Grpc.Core.Logging;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using StatelessService = Microsoft.ServiceFabric.Services.Runtime.StatelessService;

namespace ControlPlane
{
    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    internal sealed class ControlPlane : StatelessService
    {
        private SnapshotCache cache;
        private ILogger logger;

        public ControlPlane(StatelessServiceContext context)
            : base(context)
        {
            logger = new ConsoleLogger();
            cache = new SnapshotCache(true, logger);
        }

        /// <summary>
        /// Optional override to create listeners (e.g., TCP, HTTP) for this service replica to handle client or user requests.
        /// </summary>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new[]
            {
                new ServiceInstanceListener(serviceContext =>
                    new GrpcCommunicationListener(new[] { (Func<CancellationToken, ServerServiceDefinition>)(ct => AggregatedDiscoveryService.BindService(new Services(cache, logger, ct).AggregatedService)) }, serviceContext))
            };
        }

        /// <summary>
        /// This is the main entry point for your service instance.
        /// </summary>
        /// <param name="cancellationToken">Canceled when Service Fabric needs to shut down this service instance.</param>
        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            var client = new FabricClient();
            await MaintainSnapshotCache(client, cache, logger, cancellationToken);
            await Task.Delay(TimeSpan.FromMilliseconds(-1), cancellationToken);

            GC.KeepAlive(client);
        }

        static async Task MaintainSnapshotCache(FabricClient client, SnapshotCache cache, ILogger logger, CancellationToken cancellationToken)
        {
            async void Handler(object sender, EventArgs args)
            {
                await SetSnapshotsOnCache(cache, logger, client);
            }

            long? regitrationId = null;

            cancellationToken.Register(async () =>
            {
                client.ServiceManager.ServiceNotificationFilterMatched -= Handler;
                if (regitrationId.HasValue)
                {
                    await client.ServiceManager.UnregisterServiceNotificationFilterAsync(regitrationId.Value);
                }
            });

            client.ServiceManager.ServiceNotificationFilterMatched += Handler;
            regitrationId = await client.ServiceManager.RegisterServiceNotificationFilterAsync(new ServiceNotificationFilterDescription(new Uri("fabric:"), true, false));

            await SetSnapshotsOnCache(cache, logger, client);
        }

        private static async Task SetSnapshotsOnCache(SnapshotCache cache, ILogger logger, FabricClient client)
        {
            var snapshots = await GetSnapshots(logger, client);

            lock (cache)
            {
                foreach (var snapshot in snapshots)
                {
                    cache.SetSnapshot(snapshot.Key, snapshot.Value);
                }
            }
        }

        private static async Task<Dictionary<string, Snapshot>> GetSnapshots(ILogger logger, FabricClient client)
        {
            var (endpointInstances, nodeAdresses) = await client.GetEndpointInstances(logger);
            var snapshots = EndpointInstancesToEnvoyTransormations.CreateEnvoySnapshots(nodeAdresses, endpointInstances);
            return snapshots;
        }
    }
}
