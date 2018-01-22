using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.LeetCode {
    public class RemoveDuplicatesfromSortedList2 {
        public ListNode DeleteDuplicates(ListNode head) {
            var val = head.val;
            ListNode res = new ListNode(head.val);
            int count = 0;
            while (head.next != null) {
                if (head.next.val == val) {
                    head = head.next;
                    count++;
                } else {
                    if (count == 0) {

                    }
                }
            }

            if (head.next.val == val) {
                while (head.next != null) {
                    if (head.next.val != val) {

                        return DeleteDuplicates(head);
                    }
                }
            } else {

            }
            return null;
        }
    }
}
