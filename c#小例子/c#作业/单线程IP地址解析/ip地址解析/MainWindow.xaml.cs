using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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

namespace ip地址解析
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
        public string ipparse(string ip)
        {
            string attr = "";
            try
            {
                IPHostEntry ipone = Dns.GetHostEntry(ip);
                attr = "主机DNS名称：" + ipone.HostName;
            }
            catch (Exception ex)
            {
                attr = "主机DNS名称：(不存在)";
            }
            return attr;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listone.Items.Clear();
            int start = int.Parse(ipstart.Text);
            int end = int.Parse(ipend.Text);
            if (start > end)
            {
                textone.Text = "起始值有问题！！！";
            }
            else
            {
                for (int i = start; i < end + 1; i++)
                {
                    string attrip = iphead.Text + i.ToString();
                    try
                    {
                        IPAddress ipip = IPAddress.Parse(attrip);
                        Stopwatch time = new Stopwatch();
                        time.Start();
                        string answer = ipparse(attrip);
                        time.Stop();
                        listone.Items.Add("扫描地址：" + attrip + ",扫描用时：" + time.ElapsedMilliseconds + ", " + answer);
                        textone.Text = "解析完成！！！.";
                    }
                    catch
                    {
                        textone.Text = "ip地址有错，请更正！！！";
                    }
                }
            }
        }
    }
}
