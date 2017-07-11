using System;
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

        public void AddCard(uint cardID, DateTime endDate, uint pass)
        {
            _repo.AddCard(cardID, endDate, pass);
        }
    }
}
