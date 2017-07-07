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

namespace WanoControlCenter.View
{
    /// <summary>
    /// Interaction logic for WCCSupervisor.xaml
    /// </summary>
    public partial class WCCSupervisor : Window
    {
        private List<GroupBox> _groupBoxes = new List<GroupBox>();

        public WCCSupervisor()
        {
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
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Left
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
                Button current = new Button()
                {
                    Height = 25,
                    Width = 100,
                    Content = string.Format("Door: {0}", i),
                    Background = Brushes.LightGray,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Left
                };

                current.Click += current_Click;

                grid.Children.Add(current);

            }
        }

        void current_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Background == Brushes.Red) 
            {
                ((Button)sender).Background = Brushes.Green;
            }
            else if (((Button)sender).Background == Brushes.Green)
            {
                ((Button)sender).Background = Brushes.LightGray;
            }
            else
            {
                ((Button)sender).Background = Brushes.Red;
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
