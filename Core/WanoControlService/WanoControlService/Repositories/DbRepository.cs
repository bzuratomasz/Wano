using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCCCommon.Models;
using WCCDatabaseORM.Schemes.Main.Contexts;
using WCCDatabaseORM.Schemes.Main.Entities;
using WCCInfrastructure.Configuration;
using WCCInfrastructure.Repositories;

namespace WanoControlService.Repositories
{
    public class DbRepository : IDbRepository
    {
        private readonly IConfiguration _conf;

        public DbRepository(IConfiguration conf)
        {
            _conf = conf;
        }

        public void AddSRData(SRData sr)
        {
            using (var context = new MainDbContext(_conf))
            {
                SRDataEntity result = new SRDataEntity()
                {
                    DeviceId = sr.Data.DeviceId,
                    ErrorText = sr.Data.ErrorText,
                    Frequency = sr.Data.Frequency,
                    SendData = sr.Data.SendData,
                    Status = sr.Data.Status
                };

                context.SRData.Add(result);
                context.SaveChanges();
            }
        }

        public void AddUserActivity(List<ActivityEntity> list)
        {
            using (var context = new MainDbContext(_conf))
            {
                context.Activity.AddRange(list);
                context.SaveChanges();
            }
        }


        public void AddCard(uint cardID, DateTime endDate, uint pass)
        {
            using (var context = new MainDbContext(_conf))
            {
                context.Cards.Add(new CardsEntity()
                {
                    CardId = (int)cardID,
                    IsDeleted = false,
                    Password = (int)pass,
                    YmdStart = DateTime.UtcNow,
                    YmdEnd = endDate
                });

                context.SaveChanges();
            }
        }
    }
}
