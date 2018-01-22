using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.GraphStructure
{
    /// <summary>
    /// 广度优先搜索路径
    /// </summary>
    public class BreadthFirstPaths
    {
        private bool[] marked;
        private int[] edgeTo;
        private readonly int s;
        public BreadthFirstPaths(Graph G, int s)
        {
            marked = new bool[G.V()];
            edgeTo = new int[G.V()];
            this.s = s;
            bfs(G, s);
        }
        private void bfs(Graph G, int s)
        {
            Queue<int> queue = new Queue<int>();
            marked[s] = true;
            queue.Enqueue(s);
            while (queue.Any())
            {
                int v = queue.Dequeue();
                foreach (int w in G.Adj(v))
                {
                    if (!marked[w])
                    {
                        edgeTo[w] = v;
                        marked[w] = true;
                        queue.Enqueue(w);
                    }
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
