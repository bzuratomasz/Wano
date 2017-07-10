using System;

namespace WCCInfrastructure.Repositories
{
    public interface ICardsRepository
    {
        void AddCard(uint cardID, DateTime endDate, uint pass);
    }
}
