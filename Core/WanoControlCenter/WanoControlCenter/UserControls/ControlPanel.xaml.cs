using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WanoControlCenter.Presenters;
using WanoControlContracts.DataContracts.RegisterCard;
using WanoControlCenter.Views;
using System.Windows.Input;
using WanoControlCenter.Controls;
using Newtonsoft.Json;
using WCCCommon.Models;
using WanoControlCenter.Interfaces.Presenters;

namespace WanoControlCenter.UserControls
{
    /// <summary>
    /// Interaction logic for ControlPanel.xaml
    /// </summary>
    public partial class ControlPanel : UserControl, IControlPanelPresenter, IDisposable
    {

        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private IDisposable _handle;
        private List<RequestRegisterCard> _cards = new List<RequestRegisterCard>();
        private bool _showed = false;
        private List<ListBoxItemCustom> _buffer;

        public ControlPanelPresenter _presenter { get; set; }

        public ControlPanel()
        {
            InitializeComponent();

            RegisterAndSubscribe();

            InitList();
        }

        private void RegisterAndSubscribe()
        {
            _presenter = new ControlPanelPresenter(new Models.ServiceModel(), new Models.ControlPanelUiModel(), this);
            _handle = _presenter.GetManageCards().ManageCard.Subscribe(i => InitList());
        }

        public async void InitList()
        {
            try
            {
                CardsList.Items.Clear();

                await Task.Run(() =>
                {
                    _cards = _presenter.GetCards();

                    Dispatcher.Invoke(() =>
                    {
                        BindList();
                    });
                });
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("Error while getting CardList(). Error text: {0}", ex);
            }
        }

        private void BindList()
        {
            foreach (var item in _cards)
            {
                ListBoxItemCustom control = new ListBoxItemCustom()
                {
                    ToolTip = string.Format(Properties.Resources.ListBoxItemCustomToolTip, item.StartTime, item.EndTime, item.Deleted),
                    Content = string.Format(Properties.Resources.cardIdTemplate, item.CardId),
                    cardId = item.CardId,
                    Stats = item.Permissions == null ? null : JsonConvert.DeserializeObject<List<List<Status>>>(item.Permissions)
                };
                CardsList.Items.Add(control);
            }

            _buffer = CardsList.Items.Cast<ListBoxItemCustom>().ToList();

            spin.Visibility = System.Windows.Visibility.Hidden;
        }

        private void cmdOpen_Click(object sender, RoutedEventArgs e)
        {
            Loader conf = new Loader();

            var result = (ListBoxItemCustom)CardsList.SelectedItem;
            ControlPanelEvent(result, false);
            InitList();

            conf.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!_showed)
            {
                _presenter.GetManageCards().Show();
                _showed = true;
            }
            else
            {
                _presenter.GetManageCards().Visibility = System.Windows.Visibility.Visible;
            }
        }

        public void Dispose()
        {
            _handle.Dispose();
        }

        private void SearchTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            var result = _buffer
                .Where(x => SubstringCustom(x))
                .Select(s => s)
                .ToList();

            CardsList.Items.Clear();

            result.ForEach(x => CardsList.Items.Add(x));
        }

        private bool SubstringCustom(ListBoxItem item)
        {
            var curr = string.Format(Properties.Resources.cardIdTemplate, SearchTxt.Text);
            return item.Content.ToString().Contains(curr);
        }

        private void CardsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ControlPanelEvent((ListBoxItemCustom)CardsList.SelectedItem, true);
        }

        #region event

        public delegate void ControlPanelEventDelegate(ListBoxItemCustom item, bool reading);
        public static event ControlPanelEventDelegate ControlPanelEvent;

        public void Write(ListBoxItemCustom item, bool reading)
        {
            if (ControlPanelEvent != null)
                ControlPanelEvent(item, reading);
        }

        #endregion
    }
}
