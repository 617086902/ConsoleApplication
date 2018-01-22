using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApplication.LeetCode
{
    public class TwoSum
    {
        /// <summary>
        /// 获取数组中两个数之和为指定值的元素位置
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] GetTwoSum(int[] nums, int target)
        {
            //规则是不能排序—_—
            //Array.Sort(nums);
            //int i = 0, j = nums.Length - 1;
            //while (i < j)
            //{
            //    var sum = nums[i] + nums[j];
            //    if (sum < target) i++;
            //    else if (sum > target) j--;
            //    else return new[] { i + 1, j + 1 };
            //}

            //naive
            //for (var i = 0; i < nums.Length; i++)
            //{
            //    for (var j = i + 1; j < nums.Length; j++)
            //    {
            //        if (nums[i] + nums[j] == target)
            //            return new[] { i + 1, j + 1 };
            //    }
            //}

            //best
            Hashtable ht = new Hashtable();
            for (var i = 0; i < nums.Length; i++)
            {
                if (ht.Contains(nums[i]))
                    return new[] { Convert.ToInt32(ht[nums[i]]) + 1, i + 1 };
                else
                {
                    if (!ht.ContainsKey(target - nums[i]))
                        ht.Add(target - nums[i], i);
                }
            }
            return null;
        }
    }
}
