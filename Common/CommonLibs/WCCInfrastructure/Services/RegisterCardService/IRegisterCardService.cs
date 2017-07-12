using System;
using System.Collections.Generic;
using WanoControlContracts.DataContracts.RegisterCard;
using WCCCommon.Models;

namespace WCCInfrastructure.Services.RegisterCardService
{
    public interface IRegisterCardService
    {
        ResponseRegisterCard RegisterCard(RequestRegisterCard card);
        bool SetExpiredDateForCard(int cardId, DateTime expiredDate);
        IEnumerable<RequestRegisterCard> GetCards();
        bool UpdateCardsPermissions(List<List<Status>> Permissions, int cardId);
    }
}
