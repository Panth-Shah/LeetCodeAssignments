using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class PackageDependencyDesign
    {
        public PackageDependencyDesign()
        {

        }

        //Find a correct build order
        public Project[] findBuildOrder(string[] projects, string[][] dependencies)
        {
            Graph graph = buildGraph(projects, dependencies);
            return orderProjects(graph.getNodes());
        }

        private Graph buildGraph(string[] projects, string[][] dependencies)
        {
            Graph graph = new Graph();
            //Each project is vertice of a graph and be added with its dependencies
            foreach (var project in projects)
            {
                graph.getOrCreateNode(project);
            }

            //Build dependencies of each graph indencies from dependencies matrix
            //Add edge into graph
            foreach (var dependency in dependencies)
            {
                string first = dependency[0];
                string second = dependency[1];
                graph.addEdge(first, second);
            }

            return graph;
        }

        //Return list of the project in dependency order
        private Project[] orderProjects(List<Project> projects)
        {
            Project[] order = new Project[projects.Count];

            //Add "roots" to build order first
            int endOfList = addNoDependent(order, projects, 0);

            int toBeProcessed = 0;
            while (toBeProcessed < order.Length)
            {
                Project current = order[toBeProcessed];

                //we have circular dependeny as we have no projects left with zero dependencies
                if (current == null)
                    return null;

                //remove current element from dependency
                List<Project> children = current.getChildren();
                foreach(var child in children)
                {
                    child.decrementDependencies();
                }

                //Add children that has no one depending on them
                endOfList = addNoDependent(order, children, endOfList);
                toBeProcessed++;
            }
            return order;
        }

        //Helper function to insert projects with zero dependencies into the order
        //array, starting at index offset
        private int addNoDependent(Project[] order, List<Project> projects, int offset)
        {
            foreach (var project in projects)
            {
                if (project.getNumberOfDependents() == 0)
                {
                    order[offset] = project;
                    offset++;
                }
            }
            return offset;
        }
    }

    public class Graph
    {
        //Build List of nodes
        private List<Project> nodes = new List<Project>();
        
        //Map with Graph and its dependencies => built for constant time access of graph dependencies for each vertices
        private Dictionary<string, Project> map = new Dictionary<string, Project>();

        //
        public Project getOrCreateNode(string name)
        {
            if (!map.ContainsKey(name))
            {
                Project node = new Project(name);
                nodes.Add(node);
                map.Add(name, node);
            }

            return map[name];
        }

        //Add edge between start and end node and add end as neighbour of end
        public void addEdge(string startName, string endName)
        {
            Project start = getOrCreateNode(startName);
            Project end = getOrCreateNode(endName);
            start.addNeighbours(end);
        }

        public List<Project> getNodes()
        {
            return nodes;
        } 
    }

    //Projects: 
    public class Project
    {
        private List<Project> children = new List<Project>();
        private Dictionary<string, Project> map = new Dictionary<string, Project>();
        private string name;
        private int dependencies = 0;

        public Project(string n)
        {
            name = n;
        }

        public void incrementDependencies()
        {
            dependencies++;
        }
        public void decrementDependencies()
        {
            dependencies--;
        }
        public string getName()
        {
            return name;
        }
        public List<Project> getChildren()
        {
            return children;
        }

        public int getNumberOfDependents()
        {
            return dependencies;
        }
        //Add neighbour of node in graph and increment node dependency
        public void addNeighbours(Project node)
        {
            if (!map.ContainsKey(node.getName()))
            {
                children.Add(node);
                map.Add(node.getName(), node);
                node.incrementDependencies();
            }
        }
    }
}
