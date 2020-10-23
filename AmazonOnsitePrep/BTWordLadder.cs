using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class BTWordLadder
    {
        public BTWordLadder()
        {

        }

        public int ladderLength(string beginWord, string endWord, List<string> wordList)
        {
            //Since all the words are of same length
            int L = beginWord.Length;

            //Step1: PreProcessing of words in WordList
            //Build dictionary to hold all the possibility of each word in WordList
            Dictionary<string, List<string>> wordMap = new Dictionary<string, List<string>>();
            foreach (var word in wordList)
            {
                for(int i = 0; i < L; i++)
                {
                    string newWord = word.Substring(0, i) + "*" + word.Substring(i + 1);
                    if (!wordMap.ContainsKey(newWord))
                    {
                        wordMap.Add(newWord, new List<string>());
                    }
                    wordMap[newWord].Add(word);
                }
            }

            //Step2: BFS
            Queue<QElement> q = new Queue<QElement> ();
            q.Enqueue(new QElement(beginWord, 1, true));
            // Visited to make sure we don't repeat processing same word.
            Dictionary<string, bool> visited = new Dictionary<string, bool>();
            visited.Add(beginWord, true);
            while(q.Count > 0)
            {
                var element = q.Dequeue();
                string word = element._word;
                int level = element._level;
                for (int i = 0; i < L; i++)
                {
                    //Intermediate words for current word
                    string newWord = word.Substring(0, i) + "*" + word.Substring(i + 1);
                    //All the words which shares same intermediate state
                    if (wordMap.ContainsKey(newWord))
                    {
                        foreach (var adjacentWord in wordMap[newWord])
                        {
                            //If at any point if we find what we are looking for
                            //i.e. the end word - we can return with the answer
                            if (adjacentWord.Equals(endWord))
                            {
                                return level + 1;
                            }
                            //Otherwise, add it to the BFS queue and mark it visited
                            if (!visited.ContainsKey(adjacentWord))
                            {
                                visited.Add(adjacentWord, true);
                                q.Enqueue(new QElement(adjacentWord, level + 1, true));
                            }
                        }
                    }
                }
            }

            return 0;
        }
    }

    public class QElement
    {
        public string _word;
        public int _level;
        public bool _isVisited;
        public QElement(string word, int level, bool status)
        {
            this._word = word;
            this._level = level;
            this._isVisited = status;
        }
    }
}
