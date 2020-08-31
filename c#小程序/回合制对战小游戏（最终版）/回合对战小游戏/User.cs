using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 回合对战小游戏
{
    public class User
    {
        public string UserName { get; set; }//用户名
        public readonly IService1Callback callback;//与该用户通信的回调接口
        public int Index { get; set; }//桌子号
        public int Side { get; set; }//哪一边
        public bool IsStarted { get; set; }//是否开始
        public User(string userName, IService1Callback callback)//初始化用户,为用户对象添加信息
        {
            this.UserName = userName;
            this.callback = callback;
        }

    }
}