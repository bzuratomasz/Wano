using System.Windows;
using WanoControlCenter.Presenters;
using WanoControlCenter.Interfaces.Presenters;

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
            _presenter = new WCCMainPresenter(new Models.ServiceModel(), this);
        }
    }
}
