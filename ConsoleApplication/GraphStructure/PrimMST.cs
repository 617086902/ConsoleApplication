using ConsoleApplication.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.GraphStructure {
    /// <summary>
    /// 最小生成树的Prim算法（即时版本）
    /// </summary>
    public class PrimMST {
        private Edge[] edgeTo;//距离树最近的边
        private double[] distTo;//distTo[w]=edgeTo[w].weight()
        private bool[] marked;//如果v在树中则为true
        private MinPQ<double> pq;//有效的横切边
        public PrimMST(EdgeWeightedGraph G) {
            edgeTo = new Edge[G.V()];
            distTo = new double[G.V()];
            marked = new bool[G.V()];
            for (int v = 0; v < G.V(); v++)
                distTo[v] = double.PositiveInfinity;
            pq = new MinPQ<double>();
            distTo[0] = 0.0;
            pq.Add(0);
        }
    }
}
