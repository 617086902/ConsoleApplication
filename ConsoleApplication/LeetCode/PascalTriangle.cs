using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.LeetCode
{
    public class PascalTriangle
    {
        /// <summary>
        /// 杨辉三角
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public static IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> lc = new List<IList<int>>(numRows);
            for (int i = 0; i < numRows; i++)
            {
                lc.Add(new List<int>());
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i)
                        lc[i].Add(1);
                    else
                        lc[i].Add(lc[i - 1][j] + lc[i - 1][j - 1]);
                }
            }
            return lc;

            //数组实现
            //int ml = numRows * 2 - 1, cl = (ml - 1) / 2;
            //int[,] arr = new int[numRows, ml];
            //arr[0, cl] = 1;
            //for (int i = 1; i < numRows; i++)
            //{
            //    for (int j = cl - i; j < ml; j++)
            //    {
            //        if (j - 1 < 0) arr[i, j] = arr[i - 1, j + 1];
            //        else if (j + 1 > ml - 1) arr[i, j] = arr[i - 1, j - 1];
            //        else arr[i, j] = arr[i - 1, j - 1] + arr[i - 1, j + 1];
            //    }
            //}
        }
    }
}
