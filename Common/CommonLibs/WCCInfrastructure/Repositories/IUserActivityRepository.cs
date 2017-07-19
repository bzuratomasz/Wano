using System;
using WCCCommon.Models;

namespace WCCInfrastructure.Repositories
{
    public interface IUserActivityRepository
    {
        void AddActivity(ActivityRequest req);
        int ActivityListCount();
    }
}
