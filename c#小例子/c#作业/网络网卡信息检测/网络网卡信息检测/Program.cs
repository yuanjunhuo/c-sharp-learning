using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Text;
namespace 网络网卡信息检测
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("            网络适配器信息");
            int num = 0;
            NetworkInterface[] nets = NetworkInterface.GetAllNetworkInterfaces();
            IPInterfaceProperties adapter = nets[0].GetIPProperties();
            foreach (var item in nets)
            {
                num = num + 1;
            }
            Console.Write("适配器个数：");
            Console.WriteLine(num);
            Console.WriteLine("----------第一个适配器信息----------");            
            Console.WriteLine("描述信息:" + nets[0].Description);
            Console.WriteLine("名称：" + nets[0].Name);
            Console.WriteLine("类型：" + nets[0].NetworkInterfaceType);
            Console.WriteLine("速度：" + nets[0].Speed);
            Console.WriteLine("MAC 地址：" + (nets[0].GetPhysicalAddress()).ToString ());
            foreach(var i in adapter .DnsAddresses )
            {
                Console.WriteLine("DNS服务器地址：" + i);
            }
            Console.WriteLine("             网络流量统计");
            IPGlobalProperties pro = IPGlobalProperties.GetIPGlobalProperties();

          
           
            

            
            Console.ReadKey();



        }
    }
}
