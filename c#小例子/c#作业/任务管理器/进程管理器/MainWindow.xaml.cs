using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace 进程管理器
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    /// 

    public class Data
    {
        public int Id { set; get; }
        public string ProcessName { set; get; }
        public string TotalMemory { set; get; }
        public string StartTime { set; get; }
        public string FileName { set; get; }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RefreshProcessInfo();
        }
        List<Data> lists = new List<Data>();
        private void RefreshProcessInfo()
        {
            datagrid1.ItemsSource = null;
            lists.Clear();
            Process[] processes = Process.GetProcesses(); // 获取本机所有进程
            string FileName = "";
            foreach (Process p in processes)
            {
                Data data = new Data();
                try
                {
                    data.FileName = p.MainModule.FileName;
                    data.StartTime = p.StartTime.ToString("yyyy-M-d HH:mm:ss");
                }
                catch (Exception)
                {
                    data.FileName = " ";
                    data.StartTime = "";
                }
                data.Id = p.Id;
                data.ProcessName = p.ProcessName;
                data.TotalMemory = string.Format("{0,10:0}KB", p.WorkingSet64 / 1024d);
                lists.Add(data);
               datagrid1.ItemsSource = lists;
            }
        }
        private void stop(object sender, RoutedEventArgs e)
        {
            var a = datagrid1.SelectedItem;
            Data selectItem = a as Data;
            Process p = Process.GetProcessById(selectItem.Id);
            try
            {
                p.Kill();
            }
            catch (Exception)
            {
                MessageBox.Show("权限不够，进程关闭失败！！！！！！");
            }
            RefreshProcessInfo();
        }

        //启动记事本进程
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "NotePad";
            p.Start();
        }
    }
}


