using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.LeetCode {
    public class ExcelSheetColumnNumber {
        public static int TitleToNumber(string s) {
            int col = 0, i = 0;
            IEnumerable<char> rs = s.Reverse<char>();
            foreach (char c in rs) {
                col += (c - 'A' + 1) * (int)Math.Pow(26, i);
                i++;
            }
            return col;
        }
    }
}
