using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrookingCodingPattern
{
    public class KthLargesrNumberInSortedList
    {
        public KthLargesrNumberInSortedList()
        {

        }
        public int FindKthLargest(int[] nums, int k)
        {
            SortedSet<int> minHeap = new SortedSet<int>(Comparer<int>.Create((x ,y) => x - y));
            foreach (int n in nums)
            {
                minHeap.Add(n);
                if (minHeap.Count > k)
                {
                    int firstEle = minHeap.First();
                    minHeap.Remove(firstEle);
                }
            }
            return minHeap.First();
        }
    }
}
