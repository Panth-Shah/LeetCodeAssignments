using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class TrajanAlgo
    {
        //An implementation of Tarjan's Strongly Connected Components algorithm using an adjacency list.
        private const int UNVISITED = -1;
        private int n;
        private List<List<int>> graph;
        private int sccCount, id;
        private int[] ids, low;
        private bool[] onStack;
        private Stack<int> stack;
        private bool solved;

        public TrajanAlgo(List<List<int>> graph)
        {
            if (graph == null) throw new ArgumentException("Graph cannot be null");
            n = graph.Count;
            this.graph = graph;
        }

        // Returns the number of strongly connected components in the graph.
        public int SCCCount()
        {
            if (!solved) Solve();
            return sccCount;
        }

        // Get the connected components of this graph. If two indexes
        // have the same value then they're in the same SCC.
        public int[] getSCCs()
        {
            if (!solved) Solve();
            return low;
        }

        public void Solve()
        {
            if (solved) return;

            ids = new int[n];
            low = new int[n];
            onStack = new bool[n];
            stack = new Stack<int>();
            
            for(int i = 0; i < n; i++)
            {
                ids[i] = UNVISITED;
            }

            for (int i = 0; i < n; i++)
            {
                if (ids[i] == UNVISITED)
                {
                    dfs(i);
                }
            }

        }

        private void dfs(int at)
        {
            stack.Push(at);
            onStack[at] = true;
            ids[at] = low[at] = id++;

            // On recursive callback, if we're at the root node (start of SCC)
            // empty the seen stack until back to root.
        }

        // Initializes adjacency list with n nodes.
        public static List<List<int>> createGraph(int n)
        {
            List<List<int>> graph = new List<List<int>>(n);
            for (int i = 0; i < n; i++) graph.Add(new List<int>());
            return graph;
        }

        // Adds a directed edge from node 'from' to node 'to'
        public static void addEdge(List<List<int>> graph, int from, int to)
        {
            graph[from].Add(to);
        }
    }
}
