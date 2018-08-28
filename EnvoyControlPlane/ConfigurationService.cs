using System.Collections.Generic;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;
using Envoy.ControlPlane.Server.Cache;
using Grpc.Core.Logging;
using Microsoft.ServiceFabric.Data;
using Microsoft.ServiceFabric.Data.Collections;
using Nito.AsyncEx;

namespace EnvoyControlPlane
{
    public class ConfigurationService
    {
        private readonly ILogger _logger;
        private readonly SnapshotCache _cache;
        private readonly FabricClient _client;
        private readonly IReliableStateManager _stateManager;
        private readonly AsyncAutoResetEvent _newConfigurationAvailablEvent = new AsyncAutoResetEvent(false);

        public ConfigurationService(ILogger logger, SnapshotCache cache, FabricClient client, IReliableStateManager stateManager)
        {
            this._logger = logger;
            this._cache = cache;
            this._client = client;
            this._stateManager = stateManager;
        }

        public async Task Start(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await _newConfigurationAvailablEvent.WaitAsync(token);
                await SetSnapshotsOnCache();
            }
        }

        public void SignalNewConfiguration()
        {
            _newConfigurationAvailablEvent.Set();
        }

        private async Task SetSnapshotsOnCache()
        {
            var snapshots = await GetSnapshots();

            lock (_cache)
            {
                foreach (var snapshot in snapshots)
                {
                    _cache.SetSnapshot(snapshot.Key, snapshot.Value);
                }
            }
        }

        private async Task<Dictionary<string, Snapshot>> GetSnapshots()
        {
            var (endpointInstances, nodeAdresses) = await _client.GetEndpointInstances(_logger);
            var sfReoutesDic = await _stateManager.GetOrAddAsync<IReliableDictionary<string, SfRoute>>(EnvoyControlPlane.RoutesStateName);

            List<SfRoute> sfRoutes = new List<SfRoute>();
            using (var tx = _stateManager.CreateTransaction())
            {
                var raoutesEnumerator = (await sfReoutesDic.CreateEnumerableAsync(tx)).GetAsyncEnumerator();
                while (await raoutesEnumerator.MoveNextAsync(CancellationToken.None))
                {
                    sfRoutes.Add(raoutesEnumerator.Current.Value);
                }
            }

            var snapshots = EndpointInstancesToEnvoyTransormations.CreateEnvoySnapshots(nodeAdresses, endpointInstances, sfRoutes);
            return snapshots;
        }
    }
}