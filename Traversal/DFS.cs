using Graphs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphs.Traversal
{
    public class DFS
    {
        private bool[] marked; // Has dfs been called on this vertex
        private int[] edgeTo; // last vertex on known path
        private readonly int s; // source

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="G">Undirected graph</param>
        /// <param name="s">source</param>
        public DFS(UndirectedGraph G, int s)
        {
            marked = new bool[G.Vertex()];
            edgeTo = new int[G.Vertex()];
            this.s = s;
            DFSTraversal(G, s);
        }

        /// <summary>
        /// BFS 
        /// </summary>
        /// <param name="G">Graph</param>
        /// <param name="v">source vertex</param>
        private void DFSTraversal(UndirectedGraph G, int v)
        {
            marked[v] = true;
            foreach (int w in G.AdjacencyList(v))
            {
                edgeTo[w] = v;
                DFSTraversal(G, w);
            }
        }

        private void DFSIterative(UndirectedGraph G, int v)
        {
            Stack<int> stack = new();
            stack.Push(v);
            marked[v] = true;
            while (stack.Any())
            {
                v = stack.Pop();
                foreach(int w in G.AdjacencyList(v))
                {
                    edgeTo[w] = v;
                    marked[w] = true;
                    stack.Push(w);
                }
            }
        }

        /// <summary>
        /// check if path to vertex exists
        /// </summary>
        /// <param name="v">vertex</param>
        /// <returns>boolean</returns>
        public bool HasPathTo(int v) => marked[v];

        /// <summary>
        /// find the path to vertex
        /// </summary>
        /// <param name="v">vertex</param>
        /// <returns>path to vertex</returns>
        public Stack<int> PathTo(int v)
        {
            if (!HasPathTo(v)) return null;
            Stack<int> returnStack = new Stack<int>();
            for(int x = v; x != s; x = edgeTo[x])
            {
                returnStack.Push(x);
            }
            returnStack.Push(s);
            return returnStack;
        }
    }
}
