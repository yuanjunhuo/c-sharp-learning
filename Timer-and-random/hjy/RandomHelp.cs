using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hjy
{
    class RandomHelp
    {
        public static int getIntRandomNumber(int a,int b)
        {
            Random num = new Random();
            return num.Next(a, b);
        }
        public static double getDoubleRandomNumber(int min, int max)
        {
            Random num = new Random();
            int num1 = num.Next (min,max);
            double num2 = num.NextDouble();
            return num1 + num2;
         
        }
    }
}
