using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class WallsAndGateProblem
    {
        private const int EMPTY = int.MaxValue;
        private const int GATE = 0;
        private List<int[]> DIRECTIONS = new List<int[]>()
        {
            new int[] { 1,  0},
            new int[] {-1,  0},
            new int[] { 0,  1},
            new int[] { 0, -1}
        };

        public void WallsAndGates(int[][] rooms)
        {
            Queue<int[]> q = new Queue<int[]>();

            for (int i = 0; i < rooms.Length; i++)
            {
                //Inner parse through each element array
                for (int j = 0; j < rooms[i].Length; j++)
                {
                    //Add all the rotten oranges in queue
                    if (rooms[i][j] == GATE)
                    {
                        q.Enqueue(new int[] { i, j});
                    }
                }
            }

            while (q.Count > 0)
            {
                int[] vertex = q.Dequeue();
                int row = vertex[0];
                int column = vertex[1];

                foreach (int[] direction in DIRECTIONS)
                {
                    int r = row + direction[0];
                    int c = column + direction[1];

                    if (r < 0|| c < 0 || r >= rooms.Length || c >= rooms[0].Length || rooms[r][c] != EMPTY)
                    {
                        continue;
                    }

                    rooms[r][c] = rooms[row][column] + 1;
                    q.Enqueue(new int[] { r, c}) ;
                }

            }
        }
    }
}
