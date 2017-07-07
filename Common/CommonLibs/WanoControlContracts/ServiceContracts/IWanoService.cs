using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WanoControlContracts.ServiceContracts.ControllerConfigure;
using WanoControlContracts.ServiceContracts.RegisterCard;

namespace WanoControlContracts.ServiceContracts
{
    [ServiceContract]
    public interface IWanoService : IRegisterCard, IControllerConfigure
    {
    }
}
