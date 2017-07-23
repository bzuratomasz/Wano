using System;
using System.Collections.Generic;
using WanoControlContracts.DataContracts.RegisterCard;
using WCCCommon.Models;
using WCCDatabaseORM.Models.Interfaces;
using WCCDatabaseORM.Schemes.Main.Contexts;
using WCCDatabaseORM.Schemes.Main.Entities;
using WCCInfrastructure.Repositories;

namespace WanoControlService.Repositories
{
    public class CardsRepository : ICardsRepository
    {
        private readonly IDbRepository _repo;

        public CardsRepository(IDbRepository repo)
        {
            _repo = repo;
        }

        public void AddCard(RequestRegisterCard card)
        {
            if (card.CardId > 0)
            {
                _repo.AddCard(card);
            }
        }


        public IEnumerable<RequestRegisterCard> GetCards()
        {
            return _repo.GetCards();
        }


        public bool UpdateCardsPermissions(List<List<Status>> Permissions, int cardId)
        {
            bool result = false;

            if (cardId > 0)
            {
                result = _repo.UpdateCardsPermissions(Permissions, cardId);
            }
            else 
            {
                throw new Exception("CardId is null!");
            }

            return result;
        }
    }
}
