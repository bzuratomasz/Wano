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
using System.Windows.Threading;

namespace WanoControlCenter.View
{
    /// <summary>
    /// Interaction logic for Loader.xaml
    /// </summary>
    public partial class Loader : Window
    {
        public Loader()
        {
            InitializeComponent();
            GenerateAnimation();
        }

        private void GenerateAnimation()
        {
            var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(100) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                progressBar.Value = progressBar.Value + 10;
                if (progressBar.Value == 100) 
                {
                    var myWindow = Window.GetWindow(this);
                    myWindow.Close();
                }
                else 
                {
                    timer.Start();
                }
            };
        }
    }
}
