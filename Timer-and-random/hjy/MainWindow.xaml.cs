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
using System.Windows.Threading;

namespace hjy
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {



        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();

            int number1;
            bool flag= int.TryParse (third.Text ,out number1 );


            timer.Interval = TimeSpan.FromMilliseconds(number1);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int number2 = int.Parse(first.Text);
            int number3 = int.Parse(second.Text);
            if(intnumber .IsChecked ==true)
            {
                int aaa = RandomHelp.getIntRandomNumber(number2, number3);
                comeout.Content = aaa.ToString();
            }
            else if(doublenumber.IsChecked == true)
            {
                double sss = RandomHelp.getDoubleRandomNumber(number2, number3);
                comeout.Content = sss.ToString();
            }
           
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            comeout.FontSize = 20;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            if(comeout.FontSize <25)
            {
                comeout.FontSize += 5;
            }
          
        }
    }
}
