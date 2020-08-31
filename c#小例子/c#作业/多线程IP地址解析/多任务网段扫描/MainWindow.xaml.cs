using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

namespace A._2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            begin.Click += Begin_Click;
        }

        IPAddress IpStart, IpEnd;

        private void Begin_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
            string input1 = textBox1.Text;
            string input2 = textBox2.Text;
            string input3 = textBox3.Text;
            int int_input2 = int.Parse(input2);
            int int_input3 = int.Parse(input3);
            int count = 0;
            int k = input1.Length;

            if (!input1[k - 1].Equals('.'))
            {
                input1 += ".";
            }

            if (IPAddress.TryParse(input1 + input2, out IpStart) && IPAddress.TryParse(input1 + input3, out IpEnd) && (int_input2 <= int_input3))
            {
                count = int_input3 - int_input2 + 1;
                tips_hidden();
            }
            else
            {
                tips();
            }
            for (int i = 0; i < count; i++)
            {
                string ipString = input1 + (int.Parse(input2) + i);
                IPAddress ip = IPAddress.Parse(ipString);

                Task.Run(() => scan(ip));

            }


        }

        public void tips()
        {
            error.Visibility = Visibility.Visible;
        }

        public void tips_hidden()
        {
            error.Visibility = Visibility.Hidden;
        }

        public void scan(Object ip)
        {
            DateTime timeBegin = DateTime.Now;
            IPAddress ipAddress = (IPAddress)ip;
            string hostName;

            try 
            {
                hostName = Dns.GetHostEntry(ipAddress).HostName;
            }
            catch (Exception e)
            {

                hostName = "(不在线)";
            }

            DateTime timeEnd = DateTime.Now;
            TimeSpan timeSpan = timeEnd - timeBegin;

            listBox.Dispatcher.Invoke(() => listBox.Items.Add("扫描地址：" + ip + "，" + "扫描时间：" + timeSpan.Milliseconds + "毫秒，" + "主机DNS名称：" + hostName));


        }


    }
}

