using System;


namespace ConsoleApplication.Collections {
    using System.Diagnostics;

    //大顶堆优先队列的调试器显示代理。为了在调试时只显示集合元素，不展示私有变量和属性等信息。
    internal sealed class MaxPQDebugView<T> {
        private MaxPQ<T> maxpq;
        public MaxPQDebugView(MaxPQ<T> maxpq) {
            if (maxpq == null) throw new ArgumentNullException("collection");
            this.maxpq = maxpq;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public T[] Items {
            get {
                T[] temp = new T[maxpq.Count];
                for (var i = 0; i < maxpq.Count; i++) {
                    temp[i] = maxpq[i];
                }
                return temp;
            }
        }
    }
    internal sealed class MinPQDebugView<T> {
        private MinPQ<T> minpq;
        public MinPQDebugView(MinPQ<T> minpq) {
            if (minpq == null) throw new ArgumentNullException("collection");
            this.minpq = minpq;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public T[] Items {
            get {
                T[] temp = new T[minpq.Count];
                for (var i = 0; i < minpq.Count; i++) {
                    temp[i] = minpq[i];
                }
                return temp;
            }
        }
    }
}
