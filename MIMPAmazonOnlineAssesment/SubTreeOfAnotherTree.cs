using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class SubTreeOfAnotherTree
    {
        /**
         * Definition for a binary tree node.
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int x) { val = x; }
         * }
         */
        public SubTreeOfAnotherTree()
        {

        }

        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            //We are building traverse(s,t) method to take each node as a root node of subtree and then comparing root node of s with
            //root node of t using equal(x,y) method, if equal, it will compare all the other nodes of subtree with root node x & y

            return traverse(s, t);
        }

        public bool equals(TreeNode x, TreeNode y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;
            return x.val == y.val && equals(x.left, y.left) && equals(x.right, y.right);
        }

        public bool traverse(TreeNode s, TreeNode t)
        {
           return s != null && (equals(s, t) || traverse(s.left, t) || traverse(s.right, t));
        }

    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x)
        {
            val = x;
        }
    }


}
