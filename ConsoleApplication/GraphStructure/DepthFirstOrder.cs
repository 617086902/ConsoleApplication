using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.GraphStructure {
    /// <summary>
    /// 有向图中基于深度优先搜索的顶点排序
    /// </summary>
    public class DepthFirstOrder {
        private bool[] marked;
        private Queue<int> pre;//所有顶点的前序排列
        private Queue<int> post;//所有顶点的后序排列
        private Stack<int> reversePost;//所有定点的逆后序排列
        public DepthFirstOrder(Digraph G) {
            pre = new Queue<int>();
            post = new Queue<int>();
            reversePost = new Stack<int>();
            marked = new bool[G.V()];
            for (int v = 0; v < G.V(); v++)
                if (!marked[v]) dfs(G, v);
        }
        private void dfs(Digraph G,int v) {
            pre.Enqueue(v);
            marked[v] = true;
            foreach (var w in G.Adj(v))
                if (!marked[w]) dfs(G, v);
            post.Enqueue(v);
            reversePost.Push(v);
        }
        public Queue<int> Pre() { return pre; }
        public Queue<int> Post() { return post; }
        public Stack<int> ReversePost() { return reversePost; }
    }
}
