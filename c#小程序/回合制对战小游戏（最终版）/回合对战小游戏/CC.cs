using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 回合对战小游戏
{
    public class CC
    {
        public static List<User> Users { get; set; }//用户列表
        public const int maxRooms = 10;//最大房间数
        public static GameTables[] Rooms { get; set; }//
        public static User GetUser(string userName)//获得用户信息
        {
            User user = null;
            foreach (var v in Users)
            {
                if (v.UserName == userName)
                {
                    user = v;
                    break;
                }
            }
            return user;
        }

    }
}