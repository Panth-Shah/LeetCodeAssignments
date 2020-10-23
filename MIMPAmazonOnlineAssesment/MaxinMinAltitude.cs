using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    //Problem Statement
  // Given a matrix with r rows and c columns, find the maximum score of a path starting at[0, 0] and ending at[r - 1, c - 1]. The score of a 
  // path is the minimum value in that path.For example, the score of the path 8 → 4 → 5 → 9 is 4.
  // Don't include the first or final entry. You can only move either down or right at any point in time.
    public class MaxinMinAltitude
    {
        public MaxinMinAltitude()
        {

        }


        // Define: dp[i,j] is the max score from [0][0] to [i][j]
        // Recurence Formula: dp[i,j] = max( min(dp[i-1,j], grid[i,j]), min(dp[i,j-1]), grid[i,j] )
        // Note: Init the first entry as Integer.MAX_VALUE

        // DP (2D)
        // Time: O(rc) Space: O(rc)
        public int MaxOfMinAltitude(int[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;
            int r = grid.Length;
            int c = grid[0].Length;

            int[,] dp = new int[grid.Length, grid[0].Length];

            //First & Last entry is not considered
            dp[0, 0] = int.MaxValue;
            dp[r - 1, c - 1] = int.MaxValue;

            //Access first column 
            for (int i = 1; i < dp.GetLength(0); i ++)
            {
                if (dp[i, 0] != int.MaxValue)
                {
                    //For first column grid, compare value from one above 
                    dp[i, 0] = Math.Min(dp[i - 1, 0], grid[i][0]);
                }

            }

            //Access first row
            for (int j = 1; j < dp.GetLength(1); j++)
            {
                if (dp[0,j] != int.MaxValue)
                {
                    //For first row, compare value from one left
                    dp[0, j] = Math.Min(dp[0, j - 1], grid[0][j]);
                }

            }

            //Access inner matrix
            for (int i = 1; i < r; i ++)
            {
                for (int j = 1; j < c; j++)
                {
                    if (i == r - 1 && j == c - 1)
                    {
                        //For last entry in matrix, it won't compare with itself and take max value from
                        //above or left
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                    else
                    {
                        //Score 1 is min value from current grid and left
                        int score1 = Math.Min(dp[i,j-1], grid[i][j]);
                        int score2 = Math.Min(dp[i - 1,j], grid[i][j]);
                        dp[i, j] = Math.Max(score1, score2);
                    }
                }
            }

            return dp[r - 1, c - 1] == int.MaxValue ? 0 : dp[r - 1, c - 1];
        }


        public int UniquePath(int m, int n)
        {
            int[,] dp = new int[m,n];

            for (int i = 0; i < m; i ++)
            {
                //First column is all 1s
                dp[i, 0] = 1;
            }

            for (int i = 0; i < n; i++)
            {
                //First row is all 1s
                dp[0, i] = 1;
            }

            //In any cell, we could have come from either above or left
            for (int i = 1; i < m; i ++)
            {
                for (int j = 1; j < n; j++)
                {
                    //In currect cell, we can only come from above or left as a possible paths
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }

            //Last grid will give us the possible paths we can get to reach top left corner to bottom right corner
            return dp[m - 1, n - 1];
        }


        //Min path sum problem solution
        public int minPathSum(int[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;

            int[,] dp = new int [grid.Length, grid[0].Length];

            for (int i = 0; i < dp.GetLength(0); i ++)
            {
                for (int j = 0; j < dp.GetLength(1); j++)
                {
                    dp[i, j] += grid[i][j];

                    //We can only move down or right
                    if (i > 0 && j > 0)
                    {
                        dp[i,j] += Math.Min(dp[i - 1, j], dp[i, j - 1]);
                    } else if (i > 0)
                    {
                        dp[i, j] += dp[i - 1,j];
                    }else if (j > 0)
                    {
                        dp[i, j] += dp[i, j - 1];
                    }
                }
            }

            //Return the value at bottom right hand corner of the array
            return dp[dp.GetLength(0) - 1, dp.GetLength(1) - 1];
        }
    }
}
