using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{

    public class TreasureIsland
    {
        private List<int[]> DIRECTIONS = new List<int[]>()
        {
        new int[] { 1, 0},
        new int[] { 0, 1},
        new int[] { -1, 0},
        new int[] { 0, -1}
        };

        public int minSteps(char[][] grid)
        {
            Queue<int[]> q = new Queue<int[]>();
            q.Enqueue(new int[] { 0, 0});
            grid[0][0] = 'D';
            for (int step = 1; q.Count > 0; step++ )
            {
                for(int sz = q.Count; sz > 0; sz --)
                {
                    var vertex = q.Dequeue();

                    foreach (int[] direct in DIRECTIONS)
                    {
                        int r = vertex[0] + direct[0];
                        int c = vertex[1] + direct[1];

                        if (isSafe(grid, r, c))
                        {
                            if(grid[r][c] == 'X')
                            {
                                return step;
                            }
                            grid[r][c] = 'D';
                            q.Enqueue(new int[] {r , c});
                        }
                    }
                }
            }

            return -1;
        }

        private bool isSafe(char[][] grid, int r, int c)
        {
            return r >= 0 && r < grid.Length && c >= 0 && c < grid[0].Length && grid[r][c] != 'D';
        }

    }
        
}
