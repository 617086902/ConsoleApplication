using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Search
{
    /// <summary>
    /// 二叉查找树
    /// 优点：实现简单，能够进行有序性相关操作
    /// 缺点：没有性能上界的保证，链接需要额外的空间
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    /// <typeparam name="Value"></typeparam>
    public class BST<Key, Value> where Key : IComparable<Key>
    {
        private class Node
        {
            public Key key;
            public Value value;
            public Node left, right;
            public int N;//以该节点为根的子树中的节点总数
            public Node(Key key, Value value, int N)
            {
                this.key = key;
                this.value = value;
                this.N = N;
            }
        }
        private Node root;//根节点

        //获取节点数量
        public int Size()
        {
            return Size(root);
        }
        private int Size(Node x)
        {
            if (x == null) return 0;
            else return x.N;
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
            if (cmp > 0) return Get(x.right, key);
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
        }
        private Node Put(Node x, Key key, Value val)
        {
            if (x == null) return new Node(key, val, 1);
            int cmp = key.CompareTo(x.key);
            if (cmp < 0) x.left = Put(x.left, key, val);
            else if (cmp > 0) x.right = Put(x.right, key, val);
            else x.value = val;
            x.N = Size(x.left) + Size(x.right) + 1;
            return x;
        }

        /// <summary>
        /// 最小键
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
        /// 最大键
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
        /// 删除最小键所对应的键值对
        /// </summary>
        public void DeleteMin()
        {
            root = DeleteMin(root);
        }
        private Node DeleteMin(Node x)
        {
            if (x.left == null) return x.right;
            x.left = DeleteMin(x.left);
            x.N = Size(x.left) + Size(x.right) + 1;
            return x;
        }

        /// <summary>
        /// 删除键所对应的键值对
        /// </summary>
        /// <param name="key"></param>
        public void Delete(Key key)
        {
            root = Delete(root, key);
        }
        private Node Delete(Node x, Key key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.key);
            if (cmp < 0) x.left = Delete(x.left, key);
            else if (cmp > 0) x.right = Delete(x.right, key);
            else
            {
                if (x.right == null) return x.left;
                if (x.left == null) return x.right;
                Node t = x;
                x = Min(t.right);
                x.right = DeleteMin(t.right);
                x.left = t.left;
            }
            x.N = Size(x.left) + Size(x.right) + 1;
            return x;
        }

        /// <summary>
        /// 范围查找
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Key> Keys()
        {
            return Keys(Min(), Max());
        }

        /// <summary>
        /// 范围查找
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Key> Keys(Key lo, Key hi)
        {
            Queue<Key> queue = new Queue<Key>();
            Keys(root, queue, lo, hi);
            return queue;
        }
        //稍后详细研究
        private void Keys(Node x, Queue<Key> queue, Key lo, Key hi)
        {
            if (x == null) return;
            int cmplo = lo.CompareTo(x.key);
            int cmphi = hi.CompareTo(x.key);
            //先左子节点
            if (cmplo < 0) Keys(x.left, queue, lo, hi);
            //再根节点
            if (cmplo <= 0 && cmphi >= 0) queue.Enqueue(x.key);
            //再右子节点
            if (cmphi > 0) Keys(x.right, queue, lo, hi);
        }

    }
}
