using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Collections {
    /// <summary>
    /// 索引优先队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class IndexMinPQ<T> where T : IComparable<T> {
        private int N;
        private int[] pq;//索引二叉堆从1开始
        private int[] qp;//逆序,qp[pq[i]]=pq[qp[i]]=i
        private T[] keys;//有优先级之分的元素
        public IndexMinPQ(int maxN) {
            keys = new T[maxN];
            pq = new int[maxN + 1];
            qp = new int[maxN + 1];
            for (int i = 0; i <= maxN; i++) qp[i] = -1;
        }
        public bool IsEmpty() { return N == 0; }
        public bool Contains(int k) { return qp[k] != -1; }
        public void Insert(int k, T key) {
            N++;
            pq[N] = k;
            qp[k] = N;
            keys[k] = key;
            Swim(N);
        }

        private bool LessCompare(int i, int j) {
            return keys[pq[i]].CompareTo(keys[pq[j]]) < 0;
        }

        private void Swim(int i) {
            while (i > 1 && LessCompare(i, Parent(i))) {
                Swap(i, Parent(i));
                i = Parent(i);
            }
        }

        private int Parent(int i) {
            return i / 2;
        }
        private int YoungChild(int i) {
            return 2 * i;
        }
        private int OldChild(int i) {
            return YoungChild(i) + 1;
        }

        private void Swap(int i, int j) {
            T temp = keys[pq[i]];
            keys[pq[i]] = keys[pq[j]];
            keys[pq[j]] = temp;
        }

        public T Min() { return keys[pq[1]]; }

        public int DelMin() {
            int indexOfMin = pq[1];
            Swap(1, N--);
            Sink(1);
            keys[pq[N + 1]] = default(T);
            qp[pq[N + 1]] = -1;
            return indexOfMin;
        }

        private void Sink(int k) {
            while (YoungChild(k) <= N) {
                var j = YoungChild(k);
                if (j < N && LessCompare(OldChild(k), YoungChild(k)))
                    j = OldChild(k);
                if (LessCompare(k, j)) break;
                Swap(k, j);
                k = j;
            }
        }

        public int MinIndex() { return pq[1]; }
        public void Change(int k, T key) {
            keys[k] = key;
            Swim(qp[k]);
            Sink(qp[k]);
        }
        public void Delete(int k) {
            int index = qp[k];
            Swap(index, N--);
            Swim(index);
            Sink(index);
            keys[k] = default(T);
            qp[k] = -1;
        }
    }
}
