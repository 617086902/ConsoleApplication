using ConsoleApplication.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.GraphStructure {
    /// <summary>
    /// 加权有向图
    /// </summary>
    public class EdgeWeightedDigraph {
        private readonly int v;//顶点总数
        private int e;//边的总数
        private Bag<DirectedEdge>[] adj;//邻接表
        public EdgeWeightedDigraph(int v) {
            this.v = v;
            this.e = 0;
            adj = new Bag<DirectedEdge>[v];
            for (int i = 0; i < v; i++)
                adj[i] = new Bag<DirectedEdge>();
        }

        public int V() { return v; }
        public int E() { return e; }
        public void AddEdge(DirectedEdge e) {
            adj[e.From()].Add(e);
            this.e++;
        }
        public IEnumerable<DirectedEdge> Adj(int v) { return adj[v]; }
        public IEnumerable<DirectedEdge> Edges() {
            Bag<DirectedEdge> bag = new Bag<DirectedEdge>();
            for (int v = 0; v < this.v; v++) {
                foreach (DirectedEdge e in adj[v])
                    bag.Add(e);
            }
            return bag;
        }
    }
}
