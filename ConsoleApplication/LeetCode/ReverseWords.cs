using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.LeetCode
{
    /// <summary>
    /// 反转句子里的单词
    /// </summary>
    public class ReverseWords
    {
        Stack<int> stack = new Stack<int>();
        Stack<int> stack2 = new Stack<int>();
        // Push element x to the back of queue.
        public void Push(int x)
        {
            stack.Push(x);
        }

        // Removes the element from front of queue.
        public void Pop()
        {
            while (stack.Any())
                stack2.Push(stack.Pop());
            stack2.Pop();
            while (stack2.Any())
                stack.Push(stack2.Pop());
        }

        // Get the front element.
        public int Peek()
        {
            while (stack.Any())
                stack2.Push(stack.Pop());
            var res = stack2.Peek();
            while (stack2.Any())
                stack.Push(stack2.Pop());
            return res;
        }

        // Return whether the queue is empty.
        public bool Empty()
        {
            return stack.Count == 0;
        }
        public static string Test(string str)
        {
            string[] strList = str.Trim().Split(' ');
            StringBuilder sb = new StringBuilder();
            Stack<string> queue = new Stack<string>();
            for (var i = 0; i < strList.Length; i++)
                if (!string.IsNullOrEmpty(strList[i]))
                    queue.Push(strList[i]);
            int length = queue.Count;
            for (var j = 0; j < length; j++)
                sb.Append(queue.Pop() + " ");
            return sb.ToString().Trim();
        }
    }
}
