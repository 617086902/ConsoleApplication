using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.GraphStructure {
    /// <summary>
    /// 有向符号图
    /// </summary>
    public class SymbolDigraph {
        private Dictionary<string, int> st;
        private string[] keys;
        private Digraph G;
        public SymbolDigraph(IEnumerable<string> list, char sp) {
            st = new Dictionary<string, int>();
            foreach (string str in list)//构造索引
            {
                string[] a = str.Split(sp);
                for (int i = 0; i < a.Length; i++)
                    if (!st.ContainsKey(a[i]))
                        st.Add(a[i], st.Count());//:st.Count()从0递增
            }
            keys = new string[st.Count()];//用来获取定点名的反向索引数组
            foreach (string name in st.Keys)
                keys[st[name]] = name;
            G = new Digraph(st.Count());
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
        public Digraph Digraph() { return G; }
    }
}
