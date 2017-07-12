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

namespace WanoControlCenter.Views
{
    /// <summary>
    /// Interaction logic for WCCSupervisor.xaml
    /// </summary>
    public partial class WCCSupervisor : Window, IWCCSupervisorPresenter
    {

        private List<GroupBox> _groupBoxes = new List<GroupBox>();

        public WCCSupervisorPresenter _presenter { get; set; }

        public WCCSupervisor()
        {
            _presenter = new WCCSupervisorPresenter(new Models.WCCModel(), this);

            InitializeComponent();
            ReadConfiguration();
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

                grid.Children.Add(current);

            }
        }

        void current_Click(object sender, RoutedEventArgs e)
        {
            if (((CustomButton)sender).Background == Brushes.Red) 
            {
                ((CustomButton)sender).Background = Brushes.Green;
                ((CustomButton)sender).Status = 1;
            }
            else if (((CustomButton)sender).Background == Brushes.Green)
            {
                ((CustomButton)sender).Background = Brushes.LightGray;
                ((CustomButton)sender).Status = 0;
            }
            else
            {
                ((CustomButton)sender).Background = Brushes.Red;
                ((CustomButton)sender).Status = 2;
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
    }
}
