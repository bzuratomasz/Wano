using System;
using WanoControlContracts.DataContracts.RegisterCard;
using WanoControlService.Services.SRDataService.Interfaces;
using WCCCommon.Models;
using WCCInfrastructure.Repositories;
using WCCInfrastructure.Services.RegisterCardService;

namespace WanoControlService.Services.RegisterCardService
{
    public class RegisterCardMainService : IRegisterCardService
    {

        private readonly ICardsRepository _repository;
        private readonly IUserActivityRepository _activity;
        private readonly ISRDataService _service;

        private RegisterContextCardService _context = new RegisterContextCardService(new RegisterH1CardService());

        public RegisterCardMainService(ICardsRepository repository, IUserActivityRepository activity, ISRDataService service)
        {
            _repository = repository;
            _activity = activity;
            _service = service;
        }

        public ResponseRegisterCard RegisterCard(RequestRegisterCard card)
        {
            ResponseRegisterCard result = null;

            if (card.CardId > 0)
            {
                _repository.AddCard(card.CardId, DateTime.MaxValue, "123");

                Report(card);

                result = _context.RegisterCard(card);
            }

            return result;
        }

        private void Report(RequestRegisterCard card)
        {
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

            _service.SaveInteraction(new SendReceiveData()
            {
                DeviceId = 600,
                ErrorText = "errorText"
            });
        }


        public bool SetExpiredDateForCard(int cardId, DateTime expiredDate)
        {
            return _context.SetExpiredDateForCard(cardId, expiredDate);
        }
    }
}
