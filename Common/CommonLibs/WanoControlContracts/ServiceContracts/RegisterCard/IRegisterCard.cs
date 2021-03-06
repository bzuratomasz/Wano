﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using WanoControlContracts.DataContracts;
using WanoControlContracts.DataContracts.RegisterCard;
using WCCCommon.Models;

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

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        List<RequestRegisterCard> GetCards();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        bool UpdateCardsPermissions(List<List<Status>> Permissions, int cardId);
    }
}
