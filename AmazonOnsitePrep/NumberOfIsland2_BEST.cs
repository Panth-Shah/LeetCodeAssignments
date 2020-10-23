using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    //Based on Weighted Quick Union Path Compression
    //Time: O((M+N) log* N)
    //Time: O(KlogMN)
    class NumberOfIsland2_BEST
    {
        public List<int> numIslands2(int m, int n, int[][] positions)
        {
            List<int> res = new List<int>();
            if (m <= 0 || n <= 0) { return res; }

            int count = 0;
            int[] roots = new int[m * n];   // 1D array of roots
            int[] size = new int[m * n];   // 1D array of size of each tree
            // Every position is water initially.
            for (int i = 0; i < roots.Length; i++) 
            {
                roots[i] = -1;
            }
            int[][] directions = new int[][] { new int []{ -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };

            foreach(int[] p in positions)
            {
                //Check for current Node
                int island = p[0] * n + p[1];
                roots[island] = island;     // Set it to be the root of itself.
                size[island]++;
                count++;

                // Check four directions
                foreach(int[] dir in directions)
                {
                    int x = p[0] + dir[0], y = p[1] + dir[1];
                    int neighbor = x * n + y;
                    // Skip when x or y is invalid, or neighbor is water <roots[neighbour] == -1>.
                    //If adjacent neighbours are water, skip
                    if (x < 0 || x >= m || y < 0 || y >= n || roots[neighbor] == -1) { continue; }

                    //Union Operation
                    int neighborRoot = findroot(neighbor, roots);
                    int islandRoot = findroot(island, roots);
                    //Building island by joining cells
                    if (islandRoot != neighborRoot)
                    {
                        // Union by size
                        if (size[islandRoot] >= size[neighborRoot])
                        {
                            size[islandRoot] += size[neighborRoot];
                            roots[neighborRoot] = islandRoot;
                        }
                        else
                        {
                            size[neighborRoot] += size[islandRoot];
                            roots[islandRoot] = neighborRoot;
                        }
                        count--;
                    }
                }

                res.Add(count);
            }

            return res;
        }

        private int findroot(int id, int[] roots)
        {
            //If node is root of itself
            while (id != roots[id])
            {
                roots[id] = roots[roots[id]];
                id = roots[id];
            }
            return id;
        }
    } 
}
