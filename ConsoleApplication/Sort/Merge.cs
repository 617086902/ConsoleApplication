using System;
namespace ConsoleApplication.Sort {
    public class Merge<T> : SortTemp<T> where T : IComparable<T> {
        private static T[] aux;

        /// <summary>
        /// 归并排序
        /// </summary>
        /// <param name="arr"></param>
        public static void Sort(T[] arr) {
            aux = new T[arr.Length];
            sort(arr, 0, arr.Length - 1);
        }
        private static void sort(T[] arr, int lo, int hi) {//将数组a[lo,hi]排序
            if (lo >= hi) return;
            int mid = lo + (hi - lo) / 2;
            sort(arr, lo, mid);
            sort(arr, mid + 1, hi);
            if (!Less(arr[mid], arr[mid + 1]))//测试数组是否已经有序
                merge(arr, lo, mid, hi);
        }
        private static void merge(T[] arr, int lo, int mid, int hi) {//合并
            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++)
                aux[k] = arr[k];
            for (var k = lo; k <= hi; k++) {
                if (i > mid) arr[k] = aux[j++];
                else if (j > hi) arr[k] = aux[i++];
                else if (Less(aux[j], aux[i])) arr[k] = aux[j++];
                else arr[k] = aux[i++];
            }
        }
    }
}
