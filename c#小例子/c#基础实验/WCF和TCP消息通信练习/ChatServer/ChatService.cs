using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static ChatServer.IChatService;

namespace ChatServer
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“ChatService”。
    public class ChatService : IChatService
    {
        public void Login(string userName)
        {
            OperationContext context = OperationContext.Current;
            IChatServiceCallback callback = context.GetCallbackChannel<IChatServiceCallback>();
            User newUser = new User(userName, callback);
            string str = "";
            for (int i = 0; i < CC.Users.Count; i++)
            {
                str += CC.Users[i].userName + "、";
            }
            newUser.callback.InitUsersInfo(str.TrimEnd('、'));
            CC.Users.Add(newUser);
            foreach (var user in CC.Users)
            {
                user.callback.ShowLogin(userName);
            }
        }

        public void Logout(string userName)
        {
            OperationContext context = OperationContext.Current;
            IChatServiceCallback callback = context.GetCallbackChannel<IChatServiceCallback>();
            //foreach (var user in CC.Users)
            //{
            //    if(user.userName == userName)
            //    {
            //        CC.Users.Remove(user);
            //    }
            //}
            foreach (var user in CC.Users)
            {
                user.callback.logout(userName);
            }
        }

        public void Talk(string userName, string message)
        {
            OperationContext context = OperationContext.Current;
            IChatServiceCallback callback = context.GetCallbackChannel<IChatServiceCallback>();
            foreach (var user in CC.Users)
            {
                if (user.userName == userName)
                    continue;
                user.callback.ShowTalk(userName,message);
            }
        }
    }
}
