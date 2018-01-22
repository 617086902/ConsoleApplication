using System;

namespace ConsoleApplication.Sort {
    /// <summary>
    /// 插入排序
    /// </summary>
    public class Insertion<T> : SortTemp<T> where T : IComparable<T> {

        /// <summary>
        /// 插入排序，在大部分数字的顺序都是正确的时候，可能是所有排序方法中效率最高的
        /// </summary>
        /// <param name="arr"></param>
        public static void Sort(T[] arr) {
            int n = arr.Length;
            for (var i = 0; i < n; i++) {
                for (var j = i; j > 0 && Less(arr[j], arr[j - 1]); j--)
                    Exch(arr, j, j - 1);
            }
        }
        public static void Sort(T[] arr, int lo, int hi) {
            for (var i = lo; i <= hi; i++) {
                for (var j = i; j > lo && Less(arr[j], arr[j - 1]); j--)
                    Exch(arr, j, j - 1);
            }
        }
    }
}
