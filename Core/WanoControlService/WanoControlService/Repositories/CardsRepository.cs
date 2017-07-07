using System;
using WCCDatabaseORM.Models.Interfaces;
using WCCDatabaseORM.Schemes.Main.Contexts;
using WCCDatabaseORM.Schemes.Main.Entities;
using WCCInfrastructure.Repositories;

namespace WanoControlService.Repositories
{
    public class CardsRepository : ICardsRepository
    {
        private readonly IDbConfiguration _conf;

        public CardsRepository(IDbConfiguration conf)
        {
            _conf = conf;
        }

        public void AddCard(uint cardID, DateTime endDate, string pass)
        {
            using (var context = new MainDbContext(_conf))
            {
                context.Cards.Add(new CardsEntity()
                {
                    CardId = (int)cardID,
                    IsDeleted = false,
                    Password = pass,
                    YmdStart = DateTime.Now,
                    YmdEnd = endDate
                });

                context.SaveChanges();
            }
        }
    }
}
