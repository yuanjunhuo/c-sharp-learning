using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace 回合对战小游戏
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract(Namespace = "GameExample",
         SessionMode = SessionMode.Required,
         CallbackContract = typeof(IService1Callback))]

    public interface IService1
    {

        //服务端需实现的接口
      
        [OperationContract(IsOneWay = true)]
        void Login(string username);
        [OperationContract(IsOneWay = true)]
        void Loginout(string username);
        [OperationContract(IsOneWay = true)]
        void SitDown(string username, int index, int side);
        [OperationContract(IsOneWay = true)]
        void GetUp(int index, int side);
        [OperationContract(IsOneWay = true)]
        void Start(string username, int index, int side);
        [OperationContract(IsOneWay = true)]
        void MakeOrder(int index,int side,int Num,string skillname);
        [OperationContract(IsOneWay = true)]
        void Talk(int index, string userName, string message);


    }
    public interface IService1Callback
    {
        [OperationContract(IsOneWay = true)]
        void ShowLogin(string username, int maxtable);
        [OperationContract(IsOneWay = true)]
        void ShowLoginout(string username);
        [OperationContract(IsOneWay = true)]
        void ShowTalk(string userName, string message);
        [OperationContract(IsOneWay = true)]
        void UpdateTablesInfo(string roominfo, int usercount);
        [OperationContract(IsOneWay = true)]
        void ShowSitDown(string username, int side);
        [OperationContract(IsOneWay = true)]
        void ShowGetUp(int side);
        [OperationContract(IsOneWay = true)]
        void ShowStart(int side);
        [OperationContract(IsOneWay = true)]
        void Gamestart();
        [OperationContract(IsOneWay = true)]
        void ShowOpertion(int side, bool finish);
        [OperationContract(IsOneWay = true)]
        void ShowResult(string Op1, string Op2, int hp1, int hp2, int mp1, int mp2);
        [OperationContract(IsOneWay = true)]
        void Showmpnot();
        [OperationContract(IsOneWay = true)]
        void ShowWin(int iswin);


    }
}
