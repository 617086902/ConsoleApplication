using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication.Collections;

namespace ConsoleApplication.GraphStructure
{
    /// <summary>
    /// 深度优先搜索算法
    /// </summary>
    public class DepthFirstSearch
    {
        private bool[] marked;
        private int count;
        public DepthFirstSearch(Graph G, int s)
        {
            marked = new bool[G.V()];
            dfs(G, s);
        }
        private void dfs(Graph G, int v)
        {
            marked[v] = true;
            count++;
            foreach (int w in G.Adj(v))
            {
                if (!marked[w])
                    dfs(G, w);
            }
        }
        public bool Marked(int w)
        {
            return marked[w];
        }
        public int Count()
        {
            return count;
        }
    }
}
