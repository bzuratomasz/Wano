using WanoControlService.Hosters;
using Autofac.Extras.DynamicProxy2;
using Autofac;
using log4net;
using System.Reflection;
using WanoControlService.Contracts;
using WanoControlService.Configurations;
using WanoControlService.Services.RegisterCardService;
using WCCServiceHost.Initializers.Interfaces;
using WCCCommon.Exceptions;
using WCCDatabaseORM.Schemes.Main.Contexts;
using WCCDatabaseORM.Models.Interfaces;
using WanoControlContracts.ServiceContracts;
using WanoControlService.Services.SRDataService;
using WCCInfrastructure.Services.RegisterCardService;
using WCCInfrastructure.Configuration;
using WCCInfrastructure.Services.SRDataService;
using WanoControlService.Services.ControllerService;
using WCCInfrastructure.Services.ControllerService;

namespace WanoControlService.Modules
{
    public class WanoControlServiceModule : Autofac.Module
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected override void Load(ContainerBuilder builder)
        {
            Logger.Debug("WanoControlService initialization...");

            builder
                .RegisterType<Configuration>()
                .As<IConfiguration>()
                .As<IDbConfiguration>()
                .SingleInstance();

            builder.RegisterType<MainDbContext>()
                .AsImplementedInterfaces()
                .AsSelf()
                .ExternallyOwned();

            builder
                .RegisterType<WorkflowServiceHostInitializer>()
                .As<IServiceHostInitializer>()
                .AutoActivate()
                .SingleInstance();

            builder
                .RegisterType<WanoCCService>()
                .As<IWanoService>()
                .SingleInstance();

            builder
                .RegisterType<ControllerService>()
                .As<IControllerService>()
                .SingleInstance()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(WCCException));

            builder
                .RegisterType<RegisterCardMainService>()
                .As<IRegisterCardService>()
                .SingleInstance()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(WCCException));

            builder
                .RegisterType<SRDataService>()
                .As<ISRDataService>()
                .SingleInstance()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(WCCException));


            builder.RegisterType<WCCException>()
                .AsSelf();
        }
    }
}
