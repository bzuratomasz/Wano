﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanoControlContracts.DataContracts.RegisterCard;
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
                context.Activity.AddRange(list.ToList());
                context.SaveChanges();
            }
        }


        public void AddCard(RequestRegisterCard card)
        {
            using (var context = new MainDbContext(_conf))
            {
                context.Cards.Add(new CardsEntity()
                {
                    CardId = card.CardId,
                    IsDeleted = card.Deleted,
                    Password = card.Password,
                    YmdStart = card.StartTime,
                    YmdEnd = card.EndTime
                });

                context.SaveChanges();
            }
        }


        public IEnumerable<RequestRegisterCard> GetCards()
        {
            IEnumerable<RequestRegisterCard> resultCollection = null;

            using (var context = new MainDbContext(_conf))
            {
                resultCollection = context.Cards.Select(x => new RequestRegisterCard()
                {
                    CardId = x.CardId,
                    Deleted = x.IsDeleted,
                    EndTime = x.YmdEnd,
                    Password = x.Password,
                    StartTime = x.YmdStart
                })
                .ToList();
            }

            return resultCollection.AsEnumerable();
        }
    }
}
