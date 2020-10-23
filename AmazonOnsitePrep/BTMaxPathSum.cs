using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class BTMaxPathSum
    {
        int maxSum = int.MaxValue;

        public BTMaxPathSum()
        {

        }
        //Time complaxity: O(N)
        //Space Complaxity: O(log(N)); we will keep a recursion stack of the size of the heigh of tree
        //which is O(logN) for the BT
        public int MaxPathSum(TreeNode root)
        {
            max_gain(root);
            return maxSum;
        }

        public int max_gain(TreeNode node)
        {
            if (node == null)
                return 0;
            //max sum on left and right subtree of node
            int left_gain = Math.Max(max_gain(node.left), 0);
            int right_gain = Math.Max(max_gain(node.right), 0);

            //This price to start a new path where 'node' is highest node
            int price_newpath = node.val + left_gain + right_gain;

            //update max_sum with price_newpath
            maxSum = Math.Max(maxSum, price_newpath);

            //for recursion
            //return the max gain if continue the same path
            return node.val + Math.Max(left_gain, right_gain);
        }

    }
}
