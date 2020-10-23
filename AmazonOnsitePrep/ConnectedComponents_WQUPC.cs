using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class ConnectedComponents_WQUPC
    {
        public int CountComponents(int n, int[][] edges)
        {
            int[] root = new int[n];
            int[] size = new int[n];
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                root[i] = i;
                size[i] = 1;
            }

            for (int i = 0; i < edges.Length; i++)
            {
                int node1 = edges[i][0];
                int node2 = edges[i][1];
                // weighted
                if (size[node1] <= size[node2])
                {
                    union(root, edges[i][0], edges[i][1]);
                    size[node2] += size[node1];
                }
                else
                {
                    union(root, edges[i][1], edges[i][0]);
                    size[node1] += size[node2];
                }
            }

            for (int i = 0; i < n; i++)
                set.Add(findRoot(root, i));

            return set.Count;
        }
        private int findRoot(int[] root, int i)
        {
            while (i != root[i])
            {
                // important: path compression
                root[i] = root[root[i]];
                i = root[i];
            }
            return i;
        }

        private void union(int[] root, int p, int q)
        {
            int i = findRoot(root, p);
            int j = findRoot(root, q);
            root[i] = j;
        }
    }
}