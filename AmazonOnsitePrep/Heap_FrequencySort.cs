using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class Heap_FrequencySort
    {
        public string frequencySort(string input)
        {
            string result = null;
            SortedDictionary<char, int> charMap = new SortedDictionary<char, int>();
            foreach (char _chr in input)
            {
                if (!charMap.ContainsKey(_chr))
                {
                    charMap.Add(_chr, 0);
                }
                charMap[_chr]++;
            }
            List<char>[] buckets = new List<char>[input.Length + 1];
            foreach (var pair in charMap)
            {
                char key = pair.Key;
                int val = pair.Value;
                if (buckets[val - 1] == null)
                    buckets[val - 1] = new List<char>();
                for(int i = 0; i < val; i++)
                {
                    buckets[val - 1].Add(key);
                }
            }

            for (int i = buckets.Length - 1; i >= 0; i--)
            {
                if (buckets[i] != null)
                {
                    if(buckets[i].Count > 1)
                    {
                        foreach(char _chr in buckets[i])
                        {
                            result += _chr;
                        }
                    }
                    else
                    {
                        result += buckets[i];
                    }

                }
            }
            return result;
        }
    }
}
