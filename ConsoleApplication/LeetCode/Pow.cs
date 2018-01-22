using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.LeetCode
{
    public class Pow
    {
        /// <summary>
        /// 求幂运算
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static double MyPow(double x, int n)
        {
            //当n超大时，比如2147483647，被虐成狗
            //而且没有考虑n为负数的情况
            //double res = 1;
            //for (int i = 0; i < n; i++)
            //    res = res * x;
            //return res;

            //二分，将相乘计算次数减少一半
            if (n == 0) return 1;
            if (n == 1) return x;
            if (n == -1) return 1 / x;
            double h = MyPow(x, n / 2);
            if (n % 2 == 0) return h * h;
            if (n < 0)
                return h * h * (1 / x);
            else
                return h * h * x;
        }
    }
}
