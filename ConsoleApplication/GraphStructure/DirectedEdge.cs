using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.GraphStructure {
    /// <summary>
    /// 加权有向边
    /// </summary>
    public class DirectedEdge {
        private readonly int v;//边的起点
        private readonly int w;//边的终点
        private readonly double weight;//边的权重
        public DirectedEdge(int v, int w, int weight) {
            this.v = v;
            this.w = w;
            this.weight = weight;
        }
        public double Weight() { return weight; }
        public int From() { return v; }
        public int To() { return w; }
    }
}
