using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class FindCriticalConnections
    {
        //Problem Statement:
        //n servers numbered from 0 to n-1 connected by undirected server-to-server connections forming a
        //network where connections[i] = [a,b] represents connection between servers a and b. Any server can reach
        //any other server directly or indirectly through the network
        //A critical connecton is a connection that if removed will make some servers unable to reach some of the servers
        //return all critical connections in the network in any order

        //    private List<List<int>> graph;
        //    private const int UNVISITED = -1;
        //    private int[] ids;
        //    private int expectedDiscoveredTime;
        //    IList<IList<int>> result;
        //    private int[] discoveredTime, lowestVertex; // this stores the actual disocered time of each node while doing the Dfs

        //    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        //    {
        //        initialization(n);
        //        buildNetwork(connections);

        //        DFS(0);

        //        return result;
        //    }

        //    private void initialization(int n)
        //    {
        //        graph = new List<List<int>>();
        //        for (int i = 0; i < n; i++) graph.Add(new List<int>());
        //        result = new List<IList<int>>();
        //        ids = new int[n];
        //        discoveredTime = new int[n];
        //        lowestVertex = new int[n];

        //        for (int x = 0; x < n; x++)
        //        {
        //            ids[x] = UNVISITED;
        //        }
        //    }

        //    private void buildNetwork(IList<IList<int>> connections)
        //    {

        //        //build graph
        //        foreach (var c in connections)
        //        {
        //            int u = c[0];
        //            int v = c[1];

        //            if (!graph[u].Contains(v))
        //                graph[u].Add(v);

        //            if (!graph[v].Contains(u))
        //                graph[v].Add(u);
        //        }
        //    }

        //    private void DFS(int node)
        //    {

        //        expectedDiscoveredTime++;
        //        discoveredTime[node] = expectedDiscoveredTime;
        //        lowestVertex[node] = expectedDiscoveredTime;
        //        ids[node] = expectedDiscoveredTime;

        //        foreach (var childNode in graph[node])
        //        {
        //            if (childNode == node)
        //                continue;
        //            if (ids[childNode] == UNVISITED)
        //            {
        //                DFS(childNode);
        //                lowestVertex[node] = Math.Min(lowestVertex[childNode], lowestVertex[node]);

        //                //lowestVertex of neighbor > current's discoveredTime => critical connection!!
        //                //lowestVertex of neighbor <= current's discoveredTime
        //                //=> not critical connection. there is a circular network.

        //                if (lowestVertex[childNode] > discoveredTime[node])
        //                {
        //                    result.Add(new List<int>() { node, childNode });
        //                }
        //            }
        //            else//if this neighbor is already visited, lowerVertext of current will be updated!!
        //            {
        //                lowestVertex[node] = Math.Min(lowestVertex[node], discoveredTime[childNode]);
        //            }
        //        }
        //    }
        //}
        Dictionary<int, List<int>> graph;
        IList<IList<int>> ret;
        int?[] discoveredTime; // this stores the actual disocered time of each node while doing the Dfs.

        public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {
            graph = new Dictionary<int, List<int>>();
            ret = new List<IList<int>>();
            discoveredTime = new int?[n];

            foreach (var c in connections)
            {
                int u = c[0];
                int v = c[1];

                if (!graph[u].Contains(v))
                    graph[u].Add(v);

                if (!graph[v].Contains(u))
                    graph[v].Add(u);
            }
            Dfs(0, null, 0);
            return ret;

        }

        private int Dfs(int node, int? parent, int expextedDiscoveredTime)
        {

            if (discoveredTime[node] != null)
                return (int)discoveredTime[node];

            discoveredTime[node] = expextedDiscoveredTime;

            foreach (var childNode in graph[node])
            {

                if (childNode == parent)
                    continue;
                int childExptedToBeDiscoveredIn = expextedDiscoveredTime + 1;
                int actualDiscoveredTime = Dfs(childNode, node, childExptedToBeDiscoveredIn);
                if (actualDiscoveredTime >= childExptedToBeDiscoveredIn)
                {

                    // found a critical node that has only one way to reach (there is no backup )
                    //- its an articulation point and its brigde between two connected components
                    // The node will be critical node.

                    var temp = new List<int>();
                    temp.Add(node);
                    temp.Add(childNode);
                    ret.Add(temp);

                }

                // Update the discovered times of nodes based its child discovered times.
                discoveredTime[node] = Math.Min(actualDiscoveredTime, (int)discoveredTime[node]);
            }

            return (int)discoveredTime[node];
        }
    }
}
