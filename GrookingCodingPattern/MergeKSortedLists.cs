using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrookingCodingPattern
{
    public class MergeKSortedLists
    {
        //COmplaxity Analysis: Since we are going through all the elments of the array and will be removing/adding one element
        //from heap each step of the process, the time complaxity of this algo will be O(NlogK), where N = total # of elements &
        //'K' will be input arrays
        public MergeKSortedLists()
        {

        }
        public Node mergeLists(Node[] listNode)
        {
            SortedSet<Node> minHeap = new SortedSet<Node>();
            //put the root of each element into minHeap
            foreach (var ele in listNode)
            {
                if (ele != null)
                {
                    minHeap.Add(ele);
                }
            }

            //take the smallest element from minHeap and add it to sortedList for result
            //If top element has next element; add it to the heap
            Node resultHead = null; Node resultTail = null;
            while (minHeap.Count > 0)
            {
                var minElement = minHeap.Min;
                if (resultHead == null)
                {
                    resultHead = resultTail = minElement;
                }
                else
                {
                    resultTail.next = minElement;
                }

                if (minElement.next != null)
                {
                    minHeap.Add(minElement.next);
                }
            }

            return resultHead;
        }
    }

    public class Node
    {
      public int val;
      public Node next;
      public Node(int x) { val = x; }
    }
}
