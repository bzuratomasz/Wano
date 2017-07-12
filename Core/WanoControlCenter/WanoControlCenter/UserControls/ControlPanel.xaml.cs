using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WanoControlCenter.Presenters;
using WanoControlCenter.Interfaces;
using WanoControlContracts.DataContracts.RegisterCard;
using WanoControlCenter.Views;
using System.Windows.Input;
using WanoControlCenter.Controls;
using Newtonsoft.Json;
using WCCCommon.Models;

namespace WanoControlCenter.UserControls
{
    /// <summary>
    /// Interaction logic for ControlPanel.xaml
    /// </summary>
    public partial class ControlPanel : UserControl, IWCCSupervisorPresenter, IDisposable
    {
        //TODO - Refactor this class!
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private IDisposable _handle;
        private List<RequestRegisterCard> _cards = new List<RequestRegisterCard>();
        private ManageCards _conf = new ManageCards();
        private bool _showed = false;
        private List<ListBoxItemCustom> _buffer;

        public WCCSupervisorPresenter _presenter { get; set; }

        public delegate void ControlPanelEventDelegate(ListBoxItemCustom item, bool reading);
        public static event ControlPanelEventDelegate ControlPanelEvent;

        public void Write(ListBoxItemCustom item, bool reading)
        {
            if (ControlPanelEvent != null)
                ControlPanelEvent(item, reading);
        }

        public ControlPanel()
        {
            InitializeComponent();

            _presenter = new WCCSupervisorPresenter(new Models.WCCModel(), this);
            _handle = _conf.ManageCard.Subscribe(i => InitList());

            try
            {
                InitList();
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("Error while getting CardList(). Error text: {0}", ex);
            }
        }

        public async void InitList()
        {
            CardsList.Items.Clear();

            spin.Visibility = System.Windows.Visibility.Visible;

            await Task.Run(() =>
            {
                _cards = _presenter.GetCards();

                Dispatcher.Invoke(() =>
                {
                    BindList();
                });
            });
        }

        private void BindList()
        {

            foreach (var item in _cards)
            {
                ListBoxItemCustom control = new ListBoxItemCustom()
                {
                    ToolTip = string.Format("Start time: {0}, End time: {1}, Is deleted: {2}",
                    item.StartTime,
                    item.EndTime,
                    item.Deleted),
                    Content = string.Format("CardId: {0}", item.CardId),
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
                _conf.Show();
                _showed = true;
            }
            else
            {
                _conf.Visibility = System.Windows.Visibility.Visible;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private bool SubstringCustom(ListBoxItem x)
        {
            var template = x.Content.ToString();
            var curr = string.Format("CardId: {0}", SearchTxt.Text);
            return template.Contains(curr);
        }

        private void CardsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ControlPanelEvent((ListBoxItemCustom)CardsList.SelectedItem, true);
        }
    }
}
