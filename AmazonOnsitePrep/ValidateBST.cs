using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class ValidateBST
    {
        public ValidateBST()
        {

        }
        public bool IsValidBST(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            double inorder = -Double.MaxValue;
            while (stack.Count > 0 || root != null)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                root = stack.Pop();
                //If next element in inorder travsersal is smaller
                //than the previous one that's not BST
                if (root.val <= inorder)
                    return false;
                inorder = root.val;
                root = root.right;
            }
            return true;
        }
    }
}
