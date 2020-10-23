using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresTest
{
    public class BinarySearchTree
    {
        public Node root;
        public BinarySearchTree()
        {
            root = null;
        }

        public void Insert(int i)
        {
            Node newNode = new Node();
            newNode.Data = i;

            if (root == null)
                root = newNode;
            else
            {
                Node current = root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if(i < current.Data)
                    {
                        current = current.left;
                        if(current == null)
                        {
                            parent.left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        current = current.right;
                        if(current == null)
                        {
                            parent.right = newNode;
                            break;
                        }
                    }
                }
            }
        }

        public void InOrder(Node root)
        {
            if(!(root == null))
            {
                InOrder(root.left);
                root.DisplayNode();
                InOrder(root.right);
            }
        }

        public void PreOrder(Node root)
        {
            if (!(root == null))
            {
                root.DisplayNode();
                PreOrder(root.left);
                PreOrder(root.right);
            }
        }
        public void PostOrder(Node root)
        {
            if (!(root == null))
            {
                PostOrder(root.left);
                PostOrder(root.right);
                root.DisplayNode();
            }
        }

        public Node Find(int key)
        {
            Node current = new Node();
            current = root;
            while(current.Data != key)
            {
                if(key < current.Data)
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
                if(current == null)
                {
                    return null;
                }
            }
            return current;
        }

        public void RemovingLeaf()
        {

        }

        public int Height(Node node)
        {
            if (node == null) return 0;
            return Math.Max(Height(node.left),Height(node.right)) + 1;
        }
    }

    public class Node
    {
        public int Data;
        public Node left;
        public Node right;

        public void DisplayNode()
        {
            Console.Write(Data + " ");
        }
    }

}
