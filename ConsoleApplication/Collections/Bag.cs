using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication.Collections
{
    public class Bag<T> : IEnumerable<T>
    {
        private Node first;
        private int N;
        public Bag() { N = 0; }
        private class Node
        {
            public T item;
            public Node next;
        }
        public void Add(T item)
        {
            Node oldFirst = first;
            first = new Node();
            first.item = item;
            first.next = oldFirst;
            N++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            T[] arr = new T[N];
            Node current = first;
            int i = 0;
            while (current != null)
            {
                arr[i] = current.item;
                current = current.next;
                i++;
            }
            return arr.Take(N).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
