using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class BTZigZagTraversal
    {
        public BTZigZagTraversal()
        {

        }

        public IList<IList<int>> ZigZagLevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
                return result;
            Queue<TreeNode> q = new Queue<TreeNode>();
            Stack<int> stack = new Stack<int>();
            q.Enqueue(root);
            bool forward = true;
            while (q.Count > 0)
            {
                int count = q.Count;
                result.Add(new List<int>());

                for (int i = 0; i < count; i++)
                {
                    var node = q.Dequeue();
                    if (node.left != null)
                    {
                        q.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        q.Enqueue(node.right);
                    }

                    if (!forward)
                    {
                        stack.Push(node.val);
                    }
                    else
                    {
                        result.Last().Add(node.val);
                    }
                }

                if (!forward)
                {
                    while (stack.Count > 0)
                    {
                        result.Last().Add(stack.Pop());
                    }
                }

                forward = !forward;
            }

            return result;
        }
    }
}
