using System;
using System.Collections.Generic;
using WanoControlContracts.DataContracts.ControllerConfigure;
using WanoControlContracts.DataContracts.RegisterCard;
using WanoControlContracts.ServiceContracts;
using WCCInfrastructure.Services.ControllerService;
using WCCInfrastructure.Services.RegisterCardService;

namespace WanoControlService.Contracts
{
    public class WanoCCService : IWanoService
    {
        private readonly IRegisterCardService _registerCard;
        private readonly IControllerService _controllerService;

        public WanoCCService(IRegisterCardService reg, IControllerService controllerService)
        {
            _registerCard = reg;
            _controllerService = controllerService;
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
            return _controllerService.ConnectToController(controller);
        }


        public void ResetToDefault()
        {
            if (_controllerService.Controller != null)
            {
                _controllerService.Controller.RestoreDefault();
            }
        }


        public List<RequestRegisterCard> GetCards()
        {
            return _registerCard.GetCards();
        }
    }
}
