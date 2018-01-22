using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApplication.Collections
{
    [DebuggerTypeProxy(typeof(MinPQDebugView<>))]
    public class MinPQ<T> : Heap<T>
    {
        public MinPQ() : this(Comparer<T>.Default) { }
        public MinPQ(Comparer<T> comparer) : base(comparer) { }
        public MinPQ(IEnumerable<T> collection) : base(collection) { }
        public MinPQ(IEnumerable<T> collection, Comparer<T> comparer) : base(collection, comparer) { }
        protected override bool Compare(T x, T y)
        {
            return Comparer.Compare(x, y) < 0;
        }
    }
}
