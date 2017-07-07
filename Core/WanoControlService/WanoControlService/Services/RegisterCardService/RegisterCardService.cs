using System;
using WanoControlContracts.DataContracts.RegisterCard;
using WanoControlService.Services.SRDataService.Interfaces;
using WCCCommon.Models;
using WCCInfrastructure.Repositories;
using WCCInfrastructure.Services.RegisterCardService;

namespace WanoControlService.Services.RegisterCardService
{
    public class RegisterCardService : IRegisterCardService
    {

        private readonly ICardsRepository _repository;
        private readonly IUserActivityRepository _activity;
        private readonly ISRDataService _service;

        private RegisterContextCardService _context = new RegisterContextCardService(new RegisterH1CardService());

        public RegisterCardService(ICardsRepository repository, IUserActivityRepository activity, ISRDataService service)
        {
            _repository = repository;
            _activity = activity;
            _service = service;
        }

        public ResponseRegisterCard RegisterCard(RequestRegisterCard card)
        {
            _repository.AddCard(card.CardId, DateTime.MaxValue, "123");

            //Only for TEST!
            _activity.AddActivity(new ActivityRequest() 
            { 
                Time = DateTime.Now,
                UserName = "admin",
                IsVip = true,
                ActivityText = string.Format("Adding card! Data: {0}, {1}, {2}", 
                                            card.CardId, 
                                            DateTime.MaxValue, 
                                            "123")
            });

            //Only for TEST!
            _service.SaveInteraction(new SendReceiveData() 
            {
                DeviceId = 600,
                ErrorText = "errorText"
            });

            return _context.RegisterCard(card);
        }


        public bool SetExpiredDateForCard(int cardId, DateTime expiredDate)
        {
            return _context.SetExpiredDateForCard(cardId, expiredDate);
        }
    }
}
