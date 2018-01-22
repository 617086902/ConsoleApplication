using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.GraphStructure {
    /// <summary>
    /// 带权重的边的数据类型
    /// </summary>
    public class Edge : IComparable<Edge> {
        private readonly int v;//顶点之一
        private readonly int w;//另一个顶点
        private readonly double weight;//边的权重
        public Edge(int v, int w, int weight) {
            this.v = v;
            this.w = w;
            this.weight = weight;
        }
        public double Weight() { return weight; }
        public int Either() { return v; }
        public int Other(int vertex) {
            if (vertex == v) return w;
            else if (vertex == w) return v;
            else throw new ArgumentException("不存在的顶点");
        }
        public int CompareTo(Edge that) {
            if (this.Weight() > that.Weight()) return 1;
            else if (this.Weight() < that.Weight()) return -1;
            else return 0;
        }
        public override string ToString() {
            return string.Format("{0}-{1} {2}", v, w, weight);
        }
    }
}
