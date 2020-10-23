using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class RottenOranges
    {
        //ProblemStatement:
        //Given a 2D grid, each cell is either a zombie 1 or a human 0. Zombies can turn adjacent(up/down/left/right) human beings 
        //into zombies every hour.Find out how many hours does it take to infect all humans?

        //Solution:
        //We will be using BFS algorithm here for the solution
        public RottenOranges()
        {

        }

        public int OrangesRotting(int[][] grid)
        {
            if (grid.Length == 0 || grid == null)
                return -1;
            //Initialize queue
            Queue<Element> q = new Queue<Element>();

            //Outer parse through array of arrays
            for (int i = 0; i < grid.Length; i++)
            {
                //Inner parse through each element array
                for (int j = 0; j < grid[i].Length; j++)
                {
                    //Add all the rotten oranges in queue
                    if (grid[i][j] == 2)
                    {
                        q.Enqueue(new Element(i, j, true));
                    }
                }
            }

            //set count to -1 if queue is preloaded with zombies
            var count = q.Count == 0 ? 0 : -1;

            while (q.Count > 0)
            {
                //We will only increment count when there will be a new root vertex and not for preloaded rotten oranges
                //all rotten oranges should start roting other oranges at the same time
                count++;
                //We need to find adjecent unvisited vertices for all rotten oranges
                int rootCount = q.Count;
                
                for (int i = 0; i < rootCount; i++)
                {
                    var p = q.Dequeue();
                    //Find unvisited vertex below
                    if(RotOranges(grid, p.elementX + 1, p.elementY))
                    {
                        q.Enqueue(new Element(p.elementX + 1, p.elementY, true));
                    }
                    //Find unvisited vertex above
                    if (RotOranges(grid, p.elementX - 1, p.elementY))
                    {
                        q.Enqueue(new Element(p.elementX - 1, p.elementY, true));
                    }
                    //Find unvisited vertex left
                    if (RotOranges(grid, p.elementX, p.elementY - 1))
                    {
                        q.Enqueue(new Element(p.elementX, p.elementY - 1, true));
                    }
                    //Find unvisited vertex right
                    if (RotOranges(grid, p.elementX, p.elementY + 1))
                    {

                        q.Enqueue(new Element(p.elementX, p.elementY + 1, true));
                    }

                }
            }

            //Edge Case: if all the oranges are fresh, return -1
            for (int i = 0; i < grid.Length; i++)
            {
                for(int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1) return -1;
                }
            }

            return count;
        }

        private bool RotOranges(int[][] grid, int x, int y)
        {
            if (x >= 0 && x < grid.Length && y >= 0 && y < grid[x].Length && grid[x][y] == 1)
            {
                grid[x][y] = 2;
                return true;
            }
            return false;
        }
    }

    public class Element
    {
        public int elementX;
        public int elementY;
        public bool isRotten;
        public Element(int x, int y, bool isRotten)
        {
            this.elementX = x;
            this.elementY = y;
            this.isRotten = isRotten;
        }
    }
}
