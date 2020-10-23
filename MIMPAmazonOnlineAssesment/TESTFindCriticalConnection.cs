using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class TESTFindCriticalConnection
    {
        private int[] ids;
        private List<int>[] graph;
        private IList<IList<int>> result;
        private int?[] discoveredTime;
        private const int UNVISITED = -1;
        private int expextedDiscoveredTime = 0;

        public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {
            buildGraph(connections);
            Initialization(n);
            Dfs(0,0);
            return result;
        }

        private void buildGraph(IList<IList<int>> connection)
        {
            foreach (var c in connection)
            {
                graph[c[0]].Add(c[1]);
                graph[c[1]].Add(c[0]);
            }

        }

        private void Initialization(int n)
        {
            graph = new List<int>[n];
            ids = new int[n];
            result = new List<IList<int>>();
            discoveredTime = new int?[n];

            for (int i = 0; i < n; i ++)
            {
                graph[i] = new List<int>();
                ids[i] = UNVISITED;
            }
        }
        private int Dfs(int node, int? parent)
        {

            if (discoveredTime[node] != null)
                return (int)discoveredTime[node];

            discoveredTime[node] = expextedDiscoveredTime;

            foreach (var childNode in graph[node])
            {

                if (childNode == parent)
                    continue;
                int childExptedToBeDiscoveredIn = expextedDiscoveredTime + 1;
                int actualDiscoveredTime = Dfs(childNode, node);
                if (actualDiscoveredTime >= childExptedToBeDiscoveredIn)
                {
                    result.Add(new List<int> { childNode, node});
                }

                // Update the discovered times of nodes based its child discovered times.
                discoveredTime[node] = Math.Min(actualDiscoveredTime, (int)discoveredTime[node]);
            }

            return (int)discoveredTime[node];
        }
    }
}
