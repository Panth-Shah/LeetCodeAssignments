using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class SubTreeofAnotherTree
    {
        public SubTreeofAnotherTree()
        {

        }

        public bool isSubtree(TreeNode s, TreeNode t)
        {
            if (s == null && t == null)
                return true;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(s);

            while (q.Count > 0)
            {
                var node = q.Dequeue();

                if (node.val == t.val)
                {
                    if (IsSameTree(node, t))
                    {
                        return true;
                    }
                }

                if (node.left != null)
                {
                    q.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    q.Enqueue(node.right);
                }
            }

            return false;
        }

        private bool IsSameTree(TreeNode s, TreeNode t)
        {
            if (s == null && t == null)
                return true;

            if (s == null && t != null)
                return false;

            if (s != null && t == null)
                return false;

            if (s.val != t.val)
                return false;

            return IsSameTree(s.left, t.left) && IsSameTree(s.right, t.right);
        }
    }
}
