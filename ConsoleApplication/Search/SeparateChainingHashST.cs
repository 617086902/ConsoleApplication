using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Search
{
    /// <summary>
    /// 基于拉链法的散列表实现
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    /// <typeparam name="Value"></typeparam>
    public class SeparateChainingHashST<Key, Value> where Key : IComparable<Key>
    {
        private int N;//键值对总数
        private int M;//散列表大小
        private SequentialSearchST<Key, Value>[] st;//存放链表对象的数组
        public SeparateChainingHashST() : this(997) { }
        public SeparateChainingHashST(int M)
        {
            this.M = M;
            st = (SequentialSearchST<Key, Value>[])new SequentialSearchST<Key, Value>[M];
            for (int i = 0; i < M; i++)
            {
                st[i] = new SequentialSearchST<Key, Value>();
            }
        }
        private int Hash(Key key)
        {
            return (key.GetHashCode() & 0x7fffffff) % M;
        }
        public Value Get(Key key)
        {
            return (Value)st[Hash(key)].Get(key);
        }
        public void Put(Key key,Value val)
        {
            st[Hash(key)].Put(key, val);
        }
        public void Delete(Key key)
        {
            st[Hash(key)].Delete(key);
        }
    }
}
