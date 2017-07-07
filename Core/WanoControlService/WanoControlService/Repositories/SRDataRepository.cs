using log4net;
using System;
using System.Reflection;
using WanoControlService.Services.SRDataService;
using WanoControlService.Services.SRDataService.Interfaces;
using WCCDatabaseORM.Schemes.Main.Contexts;
using WCCDatabaseORM.Schemes.Main.Entities;
using WCCInfrastructure.Repositories;
using WCCInfrastructure.Configuration;

namespace WanoControlService.Repositories
{
    public class SRDataRepository : ISRDataRepository
    {

        private static readonly ILog Logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ISRDataService _service;
        private bool _disposed = false;
        private IDisposable _handle;

        private readonly IConfiguration _conf;

        public SRDataRepository(ISRDataService service, IConfiguration conf)
        {
            _service = service;
            _conf = conf;
            Init();
        }

        private void Init()
        {
            _handle = _service.SRData.Subscribe(i =>
            {
                try
                {
                    Logger.Debug("SRDataRepository - SaveToDB()");
                    SaveToDB(i);
                }
                catch (Exception err)
                {
                    OnError(err);
                }
            },
                e => OnError(e),
                () => OnCompleted());
        }

        private void SaveToDB(SRDataService sr)
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

        public void OnCompleted()
        {
            Logger.Info("[SRDataRepository] [OnCompleted]");
        }

        public void OnError(Exception error)
        {
            Logger.ErrorFormat("[SRDataRepository] [OnError] error: {0}", error);
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
                if (_handle != null)
                {
                    _handle.Dispose();
                    Logger.Debug("_handle - Dispose()");
                }
            }

            _disposed = true;
        }
    }
}
