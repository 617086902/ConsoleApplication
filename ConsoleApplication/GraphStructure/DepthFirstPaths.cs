using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.GraphStructure
{
    /// <summary>
    /// 深度优先搜索查找路径
    /// </summary>
    public class DepthFirstPaths
    {
        private bool[] marked;
        private int[] edgeTo;
        private readonly int s;
        public DepthFirstPaths(Graph G, int s)
        {
            marked = new bool[G.V()];
            edgeTo = new int[G.V()];
            this.s = s;
            dfs(G, s);
        }
        private void dfs(Graph G, int v)
        {
            marked[v] = true;
            foreach (int w in G.Adj(v))
            {
                if (!marked[w])
                {
                    edgeTo[w] = v;
                    dfs(G, w);
                }
            }
        }
        public bool HasPathTo(int v)
        {
            return marked[v];
        }
        public Stack<int> PathTo(int v)
        {
            if (!HasPathTo(v)) return null;
            Stack<int> path = new Stack<int>();
            for (int x = v; x != s; x = edgeTo[x])
                path.Push(x);
            path.Push(s);
            return path;
        }
    }
}
