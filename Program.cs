using Graphs.Base;
using Graphs.Traversal;
using System;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectedGraph directedGraph = new DirectedGraph(13);
            directedGraph.AddEdge(0, 1);
            directedGraph.AddEdge(0, 5);
            directedGraph.AddEdge(2, 3);
            directedGraph.AddEdge(2, 0);
            directedGraph.AddEdge(3, 2);
            directedGraph.AddEdge(3, 5);
            directedGraph.AddEdge(5, 4);
            directedGraph.AddEdge(4, 2);
            directedGraph.AddEdge(4, 3);
            directedGraph.AddEdge(6, 4);
            directedGraph.AddEdge(6, 0);
            directedGraph.AddEdge(6, 8);
            directedGraph.AddEdge(6, 9);
            directedGraph.AddEdge(7, 6);
            directedGraph.AddEdge(7, 9);
            directedGraph.AddEdge(8, 6);
            directedGraph.AddEdge(9, 10);
            directedGraph.AddEdge(9, 11);
            directedGraph.AddEdge(10, 12);
            directedGraph.AddEdge(11, 12);
            directedGraph.AddEdge(11, 4);
            directedGraph.AddEdge(12, 9);

            DirectedGraph reverseGraph = directedGraph.ReverseGraph();
            DepthFirstOrder depthFirstOrder = new DepthFirstOrder(reverseGraph);

            var reversePostOrder = depthFirstOrder.ReversePost();

        }
    }
}
