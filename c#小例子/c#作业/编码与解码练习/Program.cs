using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingExercise
{
    class Program
    {        
        static void Main(string[] args)
        {
            foreach (var ei in Encoding.GetEncodings())
            {
                Encoding en = ei.GetEncoding();
                Console.WriteLine("编码名称：{0,-18}, 编码描述：{1}", ei.Name, en.EncodingName);
            }
            Console.Write("请输入要进行编解码的字符：");
            string s=Console.ReadLine();
            EncodeDecode(s, Encoding.ASCII);
            EncodeDecode(s, Encoding.GetEncoding("GB2312"));
            Console.ReadKey();
        }
        private static void EncodeDecode(string s, Encoding encoding)
        {
            StringBuilder sb = new StringBuilder();
            byte[] bytes = encoding.GetBytes(s);
            string str = encoding.GetString(bytes);
            string encodeResult = BitConverter.ToString(bytes);
            sb.AppendFormat("编码为：{0},编码结果为：{1}\n", encoding.EncodingName, encodeResult);
            sb.AppendFormat("解码为：{0}\n", str);
            Console.WriteLine(sb);
        }
    }
    
}
