using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.GraphStructure {
    /// <summary>
    /// 有向图中的环
    /// 通过递归调用dfs()方法，添加一个bool型的数组onStack[]来保存递归调用期间栈上的所有顶点
    /// 当找到一条边v-w且w在栈中时，它就找到一个有向环
    /// </summary>
    public class DirectedCycle {
        private bool[] marked;
        private int[] edgeTo;
        private Stack<int> cycle;//有向环中的所有的顶点（如果存在）
        private bool[] onStack;//递归调用的栈上的所有定点
        public DirectedCycle(Digraph G) {
            onStack = new bool[G.V()];
            edgeTo = new int[G.V()];
            marked = new bool[G.V()];
            for (int v = 0; v < G.V(); v++)
                if (!marked[v]) dfs(G, v);
        }
        private void dfs(Digraph G,int v) {
            onStack[v] = true;
            marked[v] = true;
            foreach(var w in G.Adj(v)) {
                if (HasCycle()) return;
                else if (!marked[w]) {
                    edgeTo[w] = v;
                    dfs(G, w);
                }else if (onStack[w]) {
                    cycle = new Stack<int>();
                    for (int x = v; x != w; x = edgeTo[x])
                        cycle.Push(x);
                    cycle.Push(w);
                    cycle.Push(v);
                }
            }
                onStack[v] = false;
        }
        public bool HasCycle() { return cycle != null; }
        public Stack<int> Cycle() { return cycle; }
    }
}
