using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using WanoControlCenter.Presenter;
using WanoControlCenter.View.Interfaces;
using WanoControlContracts.DataContracts.RegisterCard;

namespace WanoControlCenter.View.UserControls
{
    /// <summary>
    /// Interaction logic for ControlPanel.xaml
    /// </summary>
    public partial class ControlPanel : UserControl, IWCCSupervisorPresenter
    {

        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private List<RequestRegisterCard> _cards = new List<RequestRegisterCard>();
        public WCCSupervisorPresenter _presenter { get; set; }

        public ControlPanel()
        {
            InitializeComponent();

            _presenter = new WCCSupervisorPresenter(new Model.WCCModel(), this);
            try
            {
                InitList();
            }
            catch (Exception ex) 
            {
                Logger.ErrorFormat("Error while getting CardList(). Error text: {0}", ex);
            }
        }

        public void InitList()
        {
            _cards = _presenter.GetCards();

            BindList();
        }

        private void BindList()
        {
            CardsList.Items.Clear();

            foreach (var item in _cards) 
            {
                CardsList.Items.Add(string.Format("CardId: {0}, EndTime: {1}", item.CardId, item.EndTime));
            }
        }

        private void cmdOpen_Click(object sender, RoutedEventArgs e)
        {
            Loader conf = new Loader();
            conf.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ManageCards conf = new ManageCards();
            conf.Show();
        }
    }
}
