using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class CourseScheduler2
    {
        public CourseScheduler2()
        {

        }
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
            //Indegree is to keep track of nodes with number of child/dependent nodes
            int[] indegree = new int[numCourses];
            int[] topologicalOrder = new int[numCourses];

            //Create djacency list representation of graph
            foreach (var dependency in prerequisites)
            {
                int prevCourse = dependency[1];
                int nextCourse = dependency[0];
                if (!adjList.ContainsKey(prevCourse))
                {
                    adjList.Add(prevCourse, new List<int>());
                }
                adjList[prevCourse].Add(nextCourse);
                indegree[nextCourse] += 1;
            }

            //Add all vertices with indegree = 0 to queue
            Queue<int> q = new Queue<int>();
            for (int k = 0; k < indegree.Length; k++)
            {
                if (indegree[k] == 0)
                {
                    q.Enqueue(k);
                }
            }
            int i = 0;
            //Processor until the queue is empty
            while (q.Count > 0)
            {
                var element = q.Dequeue();
                topologicalOrder[i++] = element;

                //reduce the indegree of each neighbour of this element
                if (adjList.ContainsKey(element))
                {
                    foreach(var ele in adjList[element])
                    {
                        indegree[ele]--;
                        //If indegree of a neighbour becomes 0, add it to queue
                        if(indegree[ele] == 0)
                        {
                            q.Enqueue(ele);
                        }
                    }
                }
            }

            //Check if topological sort is possible
            if (i == numCourses)
            {
                return topologicalOrder;
            }

            return new int[0];
        }
    }
}
