using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class Service1 : IService1
    {
        //获取可以下载的文件的基本信息，文件名，文件长度，文件大小等
        public List<string> GetFileInfo()
        {
            string Path = AppDomain.CurrentDomain.BaseDirectory + @"DownLoadFile";
            DirectoryInfo directoryInfo = new DirectoryInfo(Path);
            FileInfo[] info = directoryInfo.GetFiles();
            List<string> list = new List<string>();
            foreach (FileInfo file in info)
            {
                list.Add("文件名 : " + file.Name + ",文件长度 : " + file.Length + " 字节");
            }
            return list;
        }
        //下载文件的实现方法如下
        public byte[] DownLoadFile(string FileName)
        {
            string Path = AppDomain.CurrentDomain.BaseDirectory + @"\DownLoadFile\" + FileName;
            FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.Read);
            byte[] b = new byte[fs.Length];
            fs.Read(b, 0, b.Length);
            fs.Close();
            return b;
        }
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        
    }
}
