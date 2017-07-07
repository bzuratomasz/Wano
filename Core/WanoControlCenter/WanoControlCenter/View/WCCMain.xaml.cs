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
using WanoControlCenter.Presenter;
using WanoControlCenter.View.Interfaces;
using WanoControlContracts.DataContracts.RegisterCard;

namespace WanoControlCenter.View
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
            _presenter = new WCCMainPresenter(new Model.WCCModel(), this);
            //TEST
            var result = RegisterCard(new RequestRegisterCard()
            {
                CardId = 1,
                Deleted = false,
                EndTime = DateTime.Now,
                Password = "",
                StartTime = DateTime.Now
            });
        }

        public ResponseRegisterCard RegisterCard(RequestRegisterCard card) 
        {
            return _presenter.RegisterCard(card);
        }
    }
}
