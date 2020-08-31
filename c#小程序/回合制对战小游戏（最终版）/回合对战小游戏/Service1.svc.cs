using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace 回合对战小游戏
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class Service1 : IService1
    {   
        public Service1()
        {
            
                if (CC.Users == null)
                {
                    CC.Users = new List<User>();//实例化对象
                    CC.Rooms = new GameTables[CC.maxRooms];
                    for (int i = 0; i < CC.maxRooms; i++)
                    {
                        CC.Rooms[i] = new GameTables();//每个桌子均实例化
                    }
                }
            
        }
        //服务端要实现的接口
        #region 服务端要实现的接口
        public void Login(string username)
        {
            OperationContext context = OperationContext.Current;
            IService1Callback callback = context.GetCallbackChannel<IService1Callback>();
            User newUser = new User(username, callback);
            CC.Users.Add(newUser);
            foreach (var user in CC.Users)
            {
                user.callback.ShowLogin(username,CC.maxRooms);
            }
            SendRoomsInfoToAllUsers();
        }
        public void Loginout(string username)
        {
            User logoutUser = CC.GetUser(username);
            foreach (var user in CC.Users)
            {
                //不需要发给退出用户
                if (user.UserName != logoutUser.UserName)
                {
                    user.callback.ShowLoginout(username);
                }
            }
            CC.Users.Remove(logoutUser);
            logoutUser = null; //将其设置为null后，WCF会自动关闭该客户端
            SendRoomsInfoToAllUsers();
        }
       
        public void SitDown(string username,int index,int side)
        {
            User p = CC.GetUser(username);
            p.Index = index;
            p.Side = side;
            CC.Rooms[index].players[side] = p;
            //告诉入座玩家入座信息
            p.callback.ShowSitDown(username, side);

            int anotherSide = (side + 1) % 2;  //同一桌的另一个玩家
            User p1 = CC.Rooms[index].players[anotherSide];
            if (p1 != null)
            {
                //告诉入座玩家另一个玩家是谁
                p.callback.ShowSitDown(p1.UserName, anotherSide);
                //告诉另一个玩家入座玩家是谁
                p1.callback.ShowSitDown(p.UserName, side);
            }
            //重新将游戏室各桌情况发送给所有用户
            SendRoomsInfoToAllUsers();
        }
        public void GetUp(int index,int side)
        {
            User p0 = CC.Rooms[index].players[side];
            User p1 = CC.Rooms[index].players[(side + 1) % 2];
            p0.callback.ShowGetUp(side);
            CC.Rooms[index].players[side] = null; //注意该语句执行后p0!=null
            if (p1 != null)
            {
                p1.callback.ShowGetUp(side);
                p1.IsStarted = false;
            }
            //重新将游戏室各桌情况发送给所有用户
            SendRoomsInfoToAllUsers();
        }
        public void Start(string username,int index,int side)
        {
            User p0 = CC.Rooms[index].players[side];
            p0.IsStarted = true;
            p0.callback.ShowStart(side);
            int anotherSide = (side + 1) % 2;   //对方座位号
            User p1 = CC.Rooms[index].players[anotherSide];
            if (p1 != null)
            {
                p1.callback.ShowStart(side);
                if (p1.IsStarted)
                {
                    CC.Rooms[index].Resetgames();
                    p0.callback.Gamestart();
                    p1.callback.Gamestart();
                }
            }
        }
        public void MakeOrder(int index,int side,int Num,string skillname)
        {
            CC.Rooms[index].DothisOrder(side,Num,skillname);

        }
        public void Talk(int index, string userName, string message)
        {
            User p0 = CC.Rooms[index].players[0];
            User p1 = CC.Rooms[index].players[1];
            if (p0 != null) p0.callback.ShowTalk(userName, message);
            if (p1 != null) p1.callback.ShowTalk(userName, message);
        }
        #endregion
        #region 其他
        private string GetTablesInfo()//用一个字符串表示每个房间的人数状况
        {
            string str = "";
            for (int i = 0; i < CC.Rooms.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    str += CC.Rooms[i].players[j] == null ? "0" : "1";
                }
            }
            return str;
        }
        private void SendRoomsInfoToAllUsers()//将当前游戏室情况发送给所有用户
        {
            int userCount = CC.Users.Count;
            string roomInfo = this.GetTablesInfo();
            foreach (var user in CC.Users)
            {
                user.callback.UpdateTablesInfo(roomInfo, userCount);
            }
        }

        #endregion
    }
}
