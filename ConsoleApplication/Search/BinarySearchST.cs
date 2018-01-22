using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Search
{
    public class BinarySearchST<Key,Value> where Key:IComparable<Key>
    {
        private Key[] keys;
        private Value[] vals;
        private int N;
        public BinarySearchST(int capacity)
        {
        }
    }
}
