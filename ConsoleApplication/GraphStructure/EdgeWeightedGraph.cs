using ConsoleApplication.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.GraphStructure {
    /// <summary>
    /// 加权无向图的数据类型
    /// </summary>
    public class EdgeWeightedGraph {
        private readonly int _v;//顶点总数
        private int _e;//边的总数
        private Bag<Edge>[] adj;//邻接表
        public EdgeWeightedGraph(int v) {
            this._v = v;
            this._e = 0;
            adj = new Bag<Edge>[v];
            for (int i = 0; i < v; i++)
                adj[v] = new Bag<Edge>();
        }

        public int V() { return _v; }
        public int E() { return _e; }
        public void AddEdge(Edge e) {
            int v = e.Either(), w = e.Other(v);
            adj[v].Add(e);
            adj[w].Add(e);
            _e++;
        }
        public Bag<Edge> Adj(int v) { return adj[v]; }
        public Bag<Edge> Edges() {
            Bag<Edge> b = new Bag<Edge>();
            for (int v = 0; v < _v; v++)
                foreach (Edge e in adj[v])
                    //只有另一顶点比当前顶点大的时候才添加，确保边不会被重复添加
                    if (e.Other(v) > v) b.Add(e);
            return b;
        }
    }
}
