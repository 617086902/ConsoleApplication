using System;

namespace ConsoleApplication.Sort {
    /// <summary>
    /// 快速排序
    /// </summary>
    public class Quick<T> : SortTemp<T> where T : IComparable<T> {
        /// <summary>
        /// 快速排序，时间复杂度O(NlogN)，使用最广泛的排序算法
        /// </summary>
        /// <param name="arr"></param>
        public static void Sort(T[] arr) {
            Sort(arr, 0, arr.Length - 1);
        }
        private static void Sort(T[] arr, int lo, int hi) {
            //if (lo >= hi) return;
            if (hi <= lo + 10) { Insertion<T>.Sort(arr, lo, hi); return; }
            int c = Partition(arr, lo, hi);
            Sort(arr, lo, c - 1);
            Sort(arr, c + 1, hi);
        }
        private static int Partition(T[] arr, int lo, int hi) {
            int i = lo, j = hi + 1;
            var v = arr[lo];
            while (true) {
                while (Less(arr[++i], v)) if (i == hi) break;
                while (Less(v, arr[--j])) if (j == lo) break;
                if (i >= j) break;
                Exch(arr, i, j);
            }
            Exch(arr, lo, j);
            return j;
        }
    }
}
