using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class DeepCopyOfElementsinLL
    {
        //Dictionary<Node,Node> will hold old nodes as Keys and new nodes as its values
        Dictionary<Node, Node> visitedDict = new Dictionary<Node, Node>();

        //We will be treating Linked List as Graph here
        public DeepCopyOfElementsinLL()
        {

        }

        public Node CopyRandomList(Node head)
        {
            if (head == null)
                return null;

            //If we have already processed the current node, then we simply return the cloned version of it
            if (visitedDict.ContainsKey(head))
            {
                return visitedDict[head];
            }

            //Pass 1: Create a clone of node in HashTable

            //Create a new Node with the value same as old node (i.e. copy the node)
            Node node = new Node(head.val, null, null);

            //Save this value in dictionary. This is needed since there migh be loops
            //during traversal due to randomeness of random pointers and this would help us avoid

            visitedDict.Add(head, node);

            //Pass 2: Build Dependencies of next and random node in recursive call
            //recursively copy the remaining linked list starting one from the next pointer and then from the random pointer
            //thus we have two independent recursive calls
            //Finally we update the next and random pointers for the new node created

            node.next = CopyRandomList(head.next);
            node.random = CopyRandomList(head.random);

            return node;
        }
    }

    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val, Node _next, Node _random)
        {
            val = _val;
            next = _next;
            random = _random;
        }
    }

}
