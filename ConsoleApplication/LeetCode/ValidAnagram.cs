using ConsoleApplication.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.LeetCode {
    public class ValidAnagram {
        public static bool IsAnagram(string s, string t) {
            //对于大字符串耗时过长
            //for (int i = 0; i < s.Length; i++) {
            //    int index = t.IndexOf(s.ElementAt(i));
            //    if (index < 0)
            //        return false;
            //    t = t.Remove(index, 1);
            //}
            //return true;

            //本质没变，还是慢
            //while (s.Length > 0) {
            //    int index = t.IndexOf(s.ElementAt(0));
            //    if (index < 0)
            //        return false;
            //    s = s.Remove(0, 1);
            //    t = t.Remove(index, 1);
            //}
            //return true;

            //排序比较
            //char[] sarr = s.ToCharArray();
            //char[] tarr = t.ToCharArray();
            //Quick<char>.Sort(sarr);
            //Quick<char>.Sort(tarr);
            //for(int i = 0; i < sarr.Length; i++) {
            //    if (sarr[i] != tarr[i]) return false;
            //}

            if (s.Length != t.Length) return false;
            int[] bit = new int[26];
            for (int i = 0; i < s.Length; i++)
                bit[s[i] - 'a']++;
            for (int j = 0; j < s.Length; j++)
                if (--bit[t[j] - 'a'] < 0)
                    return false;
            return true;
        }
    }
}
