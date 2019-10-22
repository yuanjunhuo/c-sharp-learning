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

namespace 简单计算器设计练习
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            textthree.IsReadOnly = true;
            
        }

       



            
        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            int number1, number2;


            bool flag1 = int.TryParse(textone.Text , out number1);
            bool flag2 = int.TryParse(texttwo.Text , out number2);

            if(!flag1)
            {
                textone.Text = "?";
            }
            if (!flag2)
            {
                texttwo.Text = "?";
            }


      if(flag1&&flag2)
            {
                if (add.IsChecked == true)
                {
                  
                    textthree.Text = (number1 + number2).ToString();
                }
                if (sub.IsChecked == true)
                {
                   
                    textthree.Text = (number1 - number2).ToString();
                }
                if (che.IsChecked == true)
                {
                   
                    textthree.Text = (number1 * number2).ToString();
                }
                if (chu.IsChecked == true)
                {
                 
                    textthree.Text = (number1 / number2).ToString();
                }
                if (mod.IsChecked == true)
                {
                   
                    textthree.Text = (number1 % number2).ToString();
                }

            }
           

        }

        private void Add_Checked(object sender, RoutedEventArgs e)
        {
            textthree.Clear();
            if (add.IsChecked == true)
            {
                hjyone.Content = "加法";
                hjytwo.Content = "+";
             
            }
            if (sub.IsChecked == true)
            {
                hjyone.Content = "减法";
                hjytwo.Content = "-";
            
            }
            if (che.IsChecked == true)
            {
                hjyone.Content = "乘法";
                hjytwo.Content = "*";
             
            }
            if (chu.IsChecked == true)
            {
                hjyone.Content = "除法";
                hjytwo.Content = "/";
             
            }
            if (mod.IsChecked == true)
            {
                hjyone.Content = "取模";
                hjytwo.Content = "%";
            
            }
        }
    }
}
