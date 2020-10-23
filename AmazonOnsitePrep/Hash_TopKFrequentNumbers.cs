using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class Hash_TopKFrequentNumbers
    {
        //    public int[] topKFFequent(int[] nums, int k) 
        //    {
        //        List<int> result = new List<int>();
        //        SortedDictionary<int, int> numFreqMap = new SortedDictionary<int, int>();
        //        foreach (int num in nums) 
        //        {
        //            if (!numFreqMap.ContainsKey(num)) 
        //            {
        //                numFreqMap.Add(num, 0);
        //            }
        //            numFreqMap[num] += 1;
        //        }
        //        SortedSet<int> heap = new SortedSet<int>(Comparer<int>.Create((p1, p2) =>
        //        numFreqMap[p1] - numFreqMap[p2]));
        //        foreach (var num in numFreqMap.Keys)
        //        {
        //            heap.Add(num);
        //            if(heap.Count > k)
        //            {
        //                heap.Remove(heap.Min);
        //            }
        //        }

        //        return new int[] { };
        //    }
        //}
        public IList<int> TopKFrequent(int[] nums, int k)
        {
            var freq = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (!freq.ContainsKey(num))
                    freq.Add(num, 0);
                freq[num]++;
            }

            List<int>[] buckets = new List<int>[nums.Length + 1];

            foreach (var pair in freq)
            {
                int key = pair.Key;
                int val = pair.Value;
                if (buckets[val - 1] == null)
                    buckets[val - 1] = new List<int>();
                buckets[val - 1].Add(key);
            }

            var res = new List<int>();
            for (int i = buckets.Length - 1; i >= 0 && res.Count < k; i--)
            {
                if (buckets[i] != null)
                {
                    int remaining = k - res.Count;
                    if (remaining < buckets[i].Count)
                    {
                        for (int j = 0; j < remaining; j++)
                            res.Add(buckets[i][j]);
                    }
                    else
                        res.AddRange(buckets[i]);
                }
            }
            return res;
        }
    }
}
