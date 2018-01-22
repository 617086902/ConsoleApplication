using ConsoleApplication.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.GraphStructure {
    /// <summary>
    /// 有向图
    /// </summary>
    public class Digraph {
        //定点
        private readonly int _v;
        //边
        private int _e;

        private Bag<int>[] adj;
        public Digraph(int v) {
            this._v = v;
            this._e = 0;
            adj = new Bag<int>[v];
            for (var i = 0; i < v; i++) {
                adj[i] = new Bag<int>();
            }
        }
        public int V() { return _v; }
        public int E() { return _e; }
        public void AddEdge(int v, int w) {
            adj[v].Add(w);
            _e++;
        }
        public Bag<int> Adj(int v) { return adj[v]; }

        /// <summary>
        /// 反转
        /// </summary>
        /// <returns></returns>
        public Digraph Reverse() {
            Digraph R = new Digraph(_v);
            for (int v = 0; v < _v; v++)
                foreach (var w in Adj(v))
                    R.AddEdge(w, v);
            return R;
        }
    }
}
