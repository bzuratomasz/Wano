using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WanoControlCenter.Configuration;
using WanoControlCenter.Model;
using WanoControlCenter.Presenter;
using WanoControlCenter.View.Interfaces;

namespace WanoControlCenter.View
{
    /// <summary>
    /// Interaction logic for LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ConfigurationContainer.Instance.Pass == passTextb.Password && ConfigurationContainer.Instance.User == userTextb.Text)
            {
                WCCConfiguration conf = new WCCConfiguration();
                conf.Show();
                var myWindow = Window.GetWindow(this);
                myWindow.Close();
            }
            else
            {
                buttonLog.Background = Brushes.Red;
            }
        }
    }
}
