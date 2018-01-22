using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Search
{
    /// <summary>
    /// 基于线形探测法的散列表
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    /// <typeparam name="Value"></typeparam>
    public class LinearProbingHashST<Key, Value>
    {
        private int N;//符号表中键值对的总数
        private int M = 16;//线性探测表的大小
        private Key[] keys;//键
        private Value[] vals;//值
        public LinearProbingHashST(int M)
        {
            this.M = M;
            keys = (Key[])new Key[M];
            vals = (Value[])new Value[M];
        }
        private int Hash(Key key)
        {
            //key.GetHashCode() & 0x7fffffff 将32位的整数变成一个31位的非负整数
            //为什么不用Math.Abs()，因为最大的整数会返回一个负值            
            return (key.GetHashCode() & 0x7fffffff) % M;
        }
        private void Resize(int cap)
        {
            LinearProbingHashST<Key, Value> t;
            t = new LinearProbingHashST<Key, Value>(cap);
            for (int i = 0; i < M; i++)
            {
                if (keys[i] != null)
                    t.Put(keys[i], vals[i]);
            }
            keys = t.keys;
            vals = t.vals;
            M = t.M;
        }
        public void Put(Key key, Value val)
        {
            if (N > M / 2) Resize(2 * M);
            int i;
            //(i+1)%M的作用是当达到数组的最大长度时，跳到数组首位
            for (i = Hash(key); keys[i] != null; i = (i + 1) % M)
                if (keys[i].Equals(key)) { vals[i] = val; return; }
            keys[i] = key;
            vals[i] = val;
            N++;
        }
        public Value Get(Key key)
        {
            for (int i = Hash(key); keys[i] != null; i = (i + 1) % M)
                if (key.Equals(keys[i])) return vals[i];
            return default(Value);
        }
        private bool Contains(Key key)
        {
            for (int i = Hash(key); keys[i] != null; i = (i + 1) % M)
                if (key.Equals(keys[i])) return true;
            return false;
        }
        public void Delete(Key key)
        {
            if (!Contains(key)) return;
            int i = Hash(key);
            while (!key.Equals(keys[i]))
                i = (i + 1) % M;
            keys[i] = default(Key);
            vals[i] = default(Value);
            i = (i + 1) % M;
            while (keys[i] != null)
            {
                Key keyToRedo = keys[i];
                Value valToRedo = vals[i];
                keys[i] = default(Key);
                vals[i] = default(Value);
                N--;
                Put(keyToRedo, valToRedo);
                i = (i + 1) % M;
            }
            N--;
            if (N > 0 && N == M / 8) Resize(M / 2);
        }
    }
}
