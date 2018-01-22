using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.GraphStructure {
    /// <summary>
    /// 拓扑排序,即所有顶点的逆后序
    /// </summary>
    public class Topological {
        public IEnumerable<int> order;//定点的拓扑顺序
        public Topological(Digraph G) {
            DirectedCycle cyclefinder = new DirectedCycle(G);
            if (!cyclefinder.HasCycle()) {
                DepthFirstOrder dfs = new DepthFirstOrder(G);
                order = dfs.ReversePost();
            }
        }
        /// <summary>
        /// 拓扑有序的所有顶点
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> Order() { return order; }
        /// <summary>
        /// G是有向无环图吗
        /// </summary>
        /// <returns></returns>
        public bool IsDAG() { return order != null; }
    }
}
