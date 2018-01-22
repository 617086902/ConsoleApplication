using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.GraphStructure {
    /// <summary>
    /// 符号图
    /// </summary>
    public class SymbolGraph {
        private Dictionary<string, int> st;
        private string[] keys;
        private Graph G;
        public SymbolGraph(IEnumerable<string> list, char sp) {
            st = new Dictionary<string, int>();
            foreach (string str in list)//构造索引
            {
                string[] a = str.Split(sp);
                for (int i = 0; i < a.Length; i++)
                    if (!st.ContainsKey(a[i]))
                        st.Add(a[i], st.Count());//:st.Count()从0递增
            }
            keys = new string[st.Count()];//用来获取顶点名的反向索引数组
            foreach (string name in st.Keys)
                keys[st[name]] = name;
            G = new Graph(st.Count());
            foreach (string str in list)//构造图
            {
                string[] a = str.Split(sp);//将每行第一个定点和该行其他定点相连
                int v = st[a[0]];
                for (int i = 1; i < a.Length; i++) {
                    G.AddEdge(v, st[a[i]]);
                }
            }
        }
        public bool Contains(string s) { return st.ContainsKey(s); }
        public int Index(string s) { return st[s]; }
        public string Name(int v) { return keys[v]; }
        public Graph Graph() { return G; }
        public Queue<string> BreadthFirstPaths(string from, string to) {
            var bfp = new BreadthFirstPaths(Graph(), Index(from));
            var path = bfp.PathTo(Index(to));
            Queue<string> queue = new Queue<string>();
            foreach (var index in path) {
                queue.Enqueue(Name(index));
            }
            return queue;
        }
    }
}
