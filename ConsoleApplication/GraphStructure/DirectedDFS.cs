using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.GraphStructure {
    /// <summary>
    /// 有向图的可达性
    /// </summary>
    public class DirectedDFS {
        private bool[] marked;

        /// <summary>
        /// 在G中找到从s可达的所有定点
        /// </summary>
        /// <param name="G"></param>
        /// <param name="s"></param>
        public DirectedDFS(Digraph G, int s) {
            marked = new bool[G.V()];
            dfs(G, s);
        }

        /// <summary>
        /// 在G中找到从sources中所有顶点可达到的所有顶点
        /// </summary>
        /// <param name="G"></param>
        /// <param name="sources"></param>
        public DirectedDFS(Digraph G, IEnumerable<int> sources) {
            marked = new bool[G.V()];
            foreach (var s in sources)
                if (!marked[s]) dfs(G, s);
        }
        private void dfs(Digraph G, int v) {
            marked[v] = true;
            foreach (var w in G.Adj(v))
                if (!marked[w]) dfs(G, w);
        }
        public bool Marked(int v) { return marked[v]; }
    }
}
