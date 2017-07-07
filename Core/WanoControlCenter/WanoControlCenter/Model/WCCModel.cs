using log4net;
using System.Reflection;
using WanoControlCenter.Configuration;
using System.ServiceModel;
using WanoControlContracts.ServiceContracts.RegisterCard;
using WanoControlContracts.DataContracts.RegisterCard;

namespace WanoControlCenter.Model
{
    public class WCCModel
    {

        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public WCCModel()
        {

        }

        public ResponseRegisterCard RegisterCard(RequestRegisterCard card)
        {
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress(ConfigurationContainer.Instance.Url);
            var myChannelFactory = new ChannelFactory<IRegisterCard>(myBinding, myEndpoint);
            ResponseRegisterCard result = new ResponseRegisterCard();

            IRegisterCard client = null;

            try
            {
                client = myChannelFactory.CreateChannel();
                result = client.RegisterCard(card);
                ((ICommunicationObject)client).Close();
            }
            catch
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
            }

            return result;
        }

        public void Register() 
        {

        }
    }
}
