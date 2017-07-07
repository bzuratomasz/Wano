using System;
using WanoControlContracts.DataContracts.RegisterCard;
using WCCInfrastructure.Services.RegisterCardService;

namespace WanoControlService.Services.RegisterCardService
{
    public class RegisterContextCardService
    {
        private IStrategyRegisterCardService _strategy = null;

        public RegisterContextCardService(IStrategyRegisterCardService st)
        {
            this._strategy = st;
        }

        public ResponseRegisterCard RegisterCard(RequestRegisterCard card) 
        {
            return this._strategy.RegisterCard(card);
        }

        public bool SetExpiredDateForCard(int cardId, DateTime expiredDate) 
        {
            return this._strategy.SetExpiredDateForCard(cardId, expiredDate);
        }
    }
}
