using Graphs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.ConnectedComponents
{
    public class ConnectedComponents
    {
        /// <summary>
        /// array to keep track if vertex is already visited
        /// </summary>
        private bool[] marked;
        /// <summary>
        /// component number to which the vertex belongs
        /// </summary>
        private int[] id;
        /// <summary>
        /// number of components
        /// </summary>
        private int count;

        /// <summary>
        /// constructor for connected component class
        /// </summary>
        /// <param name="G">Undirected graph</param>
        public ConnectedComponents(UndirectedGraph G)
        {
            // make array based on number of vertices
            marked = new bool[G.Vertex()];
            id = new int[G.Vertex()];

            // dfs on every vertex till we encounter marked vertex
            for(int i=0; i<G.Vertex(); i++)
            {
                if (!marked[i])
                {
                    DepthFirstSearch(G, i);
                    // increase component number for every dfs from main logic
                    count++;
                }

            }

        }

        /// <summary>
        /// This function does the dfs traversal on the graph
        /// </summary>
        /// <param name="G">Undirected graph</param>
        /// <param name="v">source vertex from where to do dfs</param>
        private void DepthFirstSearch(UndirectedGraph G, int v)
        {
            // mark the current vertex as visited and assign id to it
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

        /// <summary>
        /// check if two vertex are connected
        /// </summary>
        /// <param name="v">vertex 1</param>
        /// <param name="w">vertex 2</param>
        /// <returns> boolean indicating 2 vertices are connected</returns>
        public bool Connected(int v, int w) => id[v] == id[w];

        /// <summary>
        /// returns the component number a vertex belongs to
        /// </summary>
        /// <param name="i"></param>
        /// <returns>bool indicating 2 vertices are connected</returns>
        public int ComponentNumber(int i) => id[i];

        /// <summary>
        /// numbe rof components
        /// </summary>
        /// <returns>number of components</returns>
        public int Count() => count;
    }
}
