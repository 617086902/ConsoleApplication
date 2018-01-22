using System;

namespace ConsoleApplication.Sort {
    /// <summary>
    /// 希尔排序
    /// </summary>
    public class ShellSort<T> : SortTemp<T> where T : IComparable<T> {
        /// <summary>
        /// 希尔排序，基于插入排序的排序算法
        /// </summary>
        /// <param name="arr"></param>
        public static void Sort(T[] arr) {
            int n = arr.Length;
            var h = 1;
            while (h < n / 3) h = 3 * h + 1;
            while (h >= 1) {
                for (var i = h; i < n; i++) {
                    for (var j = i; j >= h && Less(arr[j], arr[j - h]); j -= h)
                        Exch(arr, j, j - h);
                }
                h = h / 3;
            }
        }
    }
}
