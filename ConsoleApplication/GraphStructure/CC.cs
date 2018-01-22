using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.GraphStructure {
    /// <summary>
    /// 连通分量
    /// </summary>
    public class CC {
        private bool[] marked;
        private int[] id;
        private int count;
        public CC(Graph G) {
            marked = new bool[G.V()];
            id = new int[G.V()];
            for (var s = 0; s < G.V(); s++)
                if (!marked[s]) {
                    dfs(G, s);
                    count++;
                }
        }
        private void dfs(Graph G, int v) {
            marked[v] = true;
            id[v] = count;
            foreach (var w in G.Adj(v))
                if (!marked[w]) dfs(G, w);
        }
        /// <summary>
        /// v和w连通吗
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        public bool Connected(int v, int w) { return id[v] == id[w]; }
        /// <summary>
        /// v所在的连通分量的标识符
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public int Id(int v) { return id[v]; }
        /// <summary>
        /// 连通分量数
        /// </summary>
        /// <returns></returns>
        public int Count() { return count; }
    }
}
