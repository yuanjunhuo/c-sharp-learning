using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 矩阵运算
{
    class Program
    {
        //初始化矩阵
        public static double [,] Init(int row,int col)
        {
            double[,] matrix = new double[row, col];
            Random a = new Random();
            for(int i=0;i<row;i++)
            {
                for (int j=0;j<col;j++)
                {
                    matrix[i, j] = a.Next(100);
                }
            }
            return matrix;
        }
        //矩阵乘法，非并行方式
        public static void matrix_None_Parallel(double [,]one,double [,]two)
        {
            int one_row = one.GetLength(0);
            int one_col = one.GetLength(1);
            int two_col = two.GetLength(1);
            double[,] result = new double[one_row, two_col];
            for (int i =0;i<one_row;i++)
            {
                for(int j =0;j < two_col;j++)
                {
                    double temp = 0;
                    for(int k =0;k<one_col; k++)
                    {
                        temp += one[i, k] * two[k, j];
                    }
                    result[i, j] = temp;
                }
            }
            
        }
        //矩阵乘法，并行方式
        public static  void matrix_Parallel(double[,] one, double[,] two)
        {
            int one_row = one.GetLength(0);
            int one_col = one.GetLength(1);
            int two_col = two.GetLength(1);
            double[,] result = new double[one_row, two_col];
            Action<int> action = i =>
           {
               for (int j = 0; j < two_col; j++)
               {
                   double temp = 0;
                   for (int k = 0; k < one_col; k++)
                   {
                       temp += one[i, k] * two[k, j];
                   }
                   result[i, j] = temp;
               }
           };
            Parallel.For(0, one_row, action);           
            
        }

        private static void calculate (int arow ,int acol ,int bcol )
        {
            double[,] a = Init(arow, acol);
            double[,] b = Init(acol, bcol);
            Stopwatch time = new Stopwatch();
            time.Start();
            matrix_None_Parallel(a, b);
            time.Stop();
            Console.WriteLine("非并行用时："+time.ElapsedMilliseconds + "ms");
            Stopwatch time1 = new Stopwatch();
            time1.Start();
            matrix_Parallel(a, b);
            time1.Stop();
            Console.WriteLine("并行用时：" + time1.ElapsedMilliseconds + "ms");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("测试一（矩阵1：200*18），矩阵2：18*27");
            calculate(200, 18, 27);
            Console.WriteLine("测试一（矩阵1：2000*180），矩阵2：180*270");
            calculate(2000, 180, 270);
            Console.WriteLine("测试一（矩阵1：2000*200），矩阵2：200*300");
            calculate(2000, 200, 300);
            Console.ReadKey();
        }

    }
}
