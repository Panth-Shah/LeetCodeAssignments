using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class WordBreak2
    {
        public WordBreak2()
        {

        }

        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            HashSet<string> wordDictSet = new HashSet<string>(wordDict);
            return word_break(s, wordDictSet, 0);
        }
        Dictionary<int, IList<string>> map = new Dictionary<int, IList<string>>();
        private IList<string> word_break(string s, HashSet<string> set, int start)
        {
            if (map.ContainsKey(start))
                return map[start];

            IList<string> res = new List<string>();

            if (start == s.Length)
                res.Add("");

            for (int end = start + 1; end <= s.Length; end++)
            {
                if(set.Contains(s.Substring(start, end - start)))
                {
                    IList<string> lst = word_break(s, set, end);
                    foreach(string l in lst)
                    {
                        res.Add(s.Substring(start, end - start) + (l.Equals("") ? "" : " ") + l);
                    }
                }
            }

            map.Add(start, res);
            return res;
        }

        //Approach 2 BFS
        //Time: O(n2^n)
        //Space: O(n2^n)
        public IList<string> WordBreakApproach2(string s, IList<string> wordDict)
        {
            HashSet<string> wordSet = new HashSet<string>(wordDict);
            return breakWord(s, wordSet);
        }

        private IList<string> breakWord(string word, HashSet<string> wordDict)
        {
            Queue<WordElement> q = new Queue<WordElement>();
            q.Enqueue(new WordElement(0));
            IList<string> result = new List<string>();

            while (q.Count > 0)
            {
                WordElement ele = q.Dequeue();
                if (ele.nextindex >= word.Length)
                {
                    result.Add(ele.result);
                }

                for (int i = ele.nextindex; i <= word.Length; i++)
                {
                    string possibleWord = word.Substring(ele.nextindex, i - ele.nextindex);
                    if (wordDict.Contains(possibleWord))
                    {
                        WordElement newEle = new WordElement(i, ele.result);
                        string temp = newEle.result != null ? newEle.result : null;
                        newEle.result = temp != null ? temp + " " + possibleWord : possibleWord;
                        q.Enqueue(newEle);
                    }
                }
            }

            return result;
        }

        //Approach 3
        //Time: O(n2^n)
        //Space: O(n2^n)
        public IList<string> WordBreakApproach3(string s, IList<string> wordDict)
        {
            return DFS(s, wordDict, new Dictionary<string, LinkedList<string>>());
        }
        private static IList<string> DFS(string s, IList<string> wordDict, Dictionary<string, LinkedList<String>> map)
        {
            // Look up cache 
            if (map.ContainsKey(s))
            {
                return map[s].ToList();
            }

            var list = new LinkedList<string>();

            // base case => Iterating over the entire length of string
            if (s.Length == 0)
            {
                list.AddLast("");
                return list.ToList();
            }

            // go over each word in dictionary
            //catsanddogs => ["cat", "cats", "dog", "and"]
            foreach (string word in wordDict)
            {
                //cat
                if (s.StartsWith(word))
                {
                    //
                    var sublist = DFS(s.Substring(word.Length), wordDict, map);

                    foreach (string sub in sublist)
                    {
                        list.AddLast(word + (string.IsNullOrEmpty(sub) ? "" : " ") + sub);
                    }
                }
            }

            // memoization
            map.Add(s, list);

            return list.ToList();
        }

        public class WordElement
        {
            public int nextindex;
            public string result;

            public WordElement()
            {

            }

            public WordElement(int nextIndex)
            {
                this.nextindex = nextIndex;
            }

            public WordElement(int nextIndex, string res)
            {
                this.nextindex = nextIndex;
                this.result = res;
            }
        }

    }
}
