using Graphs.Base;
using Graphs.Traversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.ConnectedComponents
{
    public class StronglyConnectedComponents
    {
        private bool[] marked;
        private int[] id;
        private int count = 0;

        public StronglyConnectedComponents(DirectedGraph G)
        {
            marked = new bool[G.Vertex()];
            id = new int[G.Vertex()];
            DepthFirstOrder depthFirstOrder = new DepthFirstOrder(G);
            var temp = depthFirstOrder.ReversePost();
            foreach(int v in temp)
            {
                if (!marked[v])
                {
                    DepthFirstSearch(G, v);
                    count++;
                }
            }
        }

        private void DepthFirstSearch(DirectedGraph G, int v)
        {
            marked[v] = true;
            id[v] = count;
            foreach(int w in G.AdjacencyList(v))
            {
                if (!marked[w])
                {
                    DepthFirstSearch(G, w);
                }
            }
        }

        public bool StronglyConnected(int v, int w) => id[v] == id[w];
        public int ComponentId(int v) => id[v];
        public int ComponentCount() => count;
    }
}
