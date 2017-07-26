using System;
using System.Collections.Generic;
using WanoControlContracts.DataContracts.ControllerConfigure;
using WanoControlContracts.DataContracts.RegisterCard;
using WanoControlContracts.ServiceContracts;
using WCCInfrastructure.Services.ControllerService;
using WCCInfrastructure.Services.RegisterCardService;
using System.Linq;
using WCCCommon.Models;

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


        public List<RequestRegisterCard> GetCards()
        {
            return _registerCard.GetCards().ToList();
        }


        public bool UpdateCardsPermissions(List<List<Status>> Permissions, int cardId)
        {
            return _registerCard.UpdateCardsPermissions(Permissions, cardId);
        }


        public ResponseControllerConfigure GetController()
        {
            var inputCollection = _controllerService.GetController();

            var resultCollection = new ResponseControllerConfigure()
               {
                   Ip = inputCollection.ip,
                   Mask = inputCollection.mask,
                   Port = inputCollection.port,
                   PcIPAddr = inputCollection.pcIPAddr,
                   HolidayControl = inputCollection.holidayControl,
                   Gateway = inputCollection.gateway,
                   SN = inputCollection.controllerSN
               };

            return resultCollection;
        }
    }
}
