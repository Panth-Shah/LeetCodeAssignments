using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class BTVerticalOrderTraversal
    {
        Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
        int vmin = 0;
        int vmax = 0;

        Queue<TreeNode> nodes = new Queue<TreeNode>();
        Queue<int> col = new Queue<int>();

        public BTVerticalOrderTraversal()
        {

        }

        //Time Complaxity: O(N)
        //Space Complaxity: O(N)
        public IList<IList<int>> verticalOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }

            nodes.Enqueue(root);
            col.Enqueue(0);
            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();
                var column = col.Dequeue();

                if (map.ContainsKey(column))
                {
                    map[column].Add(node.val);
                }
                else
                {
                    var list = new List<int>() { node.val};
                    map.Add(column, list);
                }

                if (node.left != null)
                {
                    nodes.Enqueue(node.left);
                    col.Enqueue(column - 1);
                }

                if (node.right != null)
                {
                    nodes.Enqueue(node.right);
                    col.Enqueue(column + 1);
                }
            }

            var temp = map.Keys.ToList();
            temp.Sort();
            foreach (var key in temp)
            {
                result.Add(map[key]);
            }

            return result;
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
