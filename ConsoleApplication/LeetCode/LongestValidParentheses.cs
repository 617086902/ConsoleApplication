using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.LeetCode {
    public class LongestValidParentheses {
        /// <summary>
        /// 最长有效括号对
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int Test(string s) {
            Stack<int> stack = new Stack<int>();
            int longestValidParentheses = 0;
            foreach (char c in s) {
                if (stack.Count == 0) { stack.Push(c == '(' ? 0 : 1); continue; }
                if (c == '(') { stack.Push(0); continue; }
                //以下为遇到右括号的情况
                if (stack.Peek() == 1) { stack.Push(1); continue; }
                if (stack.Peek() == 0) {
                    stack.Pop();
                    if (stack.Count > 0 && stack.Peek() > 1) {
                        int mc = stack.Pop();
                        while (stack.Count > 0 && stack.Peek() > 1) {
                            mc += stack.Pop() - 1;
                        }
                        stack.Push(mc + 1);
                    } else
                        stack.Push(2);
                    continue;
                }
                if (stack.Peek() > 1) {
                    int mc = stack.Pop();
                    if (stack.Count > 0 && stack.Peek() == 0) {
                        stack.Pop();
                        mc += 1;
                        while (stack.Count > 0 && stack.Peek() > 1) {
                            mc += stack.Pop() - 1;
                        }
                        stack.Push(mc);
                    } else {
                        stack.Push(mc);
                        stack.Push(1);
                    }
                }
            }
            while (stack.Count > 0) {
                int vl = (stack.Pop() - 1) * 2;
                longestValidParentheses = vl > longestValidParentheses ? vl : longestValidParentheses;

            }
            return longestValidParentheses;
        }
    }
}
