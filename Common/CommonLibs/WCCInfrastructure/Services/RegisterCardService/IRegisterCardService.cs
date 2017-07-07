using System;
using WanoControlContracts.DataContracts.RegisterCard;

namespace WCCInfrastructure.Services.RegisterCardService
{
    public interface IRegisterCardService
    {
        ResponseRegisterCard RegisterCard(RequestRegisterCard card);
        bool SetExpiredDateForCard(int cardId, DateTime expiredDate);
    }
}
