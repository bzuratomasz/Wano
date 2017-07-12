using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanoControlContracts.DataContracts.RegisterCard;
using WCCCommon.Models;
using WCCDatabaseORM.Schemes.Main.Entities;

namespace WCCInfrastructure.Repositories
{
    public interface IDbRepository
    {
        void AddSRData(SRData data);
        void AddUserActivity(List<ActivityEntity> list);
        void AddCard(RequestRegisterCard card);
        IEnumerable<RequestRegisterCard> GetCards();
        bool UpdateCardsPermissions(List<List<Status>> Permissions, int cardId);
    }
}
