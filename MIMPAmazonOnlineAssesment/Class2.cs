using System;
using System.Collections.Generic;
// IMPORT LIBRARY PACKAGES NEEDED BY YOUR PROGRAM
// SOME CLASSES WITHIN A PACKAGE MAY BE RESTRICTED
// DEFINE ANY CLASS AND METHOD NEEDED
// CLASS BEGINS, THIS CLASS IS REQUIRED
public class UpgradeServer
{
    // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
    public int minimumDays(int rows, int columns, int[,] grid)
    {
        // WRITE YOUR CODE HERE

        if (grid.Length == 0 || grid == null)
        {
            return -1;
        }

        //Initialize Queue
        Queue<Element> server_queue = new Queue<Element>();

        //outer parse through row of grid
        for (int r = 0; r < grid.GetLength(0); r++)
        {
            //Inner parse through column of grid
            for (int c = 0; c < grid.GetLength(1); c++)
            {
                //All the updated servers placed in queue for BFS
                if (grid[r, c] == 1)
                {
                    server_queue.Enqueue(new Element(r, c, true));
                }
            }

        }

        //Set count to -1 if queue is reloaded with upgraded servers
        var count = server_queue.Count == 0 ? 0 : -1;

        while (server_queue.Count > 0)
        {
            //We will increment count when there will be a new root vertex and not for
            //preloaded upgraded servers
            //all upgraded servers should start upgrading servers at the same time
            count++;

            //We need to find adjecent unvited servers which needs to be upgraded
            int rootCount = server_queue.Count;

            for (int i = 0; i < rootCount; i++)
            {
                var vertex = server_queue.Dequeue();
                //Find unvisited vertex in grid
                if (upgradeServer(grid, vertex.elementX + 1, vertex.elementY))
                {
                    server_queue.Enqueue(new Element(vertex.elementX + 1, vertex.elementY, true));
                }

                if (upgradeServer(grid, vertex.elementX - 1, vertex.elementY))
                {
                    server_queue.Enqueue(new Element(vertex.elementX - 1, vertex.elementY, true));
                }

                if (upgradeServer(grid, vertex.elementX, vertex.elementY - 1))
                {
                    server_queue.Enqueue(new Element(vertex.elementX, vertex.elementY - 1, true));
                }

                if (upgradeServer(grid, vertex.elementX, vertex.elementY + 1))
                {
                    server_queue.Enqueue(new Element(vertex.elementX, vertex.elementY + 1, true));
                }
            }

        }

        //Edge Case: If all servers in grid are upgraded already, no need to perform any operation
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[i, j] == 1) return -1;
            }
        }

        return count;
    }

    public bool upgradeServer(int[,] grid, int x, int y)
    {
        if (x >= 0 && x < grid.GetLength(0) && y >= 0 && y < grid.GetLength(1) &&
        grid[x, y] == 0)
        {
            grid[x, y] = 1;
            return true;
        }
        return false;
    }
    // METHOD SIGNATURE ENDS
}

public class Element
{
    public int elementX;
    public int elementY;
    public bool isUpdated;

    public Element(int x, int y, bool isUpdated)
    {
        this.elementX = x;
        this.elementY = y;
        this.isUpdated = isUpdated;
    }

}

