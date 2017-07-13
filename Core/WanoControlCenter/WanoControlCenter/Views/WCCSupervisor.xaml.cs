using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using WanoControlCenter.Configuration;
using WanoControlCenter.Presenters;
using WanoControlCenter.Controls;
using WanoControlCenter.UserControls;
using System.ComponentModel;
using WCCCommon.Models;
using WanoControlCenter.Models.Schemas;
using WanoControlCenter.Interfaces.Presenters;
using System;

namespace WanoControlCenter.Views
{
    /// <summary>
    /// Interaction logic for WCCSupervisor.xaml
    /// </summary>
    public partial class WCCSupervisor : Window, IWCCSupervisorPresenter
    {

        public WCCSupervisorPresenter _presenter { get; set; }

        //Default values - can be override by configuration;
        private int _gBoxH = 950;
        private int _gBoxW = 150;
        private int _butH = 25;
        private int _butW = 100;

        public WCCSupervisor()
        {
            _presenter = new WCCSupervisorPresenter(new Models.ServiceModel(), new Models.SupervisorUiModel(), this);

            InitializeComponent();
            ReadConfiguration();

            ControlPanel.ControlPanelEvent += ControlPanel_ControlPanelEvent;
        }

        private void ReadConfiguration()
        {
            var result = ConfigurationContainer.Instance.Specification;

            _gBoxH = ConfigurationContainer.Instance.GBoxH;
            _gBoxW = ConfigurationContainer.Instance.GBoxW;
            _butH = ConfigurationContainer.Instance.ButH;
            _butW = ConfigurationContainer.Instance.ButW;

            CreateGroupBox(result.Count);
            InsertButtonsIntoGroupBox(result);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        private void InsertButtonsIntoGroupBox(Dictionary<int, int> result)
        {
            int i = 0;

            foreach (var groupBox in _presenter.GetGroupBoxes())
            {
                DockPanelCustom grid = new DockPanelCustom()
                {
                    Width = _gBoxW - 50,
                    Height = _gBoxH - 100,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                    Name = string.Format(Properties.Resources.DockPanelCustomName, i),
                    IdNumber = i
                };

                AddButtons(result[i], grid);

                groupBox.Content = grid;
                i++;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="grid"></param>
        private void AddButtons(int p, DockPanelCustom grid)
        {

            for (int i = 0; i < p; i++)
            {
                ButtonCustom current = new ButtonCustom()
                {
                    Height = _butH,
                    Width = _butW,
                    Content = string.Format(Properties.Resources.CustomBtnContent, i),
                    Background = Brushes.LightGray,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                    Name = string.Format(Properties.Resources.CustomBtnName, i),
                    IdNumber = i
                };

                current.Click += current_Click;

                _presenter.AddToContext(new ControlEntity()
                {
                    customButton = current,
                    dockPanel = grid
                });

                grid.Children.Add(current);

            }
        }

        void current_Click(object sender, RoutedEventArgs e)
        {
            var instance = _presenter.GetContext().Where(x => x.customButton == ((ButtonCustom)sender)).SingleOrDefault();

            if (((ButtonCustom)sender).Background == Brushes.Red)
            {
                ((ButtonCustom)sender).Background = Brushes.Green;
                ((ButtonCustom)sender).Status = Status.Set;
                instance.customButton.Status = Status.Set;
            }
            else if (((ButtonCustom)sender).Background == Brushes.Green)
            {
                ((ButtonCustom)sender).Background = Brushes.LightGray;
                ((ButtonCustom)sender).Status = Status.Blank;
                instance.customButton.Status = Status.Blank;
            }
            else
            {
                ((ButtonCustom)sender).Background = Brushes.Red;
                ((ButtonCustom)sender).Status = Status.Clear;
                instance.customButton.Status = Status.Clear;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        private void CreateGroupBox(int groupBoxesCount)
        {
            for (int i = 0; i < groupBoxesCount; i++)
            {
                var idString = string.Format(Properties.Resources.LevelDesc, i);
                GroupBox groupBox = new GroupBox
                {
                    Width = _gBoxW,
                    Height = _gBoxH,
                    Header = idString
                };

                _presenter.AddGroupBox(groupBox);
                mainStackPanel.Children.Add(groupBox);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            ControlPanel.ControlPanelEvent -= ControlPanel_ControlPanelEvent;
            base.OnClosing(e);
        }

        /// <summary>
        /// Event from ControlPanel
        /// </summary>
        /// <param name="item"></param>
        void ControlPanel_ControlPanelEvent(ListBoxItemCustom item, bool reading)
        {
            if (reading)
            {
                ControlPanelReading(item);
            }
            else
            {
                ControlPanelUpdate(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void ControlPanelUpdate(ListBoxItemCustom item)
        {
            //TODO - compare these two lists produce new one!
            List<List<Status>> permissions = new List<List<Status>>();

            var groupBoxes = _presenter.GetContext().Select(w => w.dockPanel).Distinct();

            foreach (var items in groupBoxes)
            {
                var buttons = _presenter.GetContext().Where(x => x.dockPanel == items).Select(s => s.customButton);
                permissions.Add(buttons.Select(x => x.Status).ToList());
            }

            _presenter.UpdateCardsPermissions(GenerateFinalResult(permissions, item.Stats), item.cardId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newList"></param>
        /// <param name="oldList"></param>
        /// <returns></returns>
        private List<List<Status>> GenerateFinalResult(List<List<Status>> newList, List<List<Status>> oldList)
        {
            List<List<Status>> result = new List<List<Status>>();

            foreach (var lines in newList.Zip(oldList, Tuple.Create))
            {
                List<Status> singleRow = new List<Status>();

                foreach (var stats in lines.Item1.Zip(lines.Item2, Tuple.Create))
                {
                    if (stats.Item1 == Status.Blank && stats.Item2 != Status.Blank)
                    {
                        singleRow.Add(stats.Item2);
                    }
                    else
                    {
                        singleRow.Add(stats.Item1);
                    }
                }

                result.Add(singleRow);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void ControlPanelReading(ListBoxItemCustom item)
        {
            var rowIndex = 0;
            var columnIndex = 0;

            if (item.Stats != null)
            {
                foreach (var buttonCollections in item.Stats)
                {
                    var groupBox = _presenter.GetContext()
                        .Where(x => x.dockPanel.IdNumber == rowIndex)
                        .Select(s => s.customButton);

                    foreach (Status button in buttonCollections)
                    {
                        SetBackgroundColor(columnIndex, groupBox, button);
                        columnIndex++;
                    }
                    columnIndex = 0;
                    rowIndex++;
                }
            }
            else
            {
                _presenter.ClearButtonsBackground();
            }
        }

        /// <summary>
        /// Set Background Color
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <param name="groupBox"></param>
        /// <param name="button"></param>
        private static void SetBackgroundColor(int columnIndex, IEnumerable<ButtonCustom> groupBox, Status button)
        {
            ButtonCustom cur = groupBox
                .Where(x => x.IdNumber == columnIndex).
                SingleOrDefault();

            if (cur != null)
            {
                if (button == Status.Blank)
                {
                    cur.Background = Brushes.LightGray;
                }
                else if (button == Status.Set)
                {
                    cur.Background = Brushes.Green;
                }
                else
                {
                    cur.Background = Brushes.Red;
                }
            }
        }
    }
}
