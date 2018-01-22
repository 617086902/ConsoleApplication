using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.LeetCode
{
    public class SameTree
    {
        /// <summary>
        /// 判断两棵二叉树是否相同
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public static bool IsSameTree(TreeNode p,TreeNode q)
        {
            if (p == null && q == null) return true;
            else if (p == null || q == null) return false;
            else return p.value == q.value && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
    }
}
