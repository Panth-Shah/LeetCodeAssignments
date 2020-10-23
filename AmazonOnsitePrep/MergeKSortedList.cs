using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class MergeKSortedList
    {
        public LLNode mergeKLists(LLNode[] lists) 
        {
            //MinHeap
            SortedSet<LLNode> queue = new SortedSet<LLNode>((Comparer<LLNode>.Create((p1, p2) => 
            p1.val != p2.val ? p1.val - p2.val : 1)));
            LLNode head = new LLNode(-1);
            LLNode first = head;
            foreach (var node in lists)
            {
                if (node != null)
                    queue.Add(node);
            }

            while (queue.Count > 0)
            {
                head._next = queue.Min;
                queue.Remove(queue.Min);
                if (head._next != null)
                {
                    queue.Add(head._next);    
                }
            }
            return first._next;
        }
        public LLNode mergeKListsUsingDict(LLNode[] lists)
        {
            MinHeapForLinkedList heap = new MinHeapForLinkedList();
            //MinHeap
            foreach (var node in lists)
            {
                if (node != null)
                {
                    heap.Add(node.val, node);
                }
            }
            LLNode head = new LLNode(-1);
            LLNode first = head;

            while (heap.getCount() > 0)
            {
                var node = heap.PopMin();
                if (node._next != null)
                {
                    heap.Add(node._next.val, node._next);
                }
            }
            return first._next;
        }


    }

    public class MinHeapForLinkedList
    {
        private SortedDictionary<int, Queue<LLNode>> map = new SortedDictionary<int, Queue<LLNode>>();
        public void Add(int val, LLNode node)
        {
            if (!map.ContainsKey(val))
            {
                map.Add(val, new Queue<LLNode>());
            }
            map[val].Enqueue(node);
        }
        public LLNode PopMin()
        {
            int minKey = map.First().Key;
            LLNode node = map[minKey].Dequeue();
            if (map[minKey].Count == 0)
            {
                map.Remove(minKey);
            }

            return node;
        }

        public int getCount()
        {
            return map.Count;
        }
    }

    public class LLNode
    {
        public int val;
        public LLNode _next;
        public LLNode(int value)
        {
            this.val = value;
        }
    }
}
