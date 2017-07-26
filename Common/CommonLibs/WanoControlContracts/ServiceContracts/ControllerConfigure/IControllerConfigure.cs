using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using WanoControlContracts.DataContracts.ControllerConfigure;

namespace WanoControlContracts.ServiceContracts.ControllerConfigure
{
    [ServiceContract]
    public interface IControllerConfigure
    {
        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        bool ConnectToController(RequestControllerConfigure controller);

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        ResponseControllerConfigure GetController();
    }
}
