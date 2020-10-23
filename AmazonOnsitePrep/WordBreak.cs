using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class WordBreak
    {
        public WordBreak()
        {

        }

        public bool WordBreakUsingBFS(string s, IList<string> wordDict)
        {
            HashSet<string> wordDictSet = new HashSet<string>(wordDict);
            Queue<int> strQueue = new Queue<int>();
            int[] visited = new int[s.Length];
            strQueue.Enqueue(0);

            while (strQueue.Count > 0)
            {
                int start = strQueue.Dequeue();
                if (visited[start] == 0)
                {
                    for (int end = start + 1; end <= s.Length; end++)
                    {
                        if (wordDictSet.Contains(s.Substring(start, end - start)))
                        {
                            strQueue.Enqueue(end);
                            if (end == s.Length)
                            {
                                return true;
                            }
                        }
                    }
                    visited[start] = 1;
                }
            }

            return false;
        }

        HashSet<string> words;
        Dictionary<int, bool> memo = new Dictionary<int, bool>();

        private bool WordBreakHelper(string s, int index)
        {

            if (index == s.Length)
                return true;

            if (!memo.ContainsKey(index))
            {
                bool result = false;
                foreach (var word in words)
                {

                    if (word.Length <= s.Length - index && s.IndexOf(word, index) == index)
                    {
                        result = WordBreakHelper(s, index + word.Length);
                        if (result)
                        {
                            memo.Add(index, true);
                            return true;
                        }
                    }
                }
                memo.Add(index, false);
            }
            return memo[index];

        }

        public bool WordBreakRecursive(string s, IList<string> wordDict)
        {

            words = new HashSet<string>(wordDict);
            return WordBreakHelper(s, 0);

        }
    }
}
