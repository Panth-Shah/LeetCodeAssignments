using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class CloneGraphcs
    {
        public CloneGraphcs()
        {

        }
        public GraphNode CloneGraph(GraphNode node)
        {
            //No start node, noi cloning
            if (node == null)
                return null;

            //Build clone Dictionary<Node, Node>
            Dictionary<GraphNode, GraphNode> cloneDict = new Dictionary<GraphNode, GraphNode>();

            //Initialize Queue for BFS
            Queue<GraphNode> q = new Queue<GraphNode>();

            //Add real node into queue to start traversal
            q.Enqueue(node);

            //Add this node to Clone Dictionary<realNode, clonedNode>
            cloneDict.Add(node, new GraphNode(node.val));
            //Perform BFS 
            while (q.Count > 0)
            {
                var element = q.Dequeue();
                //Iterate over all the neighbours          
                foreach (var neighbour in element.neighbors)
                {
                    //check if this neighbour is already cloned
                    if (!cloneDict.ContainsKey(neighbour))
                    {
                        //If not, we will give it a mapping with original node
                        //We will add this node to a queue to explore its edges later

                        cloneDict.Add(neighbour, new GraphNode(neighbour.val));
                        q.Enqueue(neighbour);
                    }

                    //Via Dictionary we built, build dependencies between
                    //current node's clone to neighbour's clone

                    cloneDict[element].neighbors.Add(cloneDict[neighbour]);
                }
            }

            //return the clone of the start. This is the entry point of the cloned graph sections
            return cloneDict[node];
        }
    }

    public class GraphNode
    {
        public int val;
        public IList<GraphNode> neighbors;

        public GraphNode()
        {
            val = 0;
            neighbors = new List<GraphNode>();
        }

        public GraphNode(int _val)
        {
            val = _val;
            neighbors = new List<GraphNode>();
        }

        public GraphNode(int _val, List<GraphNode> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
}
