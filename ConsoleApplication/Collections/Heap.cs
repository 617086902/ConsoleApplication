using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Collections {
    [DebuggerDisplay("Count = {Count}")]
    [Serializable]
    public abstract class Heap<T> : IEnumerable<T> {
        #region 变量
        private const int InitCapacity = 0;//初始容量
        private const int MiniGrow = 1;//最小增长

        static readonly T[] _emptyArray = new T[InitCapacity];
        private int _capacity = InitCapacity;
        private T[] _heap = _emptyArray;
        private int _n = 0;
        #endregion

        #region 属性
        /// <summary>
        /// 获取元素数量
        /// </summary>
        public int Count { get { return _n; } }
        /// <summary>
        /// 容量
        /// </summary>
        public int Capacity { get { return _capacity; } }
        /// <summary>
        /// 是否只读
        /// </summary>
        public bool IsReadOnly { get { return false; } }

        protected Comparer<T> Comparer { get; private set; }

        protected abstract bool Compare(T x, T y);
        #endregion

        #region 构造函数
        protected Heap() : this(Comparer<T>.Default) { }
        protected Heap(Comparer<T> comparer) : this(Enumerable.Empty<T>(), comparer) { }
        protected Heap(IEnumerable<T> collection) : this(collection, Comparer<T>.Default) { }
        protected Heap(IEnumerable<T> collection, Comparer<T> comparer) {
            if (collection == null) throw new ArgumentNullException("collection error");
            if (comparer == null) throw new ArgumentNullException("comparer error");
            Comparer = comparer;
            foreach (var item in collection)
                Add(item);
        }
        #endregion

        #region 公开方法
        /// <summary>
        /// 获取或设置位于指定索引处的元素。
        /// </summary>
        /// <param name="index">要获得或设置的元素从0开始的索引</param>
        /// <returns></returns>
        public T this[int index] {
            get { return _heap[index]; }

            set {
                if (index > _n) throw new IndexOutOfRangeException("索引超出容量长度。");
                _heap[index] = value;
                Swim(index);
                Sink(index);
            }
        }

        /// <summary>
        /// 返回位于Heap<T>顶部的元素。
        /// </summary>
        /// <returns></returns>
        public T GetTop() {
            if (Count == 0) throw new InvalidOperationException("堆为空");
            return _heap[0];
        }

        /// <summary>
        /// 移除并返回位于Heap<T>顶部的元素。
        /// </summary>
        /// <returns></returns>
        public T DelTop() {
            if (Count == 0) throw new InvalidOperationException("堆为空");
            T item = _heap[0];
            Swap(0, _n--);
            _heap[_n + 1] = default(T);
            Sink(0);
            return item;
        }

        /// <summary>
        /// 将对象添加到Heap<T>的结尾处。
        /// </summary>
        /// <param name="item">要添加到Heap<T>末尾处的对象。对于引用类型，该值可以为nul。</param>
        public void Add(T item) {
            if (_n == _capacity)
                Resize(_n * 2);
            _heap[_n++] = item;
            Swim(_n - 1);
        }

        /// <summary>
        /// 确定某元素是否在Heap<T>中。
        /// </summary>
        /// <param name="item">要在Heap<T>中定位的对象。</param>
        /// <returns></returns>
        public bool Contains(T item) {
            return _heap.Contains(item);
        }

        /// <summary>
        /// 确定Heap<T>是否为空。
        /// </summary>
        public bool IsEmpty() {
            return _n == 0;
        }

        #endregion

        #region 私有方法

        private void Resize(int max = 0) {
            if (max == 0) max = _capacity + MiniGrow;
            T[] temp = new T[max];
            for (int i = 0; i < _n; i++)
                temp[i] = _heap[i];
            _capacity = max;
            _heap = temp;
        }
        private void Swim(int i) {
            while (i > 0 && Compare(_heap[i], _heap[Parent(i)])) {
                Swap(i, Parent(i));
                i = Parent(i);
            }
        }
        private void Sink(int k) {
            while (YoungChild(k) <= _n) {
                var j = YoungChild(k);
                if (Compare(_heap[OldChild(k)], _heap[YoungChild(k)]))
                    j = OldChild(k);
                if (Compare(_heap[k], _heap[j])) break;
                Swap(k, j);
                k = j;
            }
        }

        private int Parent(int i) {
            return (i + 1) / 2 - 1;
        }
        private int YoungChild(int i) {
            return (i + 1) * 2 - 1;
        }
        private int OldChild(int i) {
            return YoungChild(i) + 1;
        }

        private void Swap(int i, int j) {
            T temp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = temp;
        }
        #endregion

        #region 继承接口方法实现
        public IEnumerator<T> GetEnumerator() {
            return _heap.Take(Count).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

    }

}
