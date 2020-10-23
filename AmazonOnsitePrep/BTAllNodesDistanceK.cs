using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class BTAllNodesDistanceK
    {
        //Time: O(N)
        //Space: O(N)
        Dictionary<TreeNode, TreeNode> nodeToParentMap = new Dictionary<TreeNode, TreeNode>();

        public BTAllNodesDistanceK()
        {

        }

        public IList<int> DistanceK(TreeNode root, TreeNode start, int k)
        {
            //We will first perform dfs
            dfs(root, null);

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(start);

            //We counveretd tree into undirected graph
            HashSet<TreeNode> seen = new HashSet<TreeNode>();
            seen.Add(start);

            int currentLayer = 0;
            while (queue.Count > 0)
            {
                if (currentLayer == k)
                {
                    return extractLayerFromQueue(queue);
                }

                int layerSize = queue.Count();

                for (int i = 0; i < layerSize; i++)
                {
                    var element = queue.Dequeue();

                    if (element.left != null && !seen.Contains(element.left))
                    {
                        seen.Add(element);
                        queue.Enqueue(element.left);
                    }
                    if (element.right != null && !seen.Contains(element.right))
                    {
                        seen.Add(element);
                        queue.Enqueue(element.right);
                    }

                    TreeNode parentOfCurrentNode = nodeToParentMap[element];

                    if (parentOfCurrentNode != null && !seen.Contains(parentOfCurrentNode))
                    {
                        seen.Add(element);
                        queue.Enqueue(element.right);
                    }

                }

                currentLayer++;
            }

            return new List<int>();
        }

        public void dfs(TreeNode node, TreeNode par)
        {
            if (node != null)
            {
                nodeToParentMap.Add(node, par);
                dfs(node.left, node);
                dfs(node.right, node);
            }
        }

        public IList<int> extractLayerFromQueue(Queue<TreeNode> queue)
        {
            IList<int> extractedList = new List<int>();
            foreach(var ele in queue)
            {
                extractedList.Add(ele.val);
            }
            return extractedList;
        }
    }
}
