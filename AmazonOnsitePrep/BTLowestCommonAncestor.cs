using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class BTLowestCommonAncestor
    {
        private TreeNode ans;

        public BTLowestCommonAncestor()
        {
            ans = null;
        }

        public TreeNode LCA(TreeNode root, TreeNode p, TreeNode q)
        {
            recursionTree(root, p, q);
            return ans;
        }

        private bool recursionTree(TreeNode currentNode, TreeNode x, TreeNode y)
        {
            //Base Case
            // If reached the end of a branch, return false.
            if (currentNode == null)
                return false;

            //Recursion
            //Left Recursion. If left recursion returns true, set left = 1, right = 0
            int left = recursionTree(currentNode.left, x, y) ? 1 : 0;

            //Right recursion
            int right = recursionTree(currentNode.right, x, y) ? 1 : 0;

            //Constraint
            //If current node is one of pr or qu
            int mid = (currentNode == x || currentNode == y) ? 1 : 0;

            //If any two of the flags left, right or mid become true
            if (mid + left + right >= 2)
            {
                ans = currentNode;
            }

            //Return true if any one of the three bool values is True
            return (mid + left + right > 0);
        }
    }
}
