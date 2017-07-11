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
using WanoControlCenter.Presenter;
using WanoControlCenter.View.Interfaces;
using WanoControlContracts.DataContracts.RegisterCard;

namespace WanoControlCenter.View
{
    /// <summary>
    /// Interaction logic for ManageCards.xaml
    /// </summary>
    public partial class ManageCards : Window, IManageCardsPresenter
    {
        public ManageCardsPresenter _presenter { get; set; }

        public ManageCards()
        {
            InitializeComponent();

            _presenter = new ManageCardsPresenter(new Model.WCCModel(), this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = RegisterCard(new RequestRegisterCard()
            {
                CardId = 1,
                Deleted = false,
                EndTime = DateTime.Now,
                Password = 12345,
                StartTime = DateTime.Now
            });
        }

        private ResponseRegisterCard RegisterCard(RequestRegisterCard card)
        {
            return _presenter.RegisterCard(card);
        }
    }
}
