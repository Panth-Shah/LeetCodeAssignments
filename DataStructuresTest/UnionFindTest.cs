using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresTest
{
    public class UnionFindTest
    {
        // The number of elements in this union find
        private int size;

        // Used to track the size of each of the component
        private int[] sz;

        // id[i] points to the parent of i, if id[i] = i then i is a root node
        private int[] id;

        // Tracks the number of components in the union find
        private int numComponents;

        public UnionFindTest (int size)
        {
            if (size <= 0) throw new ArgumentException("Size <= 0 is not allowed");
            this.size = numComponents = size;
            this.sz = new int[size];
            this.id = new int[size];

            for(int i= 0; i < size; i++)
            {
                id[i] = i; //Link each node to itself (self root)
                sz[i] = 1; //Each component is originally of size one
            }
        }

        // Find which component/set 'p' belongs to, takes amortized constant time.
        public int find(int p)
        {
            int root = p;
            while (root != id[root]) root = id[root];

            while (p != root)
            {
                int next = id[p];
                id[p] = root;
                p = next;
            }
            return root;
        }
        public bool connected(int p, int q)
        {
            return find(p) == find(q);
        }

        // Return the size of the components/set 'p' belongs to
        public int componentSize(int p)
        {
            return sz[find(p)];
        }

        //// Return the number of elements in this UnionFind/Disjoint set
        //public int size()
        //{
        //    return size;
        //}

        // Returns the number of remaining components/sets
        public int components()
        {
            return numComponents;
        }

        // Unify the components/sets containing elements 'p' and 'q'
        public void unify(int p, int q)
        {

            int root1 = find(p);
            int root2 = find(q);

            // These elements are already in the same group!
            if (root1 == root2) return;

            // Merge smaller component/set into the larger one.
            if (sz[root1] < sz[root2])
            {
                sz[root2] += sz[root1];
                id[root1] = root2;
            }
            else
            {
                sz[root1] += sz[root2];
                id[root2] = root1;
            }

            // Since the roots found are different we know that the
            // number of components/sets has decreased by one
            numComponents--;
        }

    }
}
