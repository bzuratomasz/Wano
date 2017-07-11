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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = new RequestRegisterCard()
            {
                CardId = int.Parse(cardIdTxtBox.Text),
                Deleted = TrueCB.IsChecked == true ? true : false,
                EndTime = (DateTime)EndDate.SelectedDate,
                Password = int.Parse(PasswordBox.Password.ToString()),
                StartTime = (DateTime)StartDate.SelectedDate
            };

            await Task.Run(() =>
            {
                RegisterCard(result);
            });


            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }

        private ResponseRegisterCard RegisterCard(RequestRegisterCard card)
        {
            return _presenter.RegisterCard(card);
        }
    }
}
