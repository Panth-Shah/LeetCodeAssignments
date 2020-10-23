using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    //Topological Sort problem
    public class CourseScheduler
    {
        public CourseScheduler()
        {

        }
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
             if (prerequisites == null || prerequisites.Count() == 0)
                return true;

            //Step1: Build Graph from Vertices and Dependencies
            //Here, [a, b] => b is a prerequisite of a
            //To take a, you have to complete b
            CourseGraph graph = buildGraph(prerequisites);
            return orderCourses(graph, numCourses, prerequisites);
        }

        private bool orderCourses(CourseGraph graph, int numCourse, int[][] prerequisites)
        {
            int numDependencies = prerequisites.Count();
            List<CourseGraphNode> nodes = graph.nodes;
            CourseGraphNode[] courses = new CourseGraphNode[nodes.Count];
            //Cpature all courses which doesn't have any prerequisites
            int endOfList = addNodesWithNoDependencies(courses, nodes, 0);

            int toBeProcessed = 0;
            while (toBeProcessed < courses.Length)
            {
                var course = courses[toBeProcessed];
                
                //Circular dependency detected
                if (course == null)
                    return false;

                //remove current element from dependency
                List<CourseGraphNode> children = course.children;
                foreach (var child in children)
                {
                    //remove edge from removed node and child nodes
                    child.decrementDependencies();
                }

                //Add childrens that has no dependent nodes
                endOfList = addNodesWithNoDependencies(courses, children, endOfList);
                toBeProcessed++;
            }
            return true;
        }

        private int addNodesWithNoDependencies(CourseGraphNode[] courses, List<CourseGraphNode> nodes, int offset)
        {
            foreach (var node in nodes)
            {
                if (node.dependencies == 0)
                {
                    courses[offset] = node;
                    offset++;
                }
            }
            return offset;
        }

        private CourseGraph buildGraph(int[][] dependencies)
        {
            CourseGraph graph = new CourseGraph();

            //Build dependencies of each graph indices from dependencies matrix
            foreach (var dependency in dependencies)
            {
                var preCourse = graph.getOrCreateNode(dependency[1]);
                var nextCourse = graph.getOrCreateNode(dependency[0]);
                graph.addEdge(nextCourse, preCourse);
            }
            return graph;
        }
    }

    public class CourseGraph
    {
        //Build list of nodes
        public List<CourseGraphNode> nodes = new List<CourseGraphNode>();

        //Maping nodes with its dependencies
        private Dictionary<int, CourseGraphNode> map = new Dictionary<int, CourseGraphNode>();

        //Get or Create Node of the graph from cache
        public CourseGraphNode getOrCreateNode(int course)
        {
            if (!map.ContainsKey(course))
            {
                CourseGraphNode node = new CourseGraphNode(course);
                nodes.Add(node);
                map.Add(course, node);
            }

            return map[course];
        }

        //Add edge between start and end node and add end as neigbour of end
        public void addEdge(CourseGraphNode currCourse, CourseGraphNode preRequisite)
        {
            preRequisite.addNeighbours(currCourse);
        }
    }

    public class CourseGraphNode
    {
        public int dependencies = 0;
        public List<CourseGraphNode> children = new List<CourseGraphNode>();
        private Dictionary<int, CourseGraphNode> map = new Dictionary<int, CourseGraphNode>();

        private int course;
        public CourseGraphNode(int c)
        {
            course = c;  
        }
        public void incrementDependencies()
        {
            dependencies++;
        }
        public void decrementDependencies()
        {
            dependencies --;
        }
        public int getCourse()
        {
            return course;
        }
        public void addNeighbours(CourseGraphNode node)
        {
            if (!map.ContainsKey(node.getCourse()))
            {
                children.Add(node);
                map.Add(node.getCourse(), node);
                node.incrementDependencies();
            }
        }
    }
}
