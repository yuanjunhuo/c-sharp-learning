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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void StartTwoClient(object sender, RoutedEventArgs e)
        {
            LoginForm G1 = new LoginForm()
            {
                Title = "客户端1",
            };
            G1.Owner = this;
            G1.Show();
            LoginForm G2 = new LoginForm()
            {
                Title = "客户端2",
            };
            G2.Owner = this;
            G2.Show();
        }

        private void StartOneClient(object sender, RoutedEventArgs e)
        {
            LoginForm GG = new LoginForm();
            GG.Show();
        }
    }
}
