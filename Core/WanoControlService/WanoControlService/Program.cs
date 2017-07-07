using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WanoControlService.Bootstrappers;
using WanoControlService.Hosters;

namespace WanoControlService
{
    public class Program
    {
        #region Nested classes to support running as service
        public const string ServiceName = "WanoControlService";

        public class Service : ServiceBase
        {
            public Service()
            {
                ServiceName = Program.ServiceName;
            }

            protected override void OnStart(string[] args)
            {
                Program.Start(args);
            }

            protected override void OnStop()
            {
                Program.Stop();
            }
        }
        #endregion

        private static ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            if (!Environment.UserInteractive)
                using (var service = new Service())
                    ServiceBase.Run(service);
            else
            {
                Start(args);

                Console.WriteLine("Press any key to stop...");
                Console.ReadKey(true);

                Stop();
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            string msg = string.Format("[WanoControlService] Unhandled exception: {0}, StackTrace: {1}", ex.Message, ex.StackTrace);
            System.Diagnostics.Trace.WriteLine(msg);
            Logger.Fatal(msg);
        }

        private static void Start(string[] args)
        {
            ServiceBootstrapper _bootstrapper = new ServiceBootstrapper();
            
            //Initialize hosting
            _bootstrapper.Start();
        }

        private static void Stop()
        {
            //onstop code here
        }
    }
}
