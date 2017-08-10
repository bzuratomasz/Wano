using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanoControlCenter.Models;
using WanoControlCenter.Repositories;

namespace WanoControlCenter.Bootstrappers
{
    public class ServiceBootstrapper : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServiceModel>()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<SupervisorUiRepository>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}
