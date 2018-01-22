using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.LeetCode
{
    public class ZigZagConversion
    {
        /// <summary>
        /// Z字转换
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public static string Convert(string s, int numRows)
        {
            if (s == "") return "";
            string res = "";
            int len = s.Length, col = 0, i = 0, j = 0, lrows = numRows - 1 > 0 ? numRows - 1 : 1;
            while (len > 0)
            {
                if (lrows == 0) { col = len; break; }
                len -= col % (lrows) == 0 ? numRows : 1;
                col++;
            }
            char[,] carr = new char[numRows, col];
            foreach (char a in s)
            {
                if (j % lrows != 0)
                {
                    for (int m = 0; m < numRows; m++)
                        if (j % lrows == lrows - m)
                            carr[m, j] = a;
                    j++;
                }
                else
                {
                    carr[i, j] = a; i++;
                    if (i % numRows == 0) { i = 0; j++; }
                }
            }
            foreach (char cn in carr)
                if (cn != default(char)) res += cn;
            return res;
        }
    }
}
