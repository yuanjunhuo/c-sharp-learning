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
using mywcf.ServiceReference1;
namespace mywcf
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
        //1812050006-霍俊园
        //启动应用程序简单实现
        private void Startbtn_Click(object sender, RoutedEventArgs e)
        {
            if(txt.Text =="")
            {
                MessageBox.Show("请输入要启动的程序名！！！！");

            }
            else
            {
                Service1Client hjy = new Service1Client();
                bool flag = hjy.OpenNotepade(this.txt.Text );
                if(flag)
                {
                    this.labeltxt.Content = "启动成功！！！！！！";
                }
                else
                {
                    this.labeltxt.Content = "启动失败！！！！！！";
                }
            }
        }
    }
}
