using System;
using System.Collections.Generic;
using System.IO;
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
using Client.ServiceReference1;

namespace Client
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //创建实例对象
        Service1Client service1Client = new Service1Client();
        public MainWindow()
        {
            InitializeComponent();
        //通过foreach ,调用方法，获取服务端的文件名，并将其显示在listbox 中，
            foreach (string info in service1Client.GetFileInfo())
            {
                ListBoxFileInfo.Items.Add(info);
            }
        }
        //点击下载按钮，触发下载事件
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //通过两次的split分割，获取文件的下载路径
            string[] info= ListBoxFileInfo.SelectedItem.ToString().Split(':');
            string SelectedFileName = info[1].Trim().Split(',')[0];
            string Path = AppDomain.CurrentDomain.BaseDirectory + SelectedFileName;
            //判断文件是否存在，然后通过类似文件拷贝的方法下载文件
            if (!File.Exists(Path))
            {
                TextBoxDownLoad.AppendText("正在下载 " + SelectedFileName + "\n");
                byte[] b = service1Client.DownLoadFile(SelectedFileName);
                FileStream fs = new FileStream(Path, FileMode.Create, FileAccess.ReadWrite);
                fs.Write(b, 0, b.Length);
                fs.Close();
                TextBoxDownLoad.AppendText("下载完成，共下载 " + b.Length + " 字节，文件保存到 " + Path + "\n");
            }
            else
            {
                MessageBox.Show("该文件已存在！");
            }
        }
    }
}
