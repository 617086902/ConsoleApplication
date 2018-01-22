using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Search
{
    /// <summary>
    /// 平衡二叉查找树/红黑树
    /// 优点：最优的查找和插入效率，能够进行有序性相关的操作
    /// 缺点：链接需要额外的空间
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    /// <typeparam name="Value"></typeparam>
    [DebuggerDisplay("TotalCount = {Count}")]
    public class RedBlackBST<Key, Value> where Key : IComparable<Key>
    {
        private static readonly bool RED = true;
        private static readonly bool BLACK = false;
        private Node root;
        /// <summary>
        /// 节点对象
        /// </summary>
        [DebuggerDisplay("Count = {Count}")]
        private class Node
        {
            public Key key;
            public Value value;
            public Node left, right;
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            public int N;
            public bool color;
            public int Count { get { return this.N; } }
            public Node(Key key, Value val, int N, bool color)
            {
                this.key = key;
                this.value = val;
                this.N = N;
                this.color = color;
            }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public int Count { get { return root == null ? 0 : root.N; } }

        /// <summary>
        /// 获取或设置制定Key的值。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Value this[Key key]
        {
            get { return Get(key); }
            set { Value lv = value; Put(key, lv); }
        }
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Value Get(Key key)
        {
            return Get(root, key);
        }
        private Value Get(Node x, Key key)
        {
            if (x == null) return default(Value);
            int cmp = key.CompareTo(x.key);
            if (cmp < 0) return Get(x.left, key);
            else if (cmp > 0) return Get(x.right, key);
            else return x.value;
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public void Put(Key key, Value val)
        {
            root = Put(root, key, val);
            root.color = BLACK;
        }
        private Node Put(Node h, Key key, Value val)
        {
            if (h == null) return new Node(key, val, 1, RED);
            int cmp = key.CompareTo(h.key);
            if (cmp < 0) h.left = Put(h.left, key, val);
            else if (cmp > 0) h.right = Put(h.right, key, val);
            else h.value = val;

            if (IsRed(h.right) && !IsRed(h.left)) h = RotateLeft(h);
            if (IsRed(h.left) && IsRed(h.left.left)) h = RotateRight(h);
            if (IsRed(h.left) && IsRed(h.right)) FlipColors(h);
            h.N = Size(h.left) + Size(h.right) + 1;
            return h;
        }
        private bool IsRed(Node x)
        {
            if (x == null) return false;
            return x.color == RED;
        }
        //左旋转节点的右链接
        private Node RotateLeft(Node h)
        {
            Node x = h.right;
            h.right = x.left;
            x.left = h;
            x.color = h.color;
            h.color = RED;
            x.N = h.N;
            h.N = 1 + Size(h.left) + Size(h.right);
            return x;
        }
        //右旋转节点的左链接
        private Node RotateRight(Node h)
        {
            Node x = h.left;
            h.left = x.right;
            x.right = h;
            x.color = h.color;
            h.color = RED;
            x.N = h.N;
            h.N = 1 + Size(h.left) + Size(h.right);
            return x;
        }
        //颜色转换
        private void FlipColors(Node h)
        {
            h.color = RED;
            h.left.color = BLACK;
            h.right.color = BLACK;
        }

        /// <summary>
        /// 获取节点数量
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return Size(root);
        }
        private int Size(Node x)
        {
            if (x == null) return 0;
            return x.N;
        }

        /// <summary>
        /// 返回最小键
        /// </summary>
        /// <returns></returns>
        public Key Min()
        {
            Node x = Min(root);
            return x == null ? default(Key) : x.key;
        }
        private Node Min(Node x)
        {
            if (x.left == null) return x;
            return Min(x.left);
        }

        /// <summary>
        /// 获取最大键
        /// </summary>
        /// <returns></returns>
        public Key Max()
        {
            Node x = Max(root);
            return x == null ? default(Key) : x.key;
        }
        private Node Max(Node x)
        {
            if (x.right == null) return x;
            return Max(x.right);
        }

        /// <summary>
        /// 向下取整
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Key Floor(Key key)
        {
            Node x = Floor(root, key);
            if (x == null) return default(Key);
            return x.key;
        }
        private Node Floor(Node x, Key key)
        {
            //如果节点为空返回null
            if (x == null) return null;
            int cmp = key.CompareTo(x.key);
            //如果等于，直接返回
            if (cmp == 0) return x;
            //要查找的键小于根节点，则小于他的最大节点肯定在左子树中，一直往下查
            //如果一直小于，那肯定是不存在了
            if (cmp < 0) return Floor(x.left, key);
            //大于根节点，则查右子树，依然是上面的逻辑
            Node t = Floor(x.right, key);
            //如果右边查到了就返回
            if (t != null) return t;
            //如果查不到，则最近一次向右查询的根节点就是小于目标键的最大键
            else return x;
        }

        /// <summary>
        /// 查找排名为k的键
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public Key Select(int k)
        {
            return Select(root, k).key;
        }
        private Node Select(Node x, int k)
        {
            if (x == null) return null;
            int t = Size(x.left);
            if (t > k) return Select(x.left, k);
            else if (t > k) return Select(x.right, k - t - 1);
            else return x;
        }

        /// <summary>
        /// 返回小于Key的数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Rank(Key key)
        {
            return Rank(key, root);
        }
        private int Rank(Key key, Node x)
        {
            if (x == null) return 0;
            var cmp = key.CompareTo(x.key);
            if (cmp < 0) return Rank(key, x.left);
            else if (cmp > 0) return Rank(key, x.right) + Size(x.left) + 1;
            else return Size(x.left);
        }

        /// <summary>
        /// 删除最小键所对应的键值对 --TOTHINK
        /// </summary>
        public void DeleteMin()
        {
            if (IsRed(root.left) && !IsRed(root.right))
                root.color = RED;
            root = DeleteMin(root);
            if (!IsEmpty()) root.color = BLACK;
        }
        private Node DeleteMin(Node h)
        {
            if (h.left == null) return null;
            if (!IsRed(h.left) && !IsRed(h.left.left))
                h = MoveRedLeft(h);
            h.left = DeleteMin(h.left);
            return Balance(h);
        }
        private Node MoveRedLeft(Node h)
        {
            FlipColors(h);
            if (IsRed(h.right.left))
            {
                h.right = RotateRight(h.right);
                h = RotateLeft(h);
            }
            return h;
        }
        /// <summary>
        /// 删除最大键所对应的键值对。--有问题
        /// </summary>
        public void DeleteMax()
        {
            if (!IsRed(root.left) && !IsRed(root.right))
                root.color = RED;
            root = DeleteMax(root);
            if (!IsEmpty()) root.color = BLACK;
        }
        private Node MoveRedRight(Node h)
        {
            FlipColors(h);
            if (!IsRed(h.left.left)) h = RotateRight(h);
            return h;
        }
        private Node DeleteMax(Node h)
        {
            if (IsRed(h.left)) h = RotateRight(h);
            if (h.right == null) return null;
            if (!IsRed(h.right) && !IsRed(h.right.left)) h = MoveRedRight(h);
            h.right = DeleteMax(h.right);
            return Balance(h);
        }

        /// <summary>
        /// 删除指定键对应的键值对  --TOTHINK
        /// </summary>
        /// <param name="key"></param>
        public void Delete(Key key)
        {
            if (!IsRed(root.left) && !IsRed(root.right))
                root.color = RED;
            root = Delete(root, key);
            if (!IsEmpty()) root.color = BLACK;
        }
        private Node Delete(Node h, Key key)
        {
            if (key.CompareTo(h.key) < 0)
            {
                if (!IsRed(h.left) && !IsRed(h.left.left))
                    h = MoveRedLeft(h);
                h.left = Delete(h.left, key);
            }
            else
            {
                if (IsRed(h.left)) h = RotateRight(h);
                if (key.CompareTo(h.key) == 0 && (h.right == null)) return null;
                if (!IsRed(h.right) && !IsRed(h.right.left)) h = MoveRedRight(h);
                if (key.CompareTo(h.key) == 0)
                {
                    h.value = Get(h.right, Min(h.right).key);
                    h.key = Min(h.right).key;
                    h.right = DeleteMin(h.right);
                }
                else
                    h.right = Delete(h.right, key);
            }
            return Balance(h);
        }


        private Node Balance(Node h)
        {
            if (IsRed(h.right)) h = RotateLeft(h);
            if (IsRed(h.right) && !IsRed(h.left)) h = RotateLeft(h);
            if (IsRed(h.left) && IsRed(h.left.left)) h = RotateRight(h);
            if (IsRed(h.left) && IsRed(h.right)) FlipColors(h);
            h.N = Size(h.left) + Size(h.right) + 1;
            return h;
        }
        public bool IsEmpty()
        {
            return root.N == 0;
        }
    }
}
