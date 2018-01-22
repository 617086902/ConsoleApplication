using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.GraphStructure {
    /// <summary>
    /// 计算强连通分量的Kosaraju算法
    /// </summary>
    public class KosarajuSCC {
        private bool[] marked;//已访问过的顶点
        private int[] id;//强连通分量的标识符
        private int count;//强连通分量数量
        public KosarajuSCC(Digraph G) {
            marked = new bool[G.V()];
            id = new int[G.V()];
            //获取有向图的反向图
            DepthFirstOrder order = new DepthFirstOrder(G.Reverse());
            //遍历反向图的逆后序顶点列表
            foreach (var s in order.ReversePost()) {
                if (!marked[s]) {
                    dfs(G, s);
                    count++;
                }
            }
        }

        private void dfs(Digraph G, int v) {
            marked[v] = true;
            id[v] = count;
            foreach (var w in G.Adj(v))
                if (!marked[w]) dfs(G, v);
        }

        public bool StrongConnected(int v, int w) { return id[v] == id[w]; }
        public int Id(int v) { return id[v]; }
        public int Count() { return count; }
    }
}
