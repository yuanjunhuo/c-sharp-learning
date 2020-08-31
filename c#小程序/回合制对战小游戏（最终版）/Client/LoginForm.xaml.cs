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
using System.Windows.Threading;
using Client.ServiceReference1;

namespace Client
{
    /// <summary>
    /// LoginForm.xaml 的交互逻辑
    /// </summary>
    public partial class LoginForm : Window,IService1Callback
    {
        public string UserName
        {
            get { return user.Text; }
            set { user.Text = value; }
        }
       // private string Username;//用户名
        private int maxTables;//最大房间号
        private int tableIndex = -1;      //房间号
        private int tableSide = -1;       //座位号
        private Border[,] gametables;//每个房间的设计
        private Service1Client client;//远程代理类
        private bool isGameStart;//游戏是否开始
        private int nextside;//控制谁出招
        int Num = -1;//操作编号0-23

        public LoginForm()
        {
            InitializeComponent();
            this.Closing += LoginForm_Closing;
            ChangeRomesListVisible(false);
            ChangeRomeVisible(false);
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = TimeSpan.FromSeconds(1.0);   //设置刷新的间隔时间
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Time.Text = string.Concat(DateTime.Now);
        }



        #region 窗口中的事件
        private void login(object sender, RoutedEventArgs e)//点击登录按钮
        {
            UserName = user.Text;
            this.Cursor = Cursors.Wait;
            client = new Service1Client(new InstanceContext(this));
            try
            {
                client.Login(user.Text);
                
                ChangeState(btnlogin, false, btnloginout, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("与服务端连接失败：" + ex.Message);
                return;
            }
            this.Cursor = Cursors.Arrow;
        }
        private void loginout(object sender, RoutedEventArgs e)//点击退出按钮
        {
            this.Close();//此时调用closing方法
        }
        private void LoginForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)//用户要关闭窗口是调用
        {
            
            if (client != null)
            {
                if (tableIndex != -1) //如果在房间内，要求先返回大厅
                {
                    MessageBox.Show("请先返回大厅，然后再退出");
                    e.Cancel = true;
                }
                else
                {
                    client.Loginout(UserName); //从大厅退出
                    //注意此处不能再调用client.Close()，因为调用Logout后服务端已关闭与该用户的连接
                }
            }
        }
        private void btnStart_Click(object sender, RoutedEventArgs e)//点击开始
        {
            client.Start(UserName, tableIndex, tableSide);
            btnStart.IsEnabled = false;
        }
        private void btnReturn_Click(object sender, RoutedEventArgs e)//点击返回
        {
            client.GetUp(tableIndex,tableSide);
        }
        private void Button_Click(object sender, RoutedEventArgs e)//点击技能发动
        {
            Button button = e.Source as Button;
            string str = button.Name;
            Num = -1;
            
            if(str[0]=='B')
            {
                Num += 0 + ((int)str[1] - 48);
            }
            else if(str[0]=='G')
            {
                Num += 5 + ((int)str[1] - 48);
            }
            else if(str[0]=='F')
            {
                Num += 15 + ((int)str[1] - 48);
            }
            else
            {
                Num += 18 + ((int)str[1] - 48);
            }
            Button button1 = e.Source as Button;
            string str1 = button1.Tag.ToString();//技能名
            if(tableSide==nextside)
            client.MakeOrder(tableIndex,tableSide,Num,str1);
        }
        #endregion

