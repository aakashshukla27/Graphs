using Graphs.Base;
using Graphs.Traversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.TopologicalOrder
{
    public class TopologicalOrder
    {
        private Stack<int> reversePost;

        public TopologicalOrder(DirectedGraph G)
        {
            reversePost = new Stack<int>();
            DirectedCycle dc = new DirectedCycle(G);
            if (!dc.hasCycle())
            {
                DepthFirstOrder depthFirstOrder = new DepthFirstOrder(G);
                reversePost = depthFirstOrder.ReversePost();
            }
        }

        public Stack<int> Order() => reversePost;
        public bool IsDAG() => reversePost == null;
    }
}
