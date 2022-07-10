using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;

namespace Graphs.Base
{
    public class UndirectedGraph
    {
        private readonly int V;  // number of vertices
        private int E;           // number of edges
        private LinkedList<int>[] adj; // adjacency list

        /// <summary>
        /// Constructor for graph class
        /// </summary>
        /// <param name="V">Number of vertices</param>
        public UndirectedGraph(int V)
        {
            this.V = V;
            this.E = 0;
            adj = new LinkedList<int>[V];
            for (int i = 0; i < V; i++)
            {
                adj[i] = new LinkedList<int>();
            }
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
        /// Add edges to graph - Parallel Edges are allowed
        /// </summary>
        /// <param name="v">starting point</param>
        /// <param name="w">ending point</param>
        public void AddEdge(int v, int w)
        {
            adj[v].AddLast(w);
            adj[w].AddLast(v);
            E++;
        }
        
        /// <summary>
        /// adjacency list of a vertex
        /// </summary>
        /// <param name="v">Vertex number</param>
        /// <returns>Adjacency List of vertex</returns>
        public LinkedList<int> AdjacencyList(int v) => adj[v];

        /// <summary>
        /// degree of a vertex
        /// </summary>
        /// <param name="v">Vertex Number</param>
        /// <returns>Returns degree of the vertex</returns>
        public int Degree(int v)
        {
            int degree = 0;
            foreach (var item in AdjacencyList(v))
            {
                degree++;
            }
            return degree;
        }
        
        /// <summary>
        /// Calculates maximum degree
        /// </summary>
        /// <returns>Maximum Degree</returns>
        public int MaxDegree()
        {
            int max = 0;
            for (int i = 0; i < V; i++)
            {
                if (Degree(i) > max) max = Degree(i);
            }
            return max;
        }
        
        /// <summary>
        /// Average degree
        /// </summary>
        /// <returns>Average degree of the graph</returns>
        public int AverageDegree() => 2 * E / V;

        /// <summary>
        /// Number of self loops
        /// </summary>
        /// <returns>total self loops in the graph</returns>
        public int NumberOfSelfLoops()
        {
            int count = 0;
            for (int i = 0; i < V; i++)
            {
                foreach (var item in AdjacencyList(i))
                {
                    if (item == i) count++;
                }
            }

            return count/2;
        }

        public void PrintGraph()
        {
            for (int i = 0; i < adj.Length; i++)
            {
                Console.WriteLine("Adjacency List of vertex " + i);
                Console.WriteLine("head");
                foreach (var item in AdjacencyList(i))
                {
                    Console.Write(" -> " + item);
                }
                Console.WriteLine();
            }
        }
        
        

    }
}