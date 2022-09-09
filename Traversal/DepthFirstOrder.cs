using Graphs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Traversal
{
    public class DepthFirstOrder
    {
        private bool[] marked;
        private Queue<int> pre;
        private Queue<int> post;
        private Stack<int> reversePost;

        public DepthFirstOrder(DirectedGraph G)
        {
            marked = new bool[G.Vertex()];
            pre = new Queue<int>();
            post = new Queue<int>();
            reversePost = new Stack<int>();
            for(int i=0; i<G.Vertex(); i++)
            {
                if (!marked[i])
                {
                    DepthFirstSearch(G, i);
                }
            }
        }

        private void DepthFirstSearch(DirectedGraph G, int v)
        {
            pre.Enqueue(v);
            marked[v] = true;
            foreach(int w in G.AdjacencyList(v))
            {
                if (!marked[w])
                {
                    DepthFirstSearch(G, w);
                }
            }
            post.Enqueue(v);
            reversePost.Push(v);
        }

        public Queue<int> Preorder() => pre;
        public Queue<int> PostOrder() => post;
        public Stack<int> ReversePost() => reversePost;
    }
}
