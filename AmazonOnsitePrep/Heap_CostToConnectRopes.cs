using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class Heap_CostToConnectRopes
    {
        public int minCostToConnectRopes(int[] ropes) {
            int result = 0;
            //minHeap
            SortedSet<int> minHeap = new SortedSet<int>(Comparer<int>.Create((p1, p2) => p1 == p2 ? 1 : p1 - p2));
            ////MaxHeap
            //SortedSet<int> maxHeap = new SortedSet<int>(Comparer<int>.Create((p1, p2) => p1 - p2));
            foreach (var rope in ropes) 
            {
                minHeap.Add(rope);
            }
            //go through the values in the heap, in each step take top (lowest)
            //connect them and push the result back into minHeap
            //keep doing this until the heap is left is left with only one rope
            int temp = 0;
            while (minHeap.Count > 1)
            {
                int runningSum = 0;
                temp = minHeap.Min;
                runningSum += temp;
                //remove min value from heap
                minHeap.Remove(temp);
                temp = minHeap.Min;
                runningSum += temp;
                //remove min value from heap
                minHeap.Remove(temp);
                result += runningSum;
                minHeap.Add(temp);
            }
            return result;
        }
    }
}
