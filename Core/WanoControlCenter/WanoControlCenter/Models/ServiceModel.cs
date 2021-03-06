﻿using log4net;
using System.Reflection;
using WanoControlCenter.Configuration;
using System.ServiceModel;
using WanoControlContracts.ServiceContracts.RegisterCard;
using WanoControlContracts.DataContracts.RegisterCard;
using WanoControlContracts.ServiceContracts;
using WanoControlContracts.DataContracts.ControllerConfigure;
using WanoControlContracts.ServiceContracts.ControllerConfigure;
using System.Collections.Generic;
using WCCCommon.Models;
using WanoControlCenter.Interfaces.Models;
using System;

namespace WanoControlCenter.Models
{
    public class ServiceModel : IServiceModel
    {

        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly BasicHttpBinding _myBinding = new BasicHttpBinding();
        private readonly EndpointAddress _myEndpoint;
        private readonly ChannelFactory<IWanoService> myChannelFactory;
        private IRegisterCard _RegisterCardClient = null;

        public ServiceModel()
        {
            var endPoint = ConfigurationContainer.Instance.Url;

            if (endPoint != null)
            {
                _myEndpoint = new EndpointAddress(ConfigurationContainer.Instance.Url);
                myChannelFactory = new ChannelFactory<IWanoService>(_myBinding, _myEndpoint);
            }
        }

        public ResponseRegisterCard RegisterCard(RequestRegisterCard card)
        {
            ResponseRegisterCard result = new ResponseRegisterCard() { Registered = true };

            if (card.CardId > 0)
            {
                try
                {
                    if (myChannelFactory != null)
                    {
                        _RegisterCardClient = myChannelFactory.CreateChannel();
                        result = _RegisterCardClient.RegisterCard(card);
                        ((ICommunicationObject)_RegisterCardClient).Close();
                    }
                }
                catch
                {
                    if (_RegisterCardClient != null)
                    {
                        ((ICommunicationObject)_RegisterCardClient).Abort();
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("Empty argument! Declare - RequestRegisterCard");
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

            try
            {
                _RegisterCardClient = myChannelFactory.CreateChannel();
                result = _RegisterCardClient.GetCards();
                ((ICommunicationObject)_RegisterCardClient).Close();
            }
            catch
            {
                if (_RegisterCardClient != null)
                {
                    ((ICommunicationObject)_RegisterCardClient).Abort();
                }
            }

            return result;
        }

        public bool UpdateCardsPermissions(List<List<Status>> permissions, int cardId)
        {
            bool result = false;

            if (cardId > 0 && permissions != null && permissions.Count > 0)
            {
                try
                {
                    if (myChannelFactory != null)
                    {
                        _RegisterCardClient = myChannelFactory.CreateChannel();
                        result = _RegisterCardClient.UpdateCardsPermissions(permissions, cardId);
                        ((ICommunicationObject)_RegisterCardClient).Close();
                    }
                }
                catch
                {
                    if (_RegisterCardClient != null)
                    {
                        ((ICommunicationObject)_RegisterCardClient).Abort();
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("Empty argument! Declare - cardId");
            }

            return result;
        }

        public ResponseControllerConfigure GetController()
        {

            ResponseControllerConfigure result = new ResponseControllerConfigure();

            IControllerConfigure client = null;

            try
            {
                client = myChannelFactory.CreateChannel();
                result = client.GetController();
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