        #region 功能性
        private void Createtables()//创建房间列表
        {
            
            this.gametables = new Border[maxTables, 2];
            //isFromServer = false;
            //创建游戏大厅中的房间（每房间一个游戏桌）
            for (int i = 0; i < maxTables; i++)
            {
                int j = i + 1;
                StackPanel sp = new StackPanel()
                {
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(5)
                };
                TextBlock text = new TextBlock()
                {
                    Text = "房间" + (i + 1),
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    Width = 20,
                    FontSize = 8
                };
                gametables[i, 0] = new Border()
                {
                    Tag = i + "0",
                    Background = Brushes.White,
                    Child = new Image()
                    {
                        Source = ((Image)this.Resources["player"]).Source,
                        Height = 20,
                        Width=20
                    }
                };
                Image image = new Image()
                {
                    Source = ((Image)this.Resources["vs"]).Source,
                    Height =20,
                    Width = 20
                };
                gametables[i, 1] = new Border()
                {
                    Tag = i + "1",
                    Background = Brushes.White,
                    Child = new Image()
                    {
                        Source = ((Image)this.Resources["player"]).Source,
                        Height = 20,
                        Width = 20
                    }
                };
                gametables[i, 0].MouseDown += RoomSide_MouseDown;
                gametables[i, 1].MouseDown += RoomSide_MouseDown;
                sp.Children.Add(text);
                sp.Children.Add(gametables[i, 0]);
                sp.Children.Add(image);
                sp.Children.Add(gametables[i, 1]);
                tableslist.Items.Add(sp);
            }
        }
        private void ChangeRomesListVisible(bool visible)//控制房间列表的显示
        {
            if (visible == false)
            {
                gametablesgrid.Visibility = System.Windows.Visibility.Collapsed;
                gridMessage.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                gametablesgrid.Visibility = System.Windows.Visibility.Visible;
                gridMessage.Visibility = System.Windows.Visibility.Visible;
            }


        }
        private void ChangeRomeVisible(bool visible)//控制游戏桌列表的显示
        {
            if (visible == false)
            {
                gamegrid.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                gamegrid.Visibility = System.Windows.Visibility.Visible;
            }

        }
        private void RoomSide_MouseDown(object sender, MouseButtonEventArgs e)//在某个座位坐下时引发的事件
        {
            
            Border border = e.Source as Border;
            if (border != null)
            {
                string s = border.Tag.ToString();
                tableIndex = int.Parse(s[0].ToString());
                tableSide = int.Parse(s[1].ToString());
                client.SitDown(UserName, tableIndex, tableSide);
            }
        }
        private void AddMessage(string str)//在右边的列表添加实时信息
        {
            TextBlock t = new TextBlock();
            t.Text = str;
            t.Foreground = Brushes.Black;
            messagelist.Items.Add(t);
        }
        private void AddColorMessage(string str, SolidColorBrush color)
        {
            TextBlock t = new TextBlock();
            t.Text = str;
            t.Foreground = color;
            messagelist.Items.Add(t);
        }
        private static void ChangeState(Button btnStart, bool isStart, Button btnStop, bool isStop)//改变按钮状态
        {
            btnStart.IsEnabled = isStart;
            btnStop.IsEnabled = isStop;
        }
        private void addgamemessage(string str)//在实时信息框中添加信息
        {
            
            gamemessage.Items.Add(str);

            

        }
        private void G_MouseEnter(object sender, MouseEventArgs e)//技能介绍
        {
            Button item = e.Source as Button;
            string str1 = null;
            string ostr = "";
            if (item != null)
            {
                str1 = item.Tag.ToString();
                switch (str1)
                {
                    case "干扰":
                        skillinfo.Text = ostr+str1 + ":无消耗，造成0点伤害";
                        break;
                    case "冥想":
                        skillinfo.Text = ostr+str1 + ":无消耗，若这回合对方的操作不是攻击操作，则恢复3点能量";
                        break;
                    case "以柔克刚":
                        skillinfo.Text = ostr+str1 + ":消耗1点能量，若这回合对方的操作是攻击操作，则恢复这回合对方攻击操作的伤害等额的能量且减少2点受到的伤害";
                        break;
                    case "苦肉":
                        skillinfo.Text = ostr+str1 + ":消耗4点能量，恢复这回合对方对你造成伤害数值2倍的能量";
                        break;
                    case "闭关":
                        skillinfo.Text = ostr+str1 + ":消耗5点能量，若这回合对方的操作不是攻击操作，则恢复10点能量";
                        break;
                    case "思索":
                        skillinfo.Text = ostr+str1 + ":无消耗，恢复2点能量";
                        break;
                    case "普通攻击":
                        skillinfo.Text = ostr+str1 + ":消耗1点能量，造成1点伤害";
                        break;
                    case "强力攻击":
                        skillinfo.Text = ostr+str1 + ":消耗2点能量，造成3点伤害";
                        break;
                    case "破甲穿刺":
                        skillinfo.Text = ostr+str1 + ":消耗2点能量，无视对方的格挡并造成2点伤害";
                        break;
                    case "粉碎打击":
                        skillinfo.Text = ostr+str1 + ":消耗5点能量，无视对方的格挡并造成4点伤害";
                        break;
                    case "蓄力一击":
                        skillinfo.Text = ostr+str1 + ":消耗5点能量，造成7点伤害";
                        break;
                    case "嗜血":
                        skillinfo.Text = ostr+str1 + ":消耗5点能量，造成5点伤害，并恢复造成伤害等额的生命值";
                        break;
                    case "充能打击":
                        skillinfo.Text = ostr+str1 + ":消耗5点能量，造成5点伤害，并恢复造成伤害等额的能量";
                        break;
                    case "灵魂汲取":
                        skillinfo.Text = ostr+str1 + ":消耗7点能量，造成5点伤害，并恢复造成伤害等额的生命值和能量";
                        break;
                    case "能量倾泻":
                        skillinfo.Text = ostr+str1 + ":消耗20点能量，获得本次游戏胜利";
                        break;
                    case "盾防":
                        skillinfo.Text = ostr+str1 + ":无消耗，格挡3点伤害";
                        break;
                    case "能量护盾":
                        skillinfo.Text = ostr+str1 + ":消耗2点能量，格挡5点伤害";
                        break;
                    case "充能防御":
                        skillinfo.Text = ostr+str1 + ":消耗3点能量，格挡所有伤害，若对方这回合是攻击操作，则恢复3点能量";
                        break;
                    case "恢复":
                        skillinfo.Text = ostr+str1 + ":无消耗，若对方这回合是非攻击操作，则恢复2点生命值";
                        break;
                    case "妙手回春":
                        skillinfo.Text = ostr+str1 + ":消耗2点能量，若对方这回合是非攻击操作，则恢复5点生命值";
                        break;
                    case "能量恢复":
                        skillinfo.Text = ostr+str1 + ":消耗2点能量，恢复3点生命值";
                        break;
                    case "超能恢复":
                        skillinfo.Text = ostr+str1 + ":消耗5点能量，恢复6点生命值";
                        break;
                    case "涅槃":
                        skillinfo.Text = ostr+str1 + ":消耗5点能量，若对方这回合是非攻击操作，则恢复10点生命值";
                        break;
                    case "扭转乾坤":
                        skillinfo.Text = ostr+str1 + ":消耗5点能量，将对方本回合对你造成的伤害转化为你的生命值恢复";
                        break;
                }
            }

        }
        private void G_MouseLeave(object sender, MouseEventArgs e)
        {
            skillinfo.Text = "";
        }
        private void TextChanged(object sender, TextChangedEventArgs e)//玩家血量和能量的显示
        {
            TextBox textBox = e.Source as TextBox;
            if (textBox.Name == "MP")
            {
                int a = int.Parse(MP.Text);
                string str1 = null;
                for (int i = 0; i < a; i++)
                {
                    str1 += "●";
                }
                MPL1.Text = str1;
            }
            else if (textBox.Name == "HP")
            {
                int a = int.Parse(HP.Text);
                string str1 = null;
                for (int i = 0; i < a; i++)
                {
                    str1 += "●";
                }
                HPL1.Text = str1;
            }
            else if (textBox.Name == "MPX")
            {
                int a = int.Parse(MPX.Text);
                string str1 = null;
                for (int i = 0; i < a; i++)
                {
                    str1 += "●";
                }
                MPL2.Text = str1;
            }
            else
            {
                int a = int.Parse(HPX.Text);
                string str1 = null;
                for (int i = 0; i < a; i++)
                {
                    str1 += "●";
                }
                HPL2.Text = str1;
            }
        }
        
