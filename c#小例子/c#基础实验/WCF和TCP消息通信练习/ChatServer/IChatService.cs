using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ChatServer
{
    [ServiceContract(Namespace = "WcfChatExample", CallbackContract = typeof(IChatServiceCallback))]

    public interface IChatService
    {
        [OperationContract(IsOneWay = true)]
        void Login(string userName);
        [OperationContract(IsOneWay = true)]
        void Logout(string userName);
        [OperationContract(IsOneWay = true)]
        void Talk(string userName, string message);

    }

    public interface IChatServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void ShowLogin(string loginUserName);
        [OperationContract(IsOneWay = true)]
        void Showlogout(string userName);
        [OperationContract(IsOneWay = true)]
        void ShowTalk(string userName, string message);
        [OperationContract(IsOneWay = true)]
        void InitUsersInfo(string UserInfo);
        [OperationContract(IsOneWay = true)]
        void logout(string userName);
    }
}
