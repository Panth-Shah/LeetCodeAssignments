using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class PathToMaximumGold
    {
        private HashSet<List<int>> seen = new HashSet<List<int>>();
        public PathToMaximumGold()
        {

        }

        public int GetMaximumGold(int[][] grid)
        {
            int r = grid.Length;
            int c = grid[0].Length;
            int max = int.MinValue;

            for (int i = 0; i < r; i ++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (grid[i][j] != 0)
                    {
                        int temp = getGold(grid, i, j);
                        seen.Clear();
                        if (temp > max)
                        {
                            max = temp;
                        }
                    }

                }
            }

            return max;
        }
        private int getGold(int[][] grid, int i, int j)
        {
            List<int> temp = new List<int>();
            temp.Add(i);
            temp.Add(j);

            if (seen.Contains(temp))
            {
                return 0;
            }

            seen.Add(temp);

            if (i >= grid.Length || j >= grid[0].Length || i < 0 || j < 0)
            {
                return 0;
            }

            if (grid[i][j] == 0)
            {
                return 0;
            }

            int u = grid[i][j] + getGold(grid, i-1, j);
            int d = grid[i][j] + getGold(grid, i+1, j);
            int l = grid[i][j] + getGold(grid, i, j-1);
            int ri = grid[i][j] + getGold(grid, i, j+1);

            seen.Remove(temp);
            return Math.Max(Math.Max(Math.Max(u,d),l),ri);

        }

    }
}
