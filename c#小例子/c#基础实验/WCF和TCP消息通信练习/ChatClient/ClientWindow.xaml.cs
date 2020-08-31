using ChatClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

namespace ChatClient
{
    /// <summary>
    /// ClientWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ClientWindow : Window, IChatServiceCallback
    {
        private string userName = "";
        public ClientWindow()
        {
            InitializeComponent();
        }
        //登录
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            userName = userText.Text;
            InstanceContext context = new InstanceContext(this);
            ChatServiceClient duan = new ChatServiceClient(context);
            duan.Login(userName);
        }

        //退出
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            InstanceContext context = new InstanceContext(this);
            ChatServiceClient duan = new ChatServiceClient(context);
            duan.Logout(userName);
        }
        //点击按钮，发送信息
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddMessage(message.Text);
            InstanceContext context = new InstanceContext(this);
            ChatServiceClient duan = new ChatServiceClient(context);
            string str = userName + "：" + message.Text + "\n";
            duan.Talk(userName, str);
        }
        private void logout(string userName)
        {
            foreach (var user in listBoxOnLine.Items)
            {
                if(user.ToString() ==  userName)
                {
                    listBoxOnLine.Items.Remove(userName);
                }
            }
        }
        public void InitUsersInfo(string UserInfo)
        {
            if(UserInfo.Length == 0)
            {
                return;
            }
            string[] users = UserInfo.Split('、');
            for (int i = 0; i < users.Length; i++)
            {
                listBoxOnLine.Items.Add(users[i]);
            }
        }

        public void ShowLogin(string loginUserName)
        {
            listBoxOnLine.Items.Add(loginUserName);
        }

        public void Showlogout(string userName)
        {
            listBoxOnLine.Items.Remove(userName);
        }

        public void ShowTalk(string userName, string message)
        {
            talkMessage.Text += message;
        }
        private void AddMessage(string str)
        {
            str = message.Text + "\n";
            talkMessage.Text += userName+ "：" + str;
        }
    }
}
