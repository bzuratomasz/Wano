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
using WanoControlCenter.Controls;
using WanoControlCenter.UserControls;
using System.ComponentModel;
using System.Text.RegularExpressions;
using WanoControlCenter.Models;
using WCCCommon.Models;

namespace WanoControlCenter.Views
{
    /// <summary>
    /// Interaction logic for WCCSupervisor.xaml
    /// </summary>
    public partial class WCCSupervisor : Window, IWCCSupervisorPresenter
    {
        //TODO - Refactor this class!
        private List<GroupBox> _groupBoxes = new List<GroupBox>();
        private List<WCCSupervisorModel> _context = new List<WCCSupervisorModel>();

        public WCCSupervisorPresenter _presenter { get; set; }

        public WCCSupervisor()
        {
            _presenter = new WCCSupervisorPresenter(new Models.WCCModel(), this);

            InitializeComponent();
            ReadConfiguration();

            ControlPanel.ControlPanelEvent += ControlPanel_ControlPanelEvent;
        }

        private void ReadConfiguration() 
        {
            var result = ConfigurationContainer.Instance.Specification;

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

            foreach (var groupBox in _groupBoxes) 
            {
                DockPanel grid = new DockPanel()
                {
                    Width = 900,
                    Height = 50,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                    Name = string.Format("DockPanel{0}", i)
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
        private void AddButtons(int p, DockPanel grid)
        {

            for (int i = 0; i < p; i++)
            {
                CustomButton current = new CustomButton()
                {
                    Height = 25,
                    Width = 100,
                    Content = string.Format("Door: {0}", i),
                    Background = Brushes.LightGray,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                    Name = string.Format("Button{0}", i)
                };

                current.Click += current_Click;

                _context.Add(new WCCSupervisorModel() 
                {
                    customButton = current,
                    dockPanel = grid
                });

                grid.Children.Add(current);

            }
        }

        void current_Click(object sender, RoutedEventArgs e)
        {
            var instance = _context.Where(x => x.customButton == ((CustomButton)sender)).SingleOrDefault();

            if (((CustomButton)sender).Background == Brushes.Red) 
            {
                ((CustomButton)sender).Background = Brushes.Green;
                ((CustomButton)sender).Status = Status.Set;
                instance.customButton.Status = Status.Set;
            }
            else if (((CustomButton)sender).Background == Brushes.Green)
            {
                ((CustomButton)sender).Background = Brushes.LightGray;
                ((CustomButton)sender).Status = Status.Blank;
                instance.customButton.Status = Status.Blank;
            }
            else
            {
                ((CustomButton)sender).Background = Brushes.Red;
                ((CustomButton)sender).Status = Status.Clear;
                instance.customButton.Status = Status.Clear;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        private void CreateGroupBox(int p)
        {
            for (int i = 0; i < p; i++)
            {
                var idString = string.Format("Level:{0}", i);
                GroupBox groupBox = new GroupBox
                {
                    Width = 950,
                    Height = 150,
                    Header = idString
                };

                _groupBoxes.Add(groupBox);

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
             List<List<Status>> permissions = new List<List<Status>>();
             var groupBoxes = _context.Select(w => w.dockPanel).Distinct();

             foreach (var items in groupBoxes)
             {
                 var buttons = _context.Where(x => x.dockPanel == items).Select(s => s.customButton);
                 permissions.Add(buttons.Select(x => x.Status).ToList());
             }

             _presenter.UpdateCardsPermissions(permissions, item.cardId);
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
                    var groupBox = _context
                        .Where(x => x.dockPanel.Name == string.Format("DockPanel{0}", rowIndex))
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
                ClearButtonsBackground();
            }
        }

        private void ClearButtonsBackground()
        {
            var result = _context.Select(x => x.customButton);
            foreach (var item in result)
            {
                ((CustomButton)item).Background = Brushes.LightGray;
                ((CustomButton)item).Status = Status.Blank;
            }
        }

        /// <summary>
        /// Set Background Color
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <param name="groupBox"></param>
        /// <param name="button"></param>
        private static void SetBackgroundColor(int columnIndex, IEnumerable<CustomButton> groupBox, Status button)
        {
            CustomButton cur = groupBox
                .Where(x => x.Name == string.Format("Button{0}", columnIndex)).
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
