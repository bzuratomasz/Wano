using Autofac;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using WanoControlContracts.ServiceContracts;
using WanoControlService.Contracts;
using WCCInfrastructure.Configuration;
using WCCServiceHost.Initializers;

namespace WanoControlService.Hosters
{
    public class WorkflowServiceHostInitializer : CustomServiceHostInitializer<WanoCCService, IWanoService>
    {
        private readonly IConfiguration _configuration;

        public WorkflowServiceHostInitializer(ILifetimeScope lifetimeScope, IConfiguration configuration)
            : base(lifetimeScope)
        {
            if (configuration == null) throw new ArgumentNullException();
            _configuration = configuration;
        }

        protected override ServiceHost CreateServiceHost()
        {
            Uri address = new Uri(_configuration.Url);
            var host = new ServiceHost(typeof(WanoCCService), address);
            ServiceMetadataBehavior metadataBehavior = new ServiceMetadataBehavior();
            metadataBehavior.HttpGetEnabled = true;

            var basicHttpBinding = new BasicHttpBinding
            {
                MaxBufferPoolSize = int.MaxValue,
                MaxBufferSize = int.MaxValue,
                MaxReceivedMessageSize = int.MaxValue
            };

            var webHttpBinding = new WebHttpBinding
            {
                MaxBufferPoolSize = int.MaxValue,
                MaxBufferSize = int.MaxValue,
                MaxReceivedMessageSize = int.MaxValue
            };


            AddOrReplaceBehavior(host, metadataBehavior);

            host.AddServiceEndpoint(typeof(IWanoService), webHttpBinding, "web");
            host.AddServiceEndpoint(typeof(IWanoService), basicHttpBinding, "");

            Console.WriteLine("The service is ready at {0}", address);
            Console.WriteLine("Press <Enter> to stop the service.");

            return host;
        }

        private static void AddOrReplaceBehavior<T>(ServiceHost service, T behavior)
        {
            var defaultBehavior = service.Description.Behaviors.Find<T>();
            if (defaultBehavior != null)
            {
                service.Description.Behaviors.Remove<T>();
            }
            service.Description.Behaviors.Add((IServiceBehavior)behavior);
        }
    }
}
