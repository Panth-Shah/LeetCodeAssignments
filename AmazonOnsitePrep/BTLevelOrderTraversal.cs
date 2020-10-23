using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class BTLevelOrderTraversal
    {
        IList<IList<int>> result = new List<IList<int>>();

        public BTLevelOrderTraversal()
        {

        }
        //Time Complaxity: O(N)
        //Space Complaxity: O(N); To keep O/P structure which contains total N number of elements
        public IList<IList<int>> LevelOrderIterative(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
                return result;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            int level = 0;
            while (q.Count > 0)
            {
                //start from current level
                result.Add(new List<int>());
                //Number of elements in current level
                int level_length = q.Count;
                for (int i = 0; i < level_length; i++)
                {
                    TreeNode node = q.Dequeue();
                    //Fill current level
                    result[level].Add(node.val);
                    //Add child of node of current level to queue
                    if (node.left != null) q.Enqueue(node.left);
                    if (node.right != null) q.Enqueue(node.right);
                }
                //Go to next level
                level++;
            }
            return result;
        }
        //Time Complaxity = O(N)
        //Space Complaxity = O(N)
        public IList<IList<int>> LevelOrderRecursive(TreeNode root)
        {
            if (root == null)
                return result;
            helper(root,0);
            return result;
        }
        private void helper(TreeNode node, int level)
        {
            //Start current level
            if (result.Count == level)
                result.Add(new List<int>());
            //Fill current level nodes
            result[level].Add(node.val);

            //Process child of each node
            if (node.left != null)
                helper(node.left, level + 1);
            if (node.right != null)
                helper(node.right, level + 1);
        }

    }

}
