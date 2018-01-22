using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.LeetCode {
    public class NumberOf1Bits {
        /// <summary>
        /// n&(n-1) 把二进制数最低位的1变成0
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int HammingWeight(int n) {
            int re = 0;
            while (0 != n) {
                n = n & (n - 1);
                ++re;
            }
            return re;
        }
    }
}
