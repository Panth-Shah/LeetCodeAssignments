using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class BTSymmatricBST
    {
        public BTSymmatricBST()
        {

        }

        public bool IsSymmetric(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var t1 = q.Dequeue();
                var t2 = q.Dequeue();
                if (t1 == null || t2 == null) return false;
                if (t1 == null && t2 == null) return true;
                if (t1.val != t2.val) return false;
                q.Enqueue(t1.left);
                q.Enqueue(t2.right);
                q.Enqueue(t1.right);
                q.Enqueue(t2.left);
            }
            return true;
        }
    }
}
