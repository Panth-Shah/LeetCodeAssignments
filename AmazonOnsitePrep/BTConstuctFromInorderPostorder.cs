using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class BTConstuctFromInorderPostorder
    {
        private int[] _inorder;
        private int[] _postorder;
        Dictionary<int, int> idx_map = new Dictionary<int, int>();
        private int post_idx;

        public BTConstuctFromInorderPostorder()
        {

        }
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            //Last element of Post Order will be the root of BT
            int id = 0;
            //build dictionary value => index
            foreach (int val in inorder)
            {
                idx_map.Add(val,id++);
            }
            post_idx = inorder.Length - 1;
            this._inorder = inorder;
            this._postorder = postorder;
            return helper(0, inorder.Length - 1);
        }

        private TreeNode helper(int in_left, int in_right)
        {
            //If no element to construct subtree
            if (in_left > in_right)
                return null;
            int root_val = _postorder[post_idx];
            TreeNode root = new TreeNode(root_val);

            //root splits inorder into left and right
            int index = idx_map[root.val];
            post_idx--;
            //build right subtree
            root.right = helper(index + 1, in_right);
            //build left subtree
            root.left = helper(in_left, index - 1);

            return root;
        }
    }
}
