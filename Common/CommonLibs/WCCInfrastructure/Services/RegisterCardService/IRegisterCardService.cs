using System;
using System.Collections.Generic;
using WanoControlContracts.DataContracts.RegisterCard;

namespace WCCInfrastructure.Services.RegisterCardService
{
    public interface IRegisterCardService
    {
        ResponseRegisterCard RegisterCard(RequestRegisterCard card);
        bool SetExpiredDateForCard(int cardId, DateTime expiredDate);
        List<RequestRegisterCard> GetCards();
    }
}
