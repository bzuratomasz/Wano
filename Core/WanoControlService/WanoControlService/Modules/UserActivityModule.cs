using Autofac;
using log4net;
using System.Reflection;
using WanoControlService.Services.UserActivityService;
using WCCInfrastructure.Services.UserActivityService;


namespace WanoControlService.Modules
{
    public class UserActivityModule : Autofac.Module
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected override void Load(ContainerBuilder builder)
        {
            Logger.Debug("UserActivityModule initialization...");

            builder
                .RegisterType<UserActivityTimer>()
                .As<IUserActivityTimer>()
                .SingleInstance();

        }
    }
}
