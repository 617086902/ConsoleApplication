using System;

namespace ConsoleApplication.Sort
{
    /// <summary>
    /// 选择排序
    /// </summary>
    public class Selection<T> : SortTemp<T> where T :IComparable<T>
    {
        /// <summary>
        /// 选择排序，时间复杂度O(N*N)
        /// </summary>
        /// <param name="arr"></param>
        public static void Sort(T[] arr)
        {
            int n = arr.Length;
            for (var i = 0; i < n; i++)
            {
                int min = i;
                for (var j = i; j < n; j++)
                    if (Less(arr[j], arr[min]))
                        min = j;
                Exch(arr, i, min);
            }
        }
    }
}
