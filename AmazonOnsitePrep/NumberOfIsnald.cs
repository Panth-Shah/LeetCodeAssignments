using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class NumberOfIsnald
    {
        public NumberOfIsnald()
        {

        }

        public int NumberOfIsland(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;
            int rowCount = grid.Length;
            int columnCount = grid[0].Length;

            int num_island = 0;

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        ++num_island;
                        Queue<element> neighbours = new Queue<element>();
                        neighbours.Enqueue(new element(i, j, true));

                        while (neighbours.Count > 0)
                        {
                            int rootCount = neighbours.Count();

                            for (int x = 0; x < rootCount; x ++)
                            {
                                var node = neighbours.Dequeue();

                                if (isIsland(grid, node.elementX + 1, node.elementY))
                                {
                                    neighbours.Enqueue(new element(node.elementX + 1, node.elementY, true));
                                }
                                if (isIsland(grid, node.elementX + 1, node.elementY))
                                {
                                    neighbours.Enqueue(new element(node.elementX, node.elementY + 1, true));
                                }
                                if (isIsland(grid, node.elementX, node.elementY + 1))
                                {
                                    neighbours.Enqueue(new element(node.elementX - 1, node.elementY, true));
                                }
                                if (isIsland(grid, node.elementX - 1, node.elementY))
                                {
                                    neighbours.Enqueue(new element(node.elementX - 1, node.elementY, true));
                                }
                            }
                        }
                    }
                }
            }

            return num_island;
        }

        private bool isIsland(char[][] grid, int x, int y)
        {
            //Only consider island if adjecent vertices are land and not water
            if (x >= 0 && x < grid.Length && y >= 0 && y < grid[x].Length && grid[x][y] == 1)
            {
                grid[x][y] = '0';
                return true;
            }
            return false;
        }
    }

    public class element
    {
        public int elementX;
        public int elementY;
        public bool isVisited;

        public element(int x, int y, bool visited)
        {
            this.elementX = x;
            this.elementY = y;
            this.isVisited = visited;
            isVisited = false;
        } 
    }
}
