﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class NumberOfIsland2_WQUPC
    {

        private int[][] dir = { new int []{ 0, 1 }, new int[] { 0, -1 }, new int[] { -1, 0 }, new int[] { 1, 0 } };

        public List<int> numIslands2(int m, int n, int[][] positions)
        {
            UnionFind2D islands = new UnionFind2D(m, n);
            List<int> ans = new List<int>();
            foreach(int[] position in positions)
            {
                int x = position[0], y = position[1];
                int p = islands.add(x, y);
                foreach(int[] d in dir)
                {
                    int q = islands.getID(x + d[0], y + d[1]);
                    if (q > 0 && !islands.find(p, q))
                        islands.unite(p, q);
                }
                ans.Add(islands.size());
            }
            return ans;
        }
    }

    class UnionFind2D
    {
        private int[] id;
        private int[] sz;
        private int m, n, count;

        public UnionFind2D(int m, int n)
        {
            this.count = 0;
            this.n = n;
            this.m = m;
            this.id = new int[m * n + 1];
            this.sz = new int[m * n + 1];
        }

        public int index(int x, int y) { return x * n + y + 1; }

        public int size() { return this.count; }

        public int getID(int x, int y)
        {
            if (0 <= x && x < m && 0 <= y && y < n)
                return id[index(x, y)];
            return 0;
        }

        public int add(int x, int y)
        {
            int i = index(x, y);
            id[i] = i; sz[i] = 1;
            ++count;
            return i;
        }

        public bool find(int p, int q)
        {
            return root(p) == root(q);
        }

        public void unite(int p, int q)
        {
            int i = root(p), j = root(q);
            if (sz[i] < sz[j])
            { //weighted quick union
                id[i] = j; sz[j] += sz[i];
            }
            else
            {
                id[j] = i; sz[i] += sz[j];
            }
            --count;
        }

        private int root(int i)
        {
            for (; i != id[i]; i = id[i])
                id[i] = id[id[i]]; //path compression
            return i;
        }
    }
    //Runtime: 20 ms
}
