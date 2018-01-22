using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Search
{
    /// <summary>
    /// 链表（顺序查询）
    /// 适用于小型问题，对于大型符号表很慢
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    /// <typeparam name="Value"></typeparam>
    public class SequentialSearchST<Key, Value>
    {
        /// <summary>
        /// 链表节点定义
        /// </summary>
        private class Node
        {
            public Key key;
            public Value value;
            public Node next;
            public Node(Key key, Value value, Node next)
            {
                this.key = key;
                this.value = value;
                this.next = next;
            }
        }
        private int N = 0;
        private Node first;//链表首节点
        /// <summary>
        /// 查找给定的键，返回相关联的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Value Get(Key key)
        {
            for (Node x = first; x != null; x = x.next)
                if (key.Equals(x.key))
                    return x.value;
            return default(Value);
        }
        /// <summary>
        /// 更新或插入键值对
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Put(Key key, Value value)
        {
            for (Node x = first; x != null; x = x.next)
            {
                if (key.Equals(x.key))
                {
                    x.value = value;
                    return;
                }
            }
            first = new Node(key, value, first);
            N++;
        }
        public void Delete(Key key)
        {
            for (Node x = first; x != null; x = x.next)
            {
                if (key.Equals(x.key))
                {
                    x.key = x.next.key;
                    x.value = x.next.value;
                    x.next = x.next.next;
                    N--;
                    return;
                }
            }
        }
        public int Size()
        {
            return N;
        }
    }
}
