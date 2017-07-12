using System;
using System.Collections.Generic;
using WanoControlContracts.DataContracts.RegisterCard;

namespace WCCInfrastructure.Repositories
{
    public interface ICardsRepository
    {
        void AddCard(RequestRegisterCard card);
        IEnumerable<RequestRegisterCard> GetCards();
    }
}
