using System;
using System.Collections.Generic;
using WanoControlContracts.DataContracts.RegisterCard;
using WCCCommon.Models;

namespace WCCInfrastructure.Repositories
{
    public interface ICardsRepository
    {
        void AddCard(RequestRegisterCard card);
        IEnumerable<RequestRegisterCard> GetCards();
        bool UpdateCardsPermissions(List<List<Status>> Permissions, int cardId);
    }
}
