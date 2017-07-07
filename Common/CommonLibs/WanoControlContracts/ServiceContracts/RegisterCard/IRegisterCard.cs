using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using WanoControlContracts.DataContracts;
using WanoControlContracts.DataContracts.RegisterCard;

namespace WanoControlContracts.ServiceContracts.RegisterCard
{
    [ServiceContract]
    public interface IRegisterCard
    {
        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        ResponseRegisterCard RegisterCard(RequestRegisterCard card);

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        bool SetExpiredDateForCard(int cardId, DateTime expiredDate);
    }
}
