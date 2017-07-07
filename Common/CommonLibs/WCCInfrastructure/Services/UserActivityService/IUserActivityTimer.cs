using System;


namespace WCCInfrastructure.Services.UserActivityService
{
    public interface IUserActivityTimer
    {
        IObservable<IObservable<long>> ActivityToRead { get; }
    }
}
