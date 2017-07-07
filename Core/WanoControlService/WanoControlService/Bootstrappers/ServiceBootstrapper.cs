using Autofac;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WanoControlService.Hosters;
using Autofac.Extras.DynamicProxy2;
using WanoControlService.Modules;
using WCCServiceHost.Initializers.Interfaces;

namespace WanoControlService.Bootstrappers
{
    public class ServiceBootstrapper : IDisposable
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Autofac.IContainer _container;

        public ServiceBootstrapper()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new WanoControlServiceModule());
            builder.RegisterModule(new RepositoriesModule());
            builder.RegisterModule(new UserActivityModule());

            _container = builder.Build();
        }

        public void Start()
        {
            if (_container != null) 
            {
                var _host = _container.Resolve<IServiceHostInitializer>();
                _host.Initialize();
            }
        }

        public void Dispose()
        {
            if (_container != null)
                _container.Dispose();
        }
    }
}
