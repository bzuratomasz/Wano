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
using System.Windows.Shapes;
using WanoControlCenter.Configuration;
using WanoControlCenter.Presenters;
using WanoControlCenter.Interfaces;
using WanoControlContracts.DataContracts.RegisterCard;

namespace WanoControlCenter.Views
{
    /// <summary>
    /// Interaction logic for WCCMain.xaml
    /// </summary>
    public partial class WCCMain : Window, IWCCMainPresenter
    {
        public WCCMainPresenter _presenter { get; set; }

        public WCCMain()
        {
            InitializeComponent();
            _presenter = new WCCMainPresenter(new Models.WCCModel(), this);
        }
    }
}
