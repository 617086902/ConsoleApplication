using System;

namespace ConsoleApplication.Sort
{
    public class SortTemp<T> where T : IComparable<T>
    {
        public static bool Less(T a, T b)
        {
            return a.CompareTo(b) < 0;
        }
        public static void Exch(T[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
