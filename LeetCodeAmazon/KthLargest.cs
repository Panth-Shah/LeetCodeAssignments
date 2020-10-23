using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeAmazon
{
    public class KthLargest
    {
        private int kth;
        private SortedDictionary<int, int> minHeap;
        private int actualSize;

        public KthLargest(int k, int[] nums)
        {
            this.kth = k;
            minHeap = new SortedDictionary<int, int>();
            foreach (var n in nums)
                Add(n);
        }

        public int Add(int num)
        {
            if (minHeap.ContainsKey(num))
                minHeap[num]++;
            else
                minHeap.Add(num, 1);
            actualSize++;

            if (actualSize > kth)
            {
                var minKV = minHeap.First();
                if (minKV.Value == 1)
                    minHeap.Remove(minKV.Key);
                else
                    minHeap[minKV.Key]--;
                actualSize--;
            }

            return minHeap.First().Key;
        }
    }
}
