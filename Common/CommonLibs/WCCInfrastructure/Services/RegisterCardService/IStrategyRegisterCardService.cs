using System;
using WanoControlContracts.DataContracts.RegisterCard;

namespace WCCInfrastructure.Services.RegisterCardService
{
    public interface IStrategyRegisterCardService
    {
        ResponseRegisterCard RegisterCard(RequestRegisterCard card);
        bool SetExpiredDateForCard(int cardId, DateTime expiredDate);
    }
}
