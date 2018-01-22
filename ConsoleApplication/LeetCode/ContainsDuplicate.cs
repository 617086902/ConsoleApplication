using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.LeetCode {
    public class ContainsDuplicate {
        public static bool Test(int[] nums) {
            if (nums.Count() <= 0) return false;
            HashSet<int> hs = new HashSet<int>();
            for (int i = 0; i < nums.Count(); i++)
                hs.Add(nums[i]);
            return hs.Count() != nums.Count();
        }
    }
}
