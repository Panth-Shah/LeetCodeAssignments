using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class NumberOfIslands
    {

        public NumberOfIslands()
        {

        }

        public int NumIslands(char[][] grid)
        {
            int result = 0;

            if (grid == null || grid.Length == 0)
            {
                return result;
            }

            for (int row = 0; row < grid.Length; row ++)
            {
                for (int column = 0; column < grid[row].Length; column ++)
                {
                    if (grid[row][column] == '1')
                    {
                        result += 1;
                        IslandSearch(grid, row, column);
                    }
                }
            }

            return result;
        }

        private void IslandSearch(char[][] grid, int r, int c)
        {
            if (r < 0 || c < 0 || r >= grid.Length || c >= grid[r].Length || grid[r][c] == '0')
            {
                return;
            }

            grid[r][c] = '0'; // Mark grid element visited
            IslandSearch(grid, r - 1, c);
            IslandSearch(grid, r + 1, c);
            IslandSearch(grid, r, c - 1);
            IslandSearch(grid, r, c + 1);
        }
    }
}
