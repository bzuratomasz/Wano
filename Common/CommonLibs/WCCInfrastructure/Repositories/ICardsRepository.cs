using System;
using System.Collections.Generic;
using WanoControlContracts.DataContracts.RegisterCard;

namespace WCCInfrastructure.Repositories
{
    public interface ICardsRepository
    {
        void AddCard(int cardID, DateTime endDate, int pass);
        List<RequestRegisterCard> GetCards();
    }
}
