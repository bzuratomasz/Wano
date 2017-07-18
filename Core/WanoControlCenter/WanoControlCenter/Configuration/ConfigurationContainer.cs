using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WanoControlCenter.Configuration.Interfaces;

namespace WanoControlCenter.Configuration
{
    public class ConfigurationContainer : IConfiguration
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static ConfigurationContainer _instance;

        public static ConfigurationContainer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConfigurationContainer();
                }
                return _instance;
            }
        }

        public string User { get; private set; }
        public string Pass { get; private set; }
        public Dictionary<int, int> Specification { get; set; }
        public string Url { get; private set; }
        public int GBoxH { get; private set; }
        public int GBoxW { get; private set; }
        public int ButH { get; private set; }
        public int ButW { get; private set; }

        public ConfigurationContainer()
        {
            try
            {
                Initialize();
            }
            catch (Exception)
            {
                throw new Exception("Error while reading configuration! Please check *.config file.");
            }
        }

        private void Initialize()
        {
            User = ConfigurationManager.AppSettings["login"];
            Pass = ConfigurationManager.AppSettings["pass"];
            Specification = LoadSpecification(ConfigurationManager.AppSettings["Wano.SerializedLevels"]);
            Url = ConfigurationManager.AppSettings["Url"];

            var gBoxH = ConfigurationManager.AppSettings["GBoxH"];
            if (gBoxH != null)
            {
                GBoxH = int.Parse(gBoxH);
            }

            var gBoxW = ConfigurationManager.AppSettings["GBoxW"];
            if (gBoxW != null)
            {
                GBoxW = int.Parse(gBoxW);
            }

            var butH = ConfigurationManager.AppSettings["ButH"];
            if (butH != null)
            {
                ButH = int.Parse(butH);
            }

            var butW = ConfigurationManager.AppSettings["ButW"];
            if (butW != null)
            {
                ButW = int.Parse(butW);
            }
        }


        public Dictionary<int, int> LoadSpecification(string serializedStateDescriptions)
        {
            var specifications = new Dictionary<int, int>();

            try
            {
                IEnumerable<object> deserialized = (IEnumerable<object>)JsonConvert.DeserializeObject(serializedStateDescriptions);

                foreach (dynamic kv in deserialized)
                {
                    var key = int.Parse(kv.Name);
                    var value = int.Parse(string.Format("{0}", kv.Value));
                    specifications.Add(key, value);
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("Failed to deserialize state description mappings: {0}", ex);
            }

            return specifications;
        }
    }
}
