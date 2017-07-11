using System;
using System.Collections.Generic;
using WanoControlContracts.DataContracts.RegisterCard;
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

        public void AddCard(int cardID, DateTime endDate, int pass)
        {
            _repo.AddCard(cardID, endDate, pass);
        }


        public List<RequestRegisterCard> GetCards()
        {
            return _repo.GetCards();
        }
    }
}
