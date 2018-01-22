using ConsoleApplication.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.GraphStructure {
    /// <summary>
    /// 加权有向图最短路径
    /// 最短路径的Dijkstra算法
    /// </summary>
    public class DijkstraSP {
        private DirectedEdge[] edgeTo;
        private double[] distTo;
        private IndexMinPQ<Double> pq;
        public DijkstraSP(EdgeWeightedDigraph G, int s) {
            edgeTo = new DirectedEdge[G.V()];
            distTo = new double[G.V()];
            pq = new IndexMinPQ<double>(G.V());
            for (int v = 0; v < G.V(); v++)
                distTo[v] = double.PositiveInfinity;
            distTo[s] = 0.0;
            pq.Insert(s, 0.0);
            while (!pq.IsEmpty())
                relax(G, pq.DelMin());
        }
        //顶点的放松
        private void relax(EdgeWeightedDigraph G, int v) {
            foreach (DirectedEdge e in G.Adj(v)) {
                int w = e.To();
                if (distTo[w] > distTo[v] + e.Weight()) {
                    distTo[w] = distTo[v] + e.Weight();
                    edgeTo[w] = e;
                    if (pq.Contains(w)) pq.Change(w, distTo[w]);
                    else pq.Insert(w, distTo[w]);
                }
            }
        }
        /// <summary>
        /// 最短路径值
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public double DistTo(int v) { return distTo[v]; }
        /// <summary>
        /// 是否存在路径
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool HasPathTo(int v) { return distTo[v] < double.PositiveInfinity; }
        /// <summary>
        /// 最短路径
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public IEnumerable<DirectedEdge> PathTo(int v) {
            if (!HasPathTo(v)) return null;
            Stack<DirectedEdge> path = new Stack<DirectedEdge>();
            for (DirectedEdge e = edgeTo[v]; e != null; e = edgeTo[e.From()])
                path.Push(e);
            return path;
        }
    }
}
