﻿using log4net;
using System;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WanoControlCenter.Presenters;
using WanoControlContracts.DataContracts.ControllerConfigure;
using WanoControlCenter.Interfaces.Presenters;

namespace WanoControlCenter.Views
{
    /// <summary>
    /// Interaction logic for WCCConfiguration.xaml
    /// </summary>
    public partial class WCCConfiguration : Window, IWCCConfigurationPresenter
    {

        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public WCCConfigurationPresenter _presenter { get; set; }

        public WCCConfiguration()
        {
            InitializeComponent();
            txtNumSN.Text = _numValue.ToString();
            txtNumPort.Text = _numValuePort.ToString();

            _presenter = new WCCConfigurationPresenter(new Models.ServiceModel(), this);
        }

        private int _numValue = 20;

        public int NumValue
        {
            get { return _numValue; }
            set
            {
                _numValue = value;
                txtNumSN.Text = value.ToString();
            }
        }

        private void cmdUpSN_Click(object sender, RoutedEventArgs e)
        {
            NumValue++;
        }

        private void cmdDownSN_Click(object sender, RoutedEventArgs e)
        {
            NumValue--;
        }

        private void txtNumSN_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNumSN == null)
            {
                return;
            }

            if (!int.TryParse(txtNumSN.Text, out _numValue))
                txtNumSN.Text = _numValue.ToString();
        }

        #region port

        private int _numValuePort = 6001;

        public int NumValuePort
        {
            get { return _numValuePort; }
            set
            {
                _numValuePort = value;
                txtNumPort.Text = value.ToString();
            }
        }

        private void cmdUpPort_Click(object sender, RoutedEventArgs e)
        {
            NumValuePort++;
        }

        private void cmdDownPort_Click(object sender, RoutedEventArgs e)
        {
            NumValuePort--;
        }

        private void txtNumPort_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNumPort == null)
            {
                return;
            }

            if (!int.TryParse(txtNumPort.Text, out _numValuePort))
                txtNumPort.Text = _numValuePort.ToString();
        }

        #endregion

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var register = PrepareData();

            await Task.Run(() =>
            {
                try
                {
                    if (Validate())
                    {
                        _presenter.Register(register);
                    }
                }
                catch (Exception ex)
                {
                    Logger.ErrorFormat("Error while saving Controller Configuration. Error message: {0}", ex);
                }
            });

            OpenNextWindow();
        }

        /// <summary>
        /// Prepare data to send via net to controller
        /// </summary>
        /// <returns></returns>
        private RequestControllerConfigure PrepareData()
        {
            var register = new RequestControllerConfigure()
            {
                Ip = IPAddress.Parse(ipTextBox.Text),
                Port = _numValuePort,
                Mask = IPAddress.Parse(maskTextBox.Text),
                Gateway = IPAddress.Parse(gatewayTextBox.Text),
                HolidayControl = _numValue,
                PcIPAddr = pcIpTextBox.Text
            };
            return register;
        }

        private void OpenNextWindow()
        {
            WCCSupervisor conf = new WCCSupervisor();
            conf.Show();
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }

        private bool Validate()
        {
            //TODO Validate Input's
            return true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
