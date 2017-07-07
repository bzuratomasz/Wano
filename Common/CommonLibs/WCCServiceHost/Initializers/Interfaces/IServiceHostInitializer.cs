using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCCServiceHost.Initializers.Interfaces
{
    public interface IServiceHostInitializer
    {
        ServiceHost Initialize();
    }
}
