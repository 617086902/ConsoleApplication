using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Sort {
    /// <summary>
    /// 堆排序
    /// </summary>
    public class Heap<T> : SortTemp<T> where T : IComparable<T> {
        /// <summary>
        /// 堆排序，时间复杂度O(NlogN)
        /// </summary>
        /// <param name="arr"></param>
        public static void Sort(T[] arr) {
            int N = arr.Length - 1;
            //对大小为1的堆跳过
            //剩下的一半依次调用Sink方法可以使最大的元素位于数组的开头
            //次大的元素在附近
            for (var k = (N + 1) / 2 - 1; k >= 0; k--)
                Sink(arr, k, N);

            //交换首尾将最大的元素位于尾部,再次调用Sink方法
            //使次大元素位于数组头部，被换过来头部元素依次下沉到合适的位置
            while (N > 0) {
                Exch(arr, 0, N--);
                Sink(arr, 0, N);
            }
        }
        private static void Sink(T[] arr, int i, int j) {
            while ((i + 1) * 2 - 1 < j) {
                var k = (i + 1) * 2 - 1;
                if (Less(arr[k], arr[k + 1])) k++;
                if (Less(arr[k], arr[i])) break;
                Exch(arr, i, k);
                i = k;
            }
            if (j == 1 && Less(arr[i], arr[j])) Exch(arr, i, j);
        }
    }
}
