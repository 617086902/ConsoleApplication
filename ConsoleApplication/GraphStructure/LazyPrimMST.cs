using ConsoleApplication.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.GraphStructure {
    /// <summary>
    /// 最小生成树的Prim算法的延时实现
    /// </summary>
    public class LazyPrimMST {
        private bool[] marked;
        private Queue<Edge> mst;//最小生成树的边
        private MinPQ<Edge> pq;//横切边（包括失效的边）
        public LazyPrimMST(EdgeWeightedGraph G) {
            pq = new MinPQ<Edge>();
            marked = new bool[G.V()];
            mst = new Queue<Edge>();
            Visit(G, 0);//假设G是联通的
            while (!pq.IsEmpty()) {
                Edge e = pq.DelTop();//从pq中得到权重最小的边
                int v = e.Either(), w = e.Other(v);
                if (marked[v] && marked[w]) continue;
                mst.Enqueue(e);//将边添加到树中
                if (!marked[v]) Visit(G, v);//将顶点（v或w）添加到树中
                if (!marked[w]) Visit(G, w);
            }
        }

        private void Visit(EdgeWeightedGraph G,int v) {
            //标记顶点v并将所有连接v和未被标记的顶点的边加入pq
            marked[v] = true;
            foreach (Edge e in G.Adj(v))
                if (!marked[e.Other(v)]) pq.Add(e);
        }
    }
}
