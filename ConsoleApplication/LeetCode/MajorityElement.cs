using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.LeetCode {
    public class MajorityElement {
        public static int GetMajorityElement(int[] nums) {
            int count = 0, result = 0;
            for (int i = 0; i < nums.Count(); i++) {
                if (count == 0) {
                    result = nums[i];
                    count = 1;
                } else if (result == nums[i]) {
                    count++;
                } else {
                    count--;
                }
            }
            return result;
        }
    }
}
