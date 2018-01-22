using System;
using System.Diagnostics;

namespace ConsoleApplication.Collections
{
    /// <summary>
    /// 基于堆的优先队列的简单版本
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PQTest<T> where T : IComparable<T>
    {
        private T[] pq;
        private int N = 0;

        /// <summary>
        /// 创建包含指定容量大小的优先队列
        /// </summary>
        /// <param name="maxN"></param>
        public PQTest(int maxN)
        {
            pq = new T[maxN + 1];
        }

        /// <summary>
        /// 判断是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() { return N == 0; }

        /// <summary>
        /// 返回元素数
        /// </summary>
        /// <returns></returns>
        public int Count() { return N; }

        /// <summary>
        /// 插入元素
        /// </summary>
        /// <param name="item"></param>
        public void Insert(T item)
        {
            pq[++N] = item;
            Swim(N);
        }

        /// <summary>
        /// 删除并返回最大元素
        /// </summary>
        /// <returns></returns>
        public T DelMax()
        {
            T max = pq[1];
            Exch(1, N--);
            pq[N + 1] = default(T);
            Sink(1);
            return max;
        }

        //元素比较
        private bool Less(int i, int j) { return pq[i].CompareTo(pq[j]) < 0; }

        //交换元素
        private void Exch(int i, int j) { T t = pq[i]; pq[i] = pq[j]; pq[j] = t; }

        //元素上浮
        private void Swim(int k)
        {
            while (k > 1 && Less(k / 2, k))
            {
                Exch(k / 2, k);
                k = k / 2;
            }
        }

        //元素下沉
        private void Sink(int k)
        {
            while (2 * k <= N)
            {
                int j = 2 * k;
                if (j < N && Less(j, j + 1)) j++;
                if (!Less(k, j)) break;
                Exch(k, j);
                k = j;
            }
        }
    }
}
