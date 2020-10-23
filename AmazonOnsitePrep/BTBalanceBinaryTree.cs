using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class BTBalanceBinaryTree
    {
        public BTBalanceBinaryTree()
        {

        }

        public bool IsBalanced(TreeNode root)
        {
            return checkBalanced(root).isBalanced;
        }

        private BalanceStatusWithHeight checkBalanced(TreeNode root)
        {
            if (root == null)
                return new BalanceStatusWithHeight(true, -1);

            BalanceStatusWithHeight leftSubTree = checkBalanced(root.left);
            if (!leftSubTree.isBalanced)
                return leftSubTree;

            BalanceStatusWithHeight rightSubTree = checkBalanced(root.right);
            if (!rightSubTree.isBalanced)
                return rightSubTree;

            bool subTreeAreBalanced = Math.Abs(leftSubTree.hight - rightSubTree.hight) <= 1;
            int height = Math.Max(leftSubTree.hight, rightSubTree.hight) + 1;

            return new BalanceStatusWithHeight(subTreeAreBalanced, height);
        }
    }

    public class BalanceStatusWithHeight
    {
        public bool isBalanced;
        public int hight;
        public BalanceStatusWithHeight(bool balanced, int height)
        {
            this.isBalanced = balanced;
            this.hight = height;
        }
    }
}
