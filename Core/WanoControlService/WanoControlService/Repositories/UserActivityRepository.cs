using log4net;
using System;
using System.Collections.Generic;
using System.Reflection;
using WCCDatabaseORM.Schemes.Main.Contexts;
using WCCCommon.Models;
using WCCDatabaseORM.Schemes.Main.Entities;
using System.Linq;
using WCCInfrastructure.Repositories;
using WCCInfrastructure.Configuration;
using WCCInfrastructure.Services.UserActivityService;

namespace WanoControlService.Repositories
{
    public class UserActivityRepository : IUserActivityRepository, IDisposable
    {
        private static readonly ILog Logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private List<ActivityRequest> _activityRequestList = new List<ActivityRequest>();
        private readonly IUserActivityTimer _ticker;
        private IDisposable _timerHandle;
        private readonly object _syncLocker = new object();
        private bool _disposed = false;

        private readonly IDbRepository _repo;

        public UserActivityRepository(IUserActivityTimer ticker, IDbRepository repo)
        {
            _ticker = ticker;
            _repo = repo;
            Init();
        }

        private void Init()
        {
            lock (_syncLocker)
            {
                if (_timerHandle != null)
                {
                    throw new Exception("Timer is not stopped. Use StopTimer first.");
                }

                _timerHandle = _ticker.ActivityToRead.Subscribe(i =>
                {
                    try
                    {
                        Logger.Debug("UserActivityRepository - TimerTick()");
                        OnNext();
                    }
                    catch (Exception err)
                    {
                        OnError(err);
                    }
                },
                e => OnError(e),
                () => OnCompleted());
            }
        }

        private void OnNext()
        {
            if (_activityRequestList.Count > 0)
            {
                List<ActivityEntity> result = _activityRequestList.Select(x => new ActivityEntity()
                {
                    ActivityText = x.ActivityText,
                    IsVip = x.IsVip,
                    Time = x.Time,
                    UserName = x.UserName

                }).ToList();

                _repo.AddUserActivity(result);

                lock (_syncLocker)
                {
                    _activityRequestList.Clear();
                }
            }
        }

        public void OnCompleted()
        {
            Logger.Info("[UserActivityRepository] [OnCompleted]");
        }

        public void OnError(Exception error)
        {
            Logger.ErrorFormat("[UserActivityRepository] [OnError] error: {0}", error);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                if (_timerHandle != null)
                {
                    _timerHandle.Dispose();
                    Logger.Debug("_timerHandle - Dispose()");
                }
            }

            _disposed = true;
        }

        public void AddActivity(ActivityRequest req)
        {
            lock (_syncLocker)
            {
                if (req.UserName != null)
                {
                    _activityRequestList.Add(req);
                }
                else 
                {
                    throw new Exception("Specify UserName property please!");
                }
            }
        }

        public int ActivityListCount()
        {
            return _activityRequestList.Count;
        }
    }
}