        public void RcetGames(int side)//初始化游戏
        {   
            if(side==0)
            {
                HP.Text = "20";
                MP.Text = "3";
            }
            else
            {
                HPX.Text = "20";
                MPX.Text = "3";
            }
            gamemessage.Items.Clear();
        }
        public void cleargame(int side)//返回时清理桌面
        {
            HP.Text = "0";
            MP.Text = "0";
            HPX.Text = "0";
            MPX.Text = "0";
            gamemessage.Items.Clear();
            if(side==0)
            {
                player1.Text = "";
            }
            else
            {
                player2.Text = "";
            }
        }
        public void shownext(int side)
        {   if (isGameStart == true)
            {
                nextside = side;
                if (side == 0)
                {
                    addgamemessage("轮到玩家一的回合");
                }
                else
                {
                    addgamemessage("轮到玩家二的回合");
                }
            }
        }
        #endregion
        #region 客户端需实现的接口
        public void ShowLogin(string username,int maxTables)
        {
            if (username == UserName)
            {
                ChangeRomesListVisible(true);
                this.maxTables = maxTables;
                this.Createtables();
            }
            AddMessage(username + "进入大厅。");
        }
        public void ShowLoginout(string username)
        {
            AddMessage(username + "退出大厅。");
        }
        public void UpdateTablesInfo(string tablesInfo, int userCount)//更新在线人数，房间列表的信息（用户头像的显示）
        {
            infotb1.Text = string.Format("在线人数：{0}", userCount);

            for (int i = 0; i < maxTables; i++)//用户头像的控制
            {
                for (int j = 0; j < 2; j++)
                {
                    if (tableIndex == -1)
                    {
                        if (tablesInfo[2 * i + j] == '0')
                        {
                            gametables[i, j].Child.Visibility = System.Windows.Visibility.Hidden;
                            gametables[i, j].Child.IsEnabled = true;
                        }
                        else
                        {
                            gametables[i, j].Child.Visibility = System.Windows.Visibility.Visible;
                            gametables[i, j].Child.IsEnabled = false;
                        }
                    }
                    else
                    {
                        gametables[i, j].Child.IsEnabled = false;
                        if (tablesInfo[2 * i + j] == '0')
                        {
                            gametables[i, j].Child.Visibility = System.Windows.Visibility.Hidden;
                        }
                        else gametables[i, j].Child.Visibility = System.Windows.Visibility.Visible;
                    }
                }
            }
        }
        public void ShowTalk(string userName, string message)
        {
            AddColorMessage(string.Format("{0}：{1}", userName, message), Brushes.Black);
        }
        public void ShowSitDown(string username,int side)//
        {
            
            if (side == tableSide)
            {
                isGameStart = false;
                
                btnStart.IsEnabled = true;
                tableslist.IsEnabled = false;//返回大厅前不允许再坐到另一个位置
                
                ChangeRomeVisible(true);//显示游戏桌
            }
            if (side == 0)
            {
                player1.Text = "玩家一：\n" + username;
                AddMessage(string.Format("{0}在房间{1}入座。", username, tableIndex + 1));
            }
            else
            {
                player2.Text = "玩家二：\n" + username;
                AddMessage(string.Format("{0}在房间{1}入座。", username, tableIndex + 1));
            }
        }
        public void ShowGetUp(int side)
        {
            cleargame(side);
            if (side == tableSide)//对自己的操作
            {
                isGameStart = false;
               
                tableslist.IsEnabled = true;//返回大厅后允许操作房间列表
                AddMessage(UserName + "返回大厅。");
                this.tableIndex = -1;
                this.tableSide = -1;
                ChangeRomeVisible(false);//去掉游戏桌
            }
            else//对对方的操作
            {
                
                if (isGameStart)
                {
                    AddMessage("对方回大厅了，游戏结束。");
                    
                    isGameStart = false;
                    btnStart.IsEnabled = true;
                }
                else
                {
                    
                    AddMessage("对方返回大厅。");
                }
                
            }
        }
        public void ShowStart(int side)//在右侧添加信息，并初始化游戏
        {
            RcetGames(side);
            if (side == 0) AddMessage("玩家一已开始。");
            else AddMessage("玩家二已开始。");
        }
        public void Gamestart()//开始游戏
        {
            addgamemessage("游戏开始");
            isGameStart = true;
            shownext(0);
        }

