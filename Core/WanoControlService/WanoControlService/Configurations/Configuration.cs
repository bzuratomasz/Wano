using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WCCInfrastructure.Configuration;

namespace WanoControlService.Configurations
{
    public class Configuration : IConfiguration
    {
        #region Logger

        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        public string Url
        {
            get;
            private set;
        }

        public int Timer
        {
            get;
            private set;
        }

        public string ConnectionString
        {
            get;
            set;
        }

        public Configuration()
        {
            LoadApplicationConfiguration();
        }

        private void LoadApplicationConfiguration()
        {
            Logger.Info("Configuration start reading app.config...");

            var url = ConfigurationManager.AppSettings["Url"];

            if (string.IsNullOrEmpty(url))
            {
                throw new ConfigurationErrorsException("Url in app.config is not set");
            }

            Url = url;

            var connection = ConfigurationManager.ConnectionStrings["DBConnectionString"];

            if (connection == null)
            {
                throw new ConfigurationErrorsException("ConnectionString in app.config is not set");
            }

            ConnectionString = connection.ConnectionString;

            var timer = ConfigurationManager.AppSettings["Timer"];

            if (timer == null)
            {
                throw new ConfigurationErrorsException("Timer in app.config is not set");
            }

            Timer = int.Parse(timer);
        }

    }
}
