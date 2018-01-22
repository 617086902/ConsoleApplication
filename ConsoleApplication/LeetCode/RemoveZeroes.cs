using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.LeetCode {
    public class RemoveZeroes {
        public static void Move(int[] nums) {
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (nums[i] == 0)
            //    {
            //        for (int j = i; j < nums.Length; j++)
            //        {
            //            if (nums[j] != 0)
            //            {
            //                nums[i] = nums[j];
            //                nums[j] = 0;
            //                break;
            //            }
            //            else
            //            {
            //                if (j == nums.Length - 1)
            //                    return;
            //            }
            //        }
            //    }
            //}

            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] == 0) {
                    int j = i;
                    while (nums[j] == 0 && j < nums.Length - 1) {
                        j++;
                    }
                    nums[i] = nums[j];
                    nums[j] = 0;
                }
            }
        }
    }
}