        public void ShowOpertion(int side,bool fish)//操作提示信息
        {   if (fish == false)
            {
                addgamemessage("玩家" + (side + 1) + "已操作");
                shownext((side + 1) % 2);
            }
            else
            {
                addgamemessage("玩家" + (side + 1) + "已操作");
                addgamemessage("本轮已完成");
                nextside = (side + 1) % 2;
                
            }
        }

        public void ShowResult(string Op1,string Op2,int hp1, int hp2, int mp1, int mp2)//展示一轮结果
        {   
            addgamemessage("玩家一使用" + Op1+"，玩家二使用" + Op2);
            //addgamemessage("玩家一血量" + hp1 + "能量" + mp1);
            //addgamemessage("玩家二血量" + hp2 + "能量" + mp2);
            HP.Text = hp1.ToString();
            MP.Text = mp1.ToString();
            HPX.Text = hp2.ToString();
            MPX.Text = mp2.ToString();

            shownext(nextside);
        }

        public void Showmpnot()//能量不够
        {
            MessageBox.Show("能量不足！");

        }
        public void ShowWin(int iswin)
        {
            if (iswin == 1)
            {
                MessageBox.Show("玩家一胜！");
            }
            else if (iswin == 2)
            {
                MessageBox.Show("玩家二胜！");
            }
            else
            {
                MessageBox.Show("平局！");
            }
            btnStart.IsEnabled = true;
            isGameStart = false;

        }

        #endregion
        //聊天功能
        private void talktext_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                client.Talk(tableIndex, UserName, talktext.Text);
            }
            
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            client.Talk(tableIndex, UserName, talktext.Text);
        }




    }
}
