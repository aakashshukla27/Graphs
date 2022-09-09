using Graphs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.TopologicalOrder
{
    public class DirectedCycle
    {
        private bool[] marked;
        private int[] edgeTo;
        private Stack<int> cycle;
        private bool[] onStack;

        public DirectedCycle(DirectedGraph G)
        {
            onStack = new bool[G.Vertex()];
            marked = new bool[G.Vertex()];
            edgeTo = new int[G.Vertex()];
            for(int i = 0; i < G.Vertex(); i++)
            {
                if (!marked[i])
                {
                    DepthFirstSearch(G, i);
                }
            }
        }

        /// <summary>
        /// dfs logic
        /// </summary>
        /// <param name="G">graph</param>
        /// <param name="v">vertex</param>
        private void DepthFirstSearch(DirectedGraph G, int v)
        {
            marked[v] = true;
            onStack[v] = true;
            foreach(int w in G.AdjacencyList(v))
            {
                // if cycel exists return
                if (this.hasCycle()) return;
                else if (!marked[w])
                {
                    // if !marked dfs and update the previous edge
                    edgeTo[w] = v;
                    DepthFirstSearch(G, w);
                }
                else if (onStack[w])
                {
                    cycle = new Stack<int>();
                    for(int i = v; i!= w; i++)
                    {
                        cycle.Push(i);
                    }
                    cycle.Push(w);
                    cycle.Push(v);
                }
            }
            onStack[v] = false;
        }


        public bool hasCycle() => cycle != null;
        public Stack<int> Cycle() => cycle;
    }
}
