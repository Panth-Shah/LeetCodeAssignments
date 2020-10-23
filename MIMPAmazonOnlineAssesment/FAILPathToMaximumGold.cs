using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class FAILPathToMaximumGold
    {
        private int row;
        private int column;
        private List<Node<int>> lst = new List<Node<int>>();
        private int result = int.MinValue;
        private int[][] directions = new int[][] { new int[]{ 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };

        public FAILPathToMaximumGold()
        {

        }

        public int GetMaximumGold(int[][] grid)
        {
            row = grid.Length;
            column = grid[0].Length;
            if (grid == null || grid[0].Length == 0)
            {
                return 0;
            }

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] != 0)
                    {
                        lst.Add(new Node<int>(i, j, grid[i][j]));
                    }
                }
            }

            for (int x = 0; x < lst.Count; x++)
            {
                findMaxPath(lst[x], 0);
                lst[x].isVisited = false;
            }
            return result;
        }

        private void findMaxPath(Node<int> vertex, int currGold)
        {
            if (vertex == null || vertex.isVisited == true)
            {
                return;
            }
            result = Math.Max(result, currGold + vertex.val);
            vertex.isVisited = true;

            for (int x = 0; x < directions.Length; x++)
            {
                int[] dir = directions[x];
                var l = lst.FirstOrDefault(p => p.elementX == vertex.elementX + dir[0] && p.elementY == vertex.elementY + dir[1] 
                && p.isVisited == false);
                findMaxPath(l, currGold + vertex.val);
            }
        }
    }

    public class Node<T>
    {
        public int elementX;
        public int elementY;
        public bool isVisited;
        public T val;
        public Node(int x, int y, T value)
        {
            this.elementX = x;
            this.elementY = y;
            val = value;
            isVisited = false;
        }
    }
}
