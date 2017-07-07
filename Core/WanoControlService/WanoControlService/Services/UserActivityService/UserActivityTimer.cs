using System;
using System.Reactive.Linq;
using WCCInfrastructure.Configuration;
using WCCInfrastructure.Services.UserActivityService;

namespace WanoControlService.Services.UserActivityService
{
    public class UserActivityTimer : IUserActivityTimer
    {
        private IObservable<long> _obs;
        private readonly IConfiguration _configuration;

        public UserActivityTimer(IConfiguration conf)
        {
            _configuration = conf;

            _obs = Observable
                .Interval(TimeSpan.FromSeconds(1));
        }

        public IObservable<IObservable<long>> ActivityToRead
        {
            get
            {
                return _obs.Window(() =>
                    {
                        IObservable<long> seqWindow = Observable.Interval(TimeSpan.FromSeconds(_configuration.Timer));
                        return seqWindow;
                    });
            }
        }
    }
}
