using System;
using System.Collections.Generic;
using System.Fabric;
using System.Fabric.Description;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Envoy.ControlPlane.Server;
using Envoy.ControlPlane.Server.Cache;
using Envoy.Service.Discovery.V2;
using Grpc.Core;
using Grpc.Core.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ServiceFabric.Data;
using Microsoft.ServiceFabric.Services.Communication.AspNetCore;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace EnvoyControlPlane
{
    /// <summary>
    /// An instance of this class is created for each service replica by the Service Fabric runtime.
    /// </summary>
    internal sealed class EnvoyControlPlane : StatefulService
    {
        private readonly ILogger _logger;
        private readonly SnapshotCache _cache;
        private readonly FabricClient _client;
        private readonly ConfigurationService _configurationService;

        public const string RoutesStateName = "sfRoutes";

        public EnvoyControlPlane(StatefulServiceContext context)
            : base(context)
        {
            _logger = new ConsoleLogger();
            _cache = new SnapshotCache(true, _logger);
            _client = new FabricClient();
            _configurationService = new ConfigurationService(_logger, _cache, _client, this.StateManager);
        }

        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            return new[]
            {
                new ServiceReplicaListener(serviceContext =>
                    new KestrelCommunicationListener(serviceContext, (url, listener) =>
                        new WebHostBuilder()
                            .UseKestrel()
                            .ConfigureServices(
                                services => services
                                    .AddSingleton<StatefulServiceContext>(serviceContext)
                                    .AddSingleton<IReliableStateManager>(this.StateManager)
                                    .AddSingleton<ConfigurationService>(_configurationService))
                            .UseContentRoot(Directory.GetCurrentDirectory())
                            .UseServiceFabricIntegration(listener, ServiceFabricIntegrationOptions.UseUniqueServiceUrl)
                            .UseStartup<Startup>()
                            .UseUrls(url)
                            .Build()
                )),
                new ServiceReplicaListener(serviceContext =>
                    new GrpcCommunicationListener(new[] { (Func<CancellationToken, ServerServiceDefinition>)(ct => AggregatedDiscoveryService.BindService(new Services(_cache, _logger, ct).AggregatedService)) }, serviceContext, "AdsEndpoint"))
            };
        }

        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            void Handler(object sender, EventArgs args)
            {
                _configurationService.SignalNewConfiguration();
            }

            long? regitrationId = null;

            cancellationToken.Register(async () =>
            {
                _client.ServiceManager.ServiceNotificationFilterMatched -= Handler;
                if (regitrationId.HasValue)
                {
                    await _client.ServiceManager.UnregisterServiceNotificationFilterAsync(regitrationId.Value);
                }
            });

            _client.ServiceManager.ServiceNotificationFilterMatched += Handler;
            regitrationId = await _client.ServiceManager.RegisterServiceNotificationFilterAsync(new ServiceNotificationFilterDescription(new Uri("fabric:"), true, false));
            _configurationService.SignalNewConfiguration();

            await _configurationService.Start(cancellationToken);
        }
    }
}
