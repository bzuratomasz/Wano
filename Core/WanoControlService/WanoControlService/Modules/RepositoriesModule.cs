using Autofac;
using log4net;
using System.Reflection;
using WanoControlService.Repositories;
using WCCCommon.Exceptions;
using Autofac.Extras.DynamicProxy2;
using WCCInfrastructure.Repositories;

namespace WanoControlService.Modules
{
    public class RepositoriesModule : Autofac.Module
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected override void Load(ContainerBuilder builder)
        {
            Logger.Debug("RepositoriesModule initialization...");

            builder
                .RegisterType<CardsRepository>()
                .As<ICardsRepository>();

            builder
                .RegisterType<UserActivityRepository>()
                .As<IUserActivityRepository>();

            builder
                .RegisterType<SRDataRepository>()
                .As<ISRDataRepository>();

            builder
                .RegisterType<DbRepository>()
                .As<IDbRepository>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(WCCException));

        }
    }
}
