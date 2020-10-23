using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class NumberOfIslandUsingUnionFind
    {
        public List<int> numIslands2(int m, int n, int[][] positions)
        {
            List<int> ans = new List<int>();
            UnionFind uf = new UnionFind(m * n);

            foreach (var pos in positions)
            {
                int r = pos[0], c = pos[1];
                List<int> overlap = new List<int>();

                if (r - 1 >= 0 && uf.isValid((r - 1) * n + c)) overlap.Add((r - 1) * n + c);
                if (r + 1 < m && uf.isValid((r + 1) * n + c)) overlap.Add((r + 1) * n + c);
                if (c - 1 >= 0 && uf.isValid(r * n + c - 1)) overlap.Add(r * n + c - 1);
                if (c + 1 < n && uf.isValid(r * n + c + 1)) overlap.Add(r * n + c + 1);

                int index = r * n + c;
                uf.setParent(index);
                foreach (int i in overlap) uf.union(i, index);
                ans.Add(uf.getCount());
            }

            return ans;
        }
    }
    public class UnionFind
    {
        int count; // # of connected components
        int[] parent;
        int[] rank;

        public UnionFind(char[][] grid)
        { // for problem 200
            count = 0;
            int m = grid.Length;
            int n = grid[0].Length;
            parent = new int[m * n];
            rank = new int[m * n];
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (grid[i][j] == '1')
                    {
                        parent[i * n + j] = i * n + j;
                        ++count;
                    }
                    rank[i * n + j] = 0;
                }
            }
        }

        public UnionFind(int N)
        { // for problem 305 and others
            //Initialize parent and rank arrays and define all parent values to -1
            count = 0;
            parent = new int[N];
            rank = new int[N];
            for (int i = 0; i < N; ++i)
            {
                parent[i] = -1;
                rank[i] = 0;
            }
        }

        public bool isValid(int i)
        { // for problem 305
            return parent[i] >= 0;
        }

        public void setParent(int i)
        {
            parent[i] = i;
            ++count;
        }

        public int find(int i)
        { // path compression
            if (parent[i] != i) parent[i] = find(parent[i]);
            return parent[i];
        }

        public void union(int x, int y)
        { // union with rank
            int rootx = find(x);
            int rooty = find(y);
            if (rootx != rooty)
            {
                if (rank[rootx] > rank[rooty])
                {
                    parent[rooty] = rootx;
                }
                else if (rank[rootx] < rank[rooty])
                {
                    parent[rootx] = rooty;
                }
                else
                {
                    parent[rooty] = rootx; rank[rootx] += 1;
                }
                --count;
            }
        }

        public int getCount()
        {
            return count;
        }
    }
}
