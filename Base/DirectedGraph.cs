using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Base
{
    public class DirectedGraph
    {
        /// <summary>
        /// number of vertices
        /// </summary>
        private readonly int V;
        /// <summary>
        /// number of edges
        /// </summary>
        private int E;
        /// <summary>
        /// array of linkedlist representing adjacency list
        /// </summary>
        private LinkedList<int>[] adj;
        
        public DirectedGraph(int V)
        {
            this.V = V;
            this.E = 0;
            this.adj = new LinkedList<int>[V];
            for(int i = 0; i < V; i++)
            {
                adj[i] = new LinkedList<int>();
            }
        }

        /// <summary>
        /// add an edge to the graph
        /// </summary>
        /// <param name="v">starting vertex</param>
        /// <param name="w">ending vertex</param>
        public void AddEdge(int v, int w)
        {
            adj[v].AddLast(w);
            E++;
        }

        /// <summary>
        /// Vertex Count
        /// </summary>
        /// <returns>Number of vertices</returns>
        public int Vertex() => V;
        /// <summary>
        /// Edge Count
        /// </summary>
        /// <returns>Number of edges</returns>
        public int Edge() => E;

        /// <summary>
        /// calculates degree of a vertex
        /// </summary>
        /// <param name="v">vertex number</param>
        /// <returns>degree of the vertex</returns>
        public int Degree(int v)
        {
            int count = 0;
            foreach(int w in adj[v])
            {
                count++;
            }
            return count;
        }

        /// <summary>
        /// reverses a graph 
        /// </summary>
        /// <param name="G">input graph</param>
        /// <returns>reversed graph</returns>
        public DirectedGraph ReverseGraph(DirectedGraph G)
        {
            DirectedGraph r = new DirectedGraph(V);
            for(int i =0; i< V; i++)
            {
                foreach(int w in adj[i])
                {
                    r.AddEdge(w, i);
                }
            }
            return r;
        }
    }
}
