using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication.Collections;

namespace ConsoleApplication.GraphStructure
{
    public class Graph
    {
        private int _v;//顶点数
        private int _e;//边数
        private Bag<int>[] adj;
        public Graph(int v)
        {
            this._v = v;
            this._e = 0;
            adj = new Bag<int>[v];
            for (int i = 0; i < v; i++)
                adj[i] = new Bag<int>();
        }

        public int V() { return _v; }
        public int E() { return _e; }
        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
            adj[w].Add(v);
            _e++;
        }
        
        public System.Collections.Generic.IEnumerator<Bag<int>> GetEnumerator()
        {
            return adj.Take(_v).GetEnumerator();
        }

        public Bag<int> Adj(int v)
        {
            return adj[v];
        }
    }
}
