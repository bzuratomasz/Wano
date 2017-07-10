using System;
using WanoControlContracts.DataContracts.ControllerConfigure;
using WanoControlContracts.DataContracts.RegisterCard;
using WanoControlContracts.ServiceContracts;
using WCCInfrastructure.Services.RegisterCardService;

namespace WanoControlService.Contracts
{
    public class WanoCCService : IWanoService
    {
        private readonly IRegisterCardService _registerCard;

        public WanoCCService(IRegisterCardService reg)
        {
            _registerCard = reg;
        }

        public ResponseRegisterCard RegisterCard(RequestRegisterCard card)
        {
            return _registerCard.RegisterCard(card);
        }


        public bool SetExpiredDateForCard(int cardId, DateTime expiredDate)
        {
            return _registerCard.SetExpiredDateForCard(cardId, expiredDate);
        }

        public bool ConnectToController(RequestControllerConfigure controller)
        {
            throw new NotImplementedException();
        }
    }
}
