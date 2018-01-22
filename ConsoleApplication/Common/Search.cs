namespace ConsoleApplication.Common
{
    /// <summary>
    /// 二分查找
    /// </summary>
    public class Search
    {
        /// <summary>
        /// 二分查找的非递归实现
        /// </summary>
        /// <param name="arr">数组</param>
        /// <param name="key">目标值</param>
        /// <returns></returns>
        public static int BinarySearch(int[] arr, int key)
        {
            var min = 0;
            var max = arr.Length - 1;
            while (min <= max)
            {
                var center = min + (max - min) / 2;
                if (key == arr[center]) return center;
                if (key > arr[center]) min = center + 1;
                else max = max - 1;
            }
            return -1;
        }

        /// <summary>
        /// 二分查找的递归实现
        /// </summary>
        /// <param name="arr">数组</param>
        /// <param name="key">目标值</param>
        /// <param name="min">最小下标</param>
        /// <param name="max">最大下标</param>
        /// <returns></returns>
        public static int BinarySearch(int[] arr, int key, int min, int max)
        {
            if (min > max) return -1;
            var center = min + (max - min) / 2;
            if (key == arr[center]) return center;
            return key > arr[center] ? BinarySearch(arr, key, center + 1, max) : BinarySearch(arr, key, min, center - 1);
        }
    }
}
