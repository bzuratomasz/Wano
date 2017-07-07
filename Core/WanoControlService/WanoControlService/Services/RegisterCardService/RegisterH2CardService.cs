using System;
using WanoControlContracts.DataContracts.RegisterCard;
using WCCInfrastructure.Services.RegisterCardService;

namespace WanoControlService.Services.RegisterCardService
{
    public class RegisterH2CardService : IStrategyRegisterCardService
    {

        public ResponseRegisterCard RegisterCard(RequestRegisterCard card)
        {
            throw new NotImplementedException();
        }


        public bool SetExpiredDateForCard(int cardId, DateTime expiredDate)
        {
            throw new NotImplementedException();
        }
    }
}
