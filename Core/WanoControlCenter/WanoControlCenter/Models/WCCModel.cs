using log4net;
using System.Reflection;
using WanoControlCenter.Configuration;
using System.ServiceModel;
using WanoControlContracts.ServiceContracts.RegisterCard;
using WanoControlContracts.DataContracts.RegisterCard;
using WanoControlContracts.ServiceContracts;
using WanoControlContracts.DataContracts.ControllerConfigure;
using WanoControlContracts.ServiceContracts.ControllerConfigure;
using System.Collections.Generic;

namespace WanoControlCenter.Models
{
    public class WCCModel
    {

        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly BasicHttpBinding _myBinding = new BasicHttpBinding();
        private readonly EndpointAddress _myEndpoint = new EndpointAddress(ConfigurationContainer.Instance.Url);
        private readonly ChannelFactory<IWanoService> myChannelFactory;

        public WCCModel()
        {
            myChannelFactory = new ChannelFactory<IWanoService>(_myBinding, _myEndpoint);
        }

        public ResponseRegisterCard RegisterCard(RequestRegisterCard card)
        {
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

        public void Register(RequestControllerConfigure controller) 
        {
            IControllerConfigure client = null;

            try
            {
                client = myChannelFactory.CreateChannel();
                client.ConnectToController(controller);
                ((ICommunicationObject)client).Close();
            }
            catch
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
            }
        }

        public List<RequestRegisterCard> GetCards()
        {
            List<RequestRegisterCard> result = new List<RequestRegisterCard>();
            IRegisterCard client = null;

            try
            {
                client = myChannelFactory.CreateChannel();
                result = client.GetCards();
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
    }
}
