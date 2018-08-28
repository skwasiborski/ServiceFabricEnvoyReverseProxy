using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Data;
using Microsoft.ServiceFabric.Data.Collections;

namespace EnvoyControlPlane
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RouteController : ControllerBase
    {
        private readonly ConfigurationService _configurationService;
        private readonly IReliableStateManager _stateManager;

        public RouteController(ConfigurationService configurationService, IReliableStateManager stateManager)
        {
            _configurationService = configurationService;
            _stateManager = stateManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SfRoute>>> GetAll()
        {
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

            return sfRoutes;
        }

        [HttpPost("{name}")]
        public async Task Create(string name, [FromBody] SfRoute route)
        {
            var sfReoutesDic =
                await _stateManager.GetOrAddAsync<IReliableDictionary<string, SfRoute>>(EnvoyControlPlane.RoutesStateName);

            using (var tx = _stateManager.CreateTransaction())
            {
                await sfReoutesDic.AddAsync(tx, name, route);
            }

            _configurationService.SignalNewConfiguration();
        }

        [HttpPut("{name}")]
        public async Task Update(string name, [FromBody] SfRoute route)
        {
            var sfReoutesDic =
                await _stateManager.GetOrAddAsync<IReliableDictionary<string, SfRoute>>(EnvoyControlPlane.RoutesStateName);

            using (var tx = _stateManager.CreateTransaction())
            {
                await sfReoutesDic.AddOrUpdateAsync(tx, name, _ => route, (_, __) => route);
            }

            _configurationService.SignalNewConfiguration();
        }

        [HttpDelete("{name}")]
        public async Task Delete(string name)
        {
            var sfReoutesDic =
                await _stateManager.GetOrAddAsync<IReliableDictionary<string, SfRoute>>(EnvoyControlPlane.RoutesStateName);

            using (var tx = _stateManager.CreateTransaction())
            {
                await sfReoutesDic.TryRemoveAsync(tx, name);
            }

            _configurationService.SignalNewConfiguration();
        }
    }
}