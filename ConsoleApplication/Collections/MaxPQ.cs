using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApplication.Collections
{
    [DebuggerTypeProxy(typeof(MaxPQDebugView<>))]
    public class MaxPQ<T> : Heap<T>
    {
        public MaxPQ() : this(Comparer<T>.Default) { }
        public MaxPQ(Comparer<T> comparer) : base(comparer) { }
        public MaxPQ(IEnumerable<T> collection) : base(collection) { }
        public MaxPQ(IEnumerable<T> collection, Comparer<T> comparer) : base(collection, comparer) { }

        protected override bool Compare(T x, T y)
        {
            return Comparer.Compare(x, y) > 0;
        }
    }
}
