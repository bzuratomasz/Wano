﻿using System;
using WanoControlContracts.DataContracts.RegisterCard;
using WCCInfrastructure.Services.RegisterCardService;
using WG3000_COMM.Core;

namespace WanoControlService.Services.RegisterCardService
{
    public class RegisterH1CardService : IStrategyRegisterCardService
    {

        public ResponseRegisterCard RegisterCard(RequestRegisterCard card)
        {
            var register = new MjRegisterCard();
            register.CardID = card.CardId;
            return new ResponseRegisterCard() 
            {
                Registered = true
            };
        }


        public bool SetExpiredDateForCard(int cardId, DateTime expiredDate)
        {
            var register = new MjRegisterCard();
            register.ymdEnd = expiredDate;
            register.CardID = (uint)cardId;
            return true;
        }
    }
}
