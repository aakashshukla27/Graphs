using Graphs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Traversal
{
    public class BFS
    {
        private bool[] marked; // Has bfs been called on this vertex
        private int[] edgeTo; // last vertex on known path
        private readonly int s; // source

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="G">Undirected graph</param>
        /// <param name="s">source</param>
        public BFS(UndirectedGraph G, int s)
        {
            marked = new bool[G.Vertex()];
            edgeTo = new int[G.Vertex()];
            this.s = s;
            BFSTraversal(G, s);
        }

        /// <summary>
        /// BFS 
        /// </summary>
        /// <param name="G">Graph</param>
        /// <param name="v">source vertex</param>
        private void BFSTraversal(UndirectedGraph G, int v)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(v);
            marked[v] = true;
            while (queue.Any())
            {
                v = queue.Dequeue();
                foreach(int w in G.AdjacencyList(v))
                {
                    edgeTo[w] = v;
                    marked[w] = true;
                    queue.Enqueue(w);
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
            Stack<int> stack = new Stack<int>();
            for(int x = v; x != s; x = edgeTo[x])
            {
                stack.Push(x);
            }
            stack.Push(s);
            return stack;
        }
    }
}
