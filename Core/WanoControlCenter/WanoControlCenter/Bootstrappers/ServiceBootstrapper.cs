using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanoControlCenter.Model;
using WanoControlCenter.View;
using WanoControlCenter.View.UserControls;

namespace WanoControlCenter.Bootstrappers
{
    public class ServiceBootstrapper : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WCCModel>()
                .AsImplementedInterfaces()
                .SingleInstance();
                  
        }
    }
}
