using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class WordLadder
    {
        private Dictionary<string, List<string>> allKeyMap = new Dictionary<string, List<string>>();
        private HashSet<LadderElement> graph = new HashSet<LadderElement>();
        private List<List<string>> result = new List<List<string>>();

        public int ledderLength(string beginWord, string endWord, List<string> wordList)
        {
            //Build Graph
            if (wordList.Count == 0 || !wordList.Contains(endWord))
            {
                return 0;
            }
            //Each word is of same length
            StringBuilder buildWord = new StringBuilder();
            int wordLength = beginWord.Length;
            List<string> children = new List<string>();
            foreach (var word in wordList)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    buildWord.Append(word.Substring(0, i));
                    buildWord.Append('*');
                    buildWord.Append(word.Substring(i + 1, word.Length));
                    if (!allKeyMap.ContainsKey(word))
                    {
                        allKeyMap.Add(word, new List<string>());
                    }
                    allKeyMap[word].Add(buildWord.ToString());
                    children.Add(buildWord.ToString());

                }
                graph.Add(new LadderElement(word, 0, children));

            }

            //Queue for bidirectional BFS
            //BFS Starting from startWord
            Queue<LadderElement> Q_begin = new Queue<LadderElement>();
            //BFS starting from endWord
            Queue<LadderElement> Q_end = new Queue<LadderElement>();
            Q_begin.Enqueue(graph.FirstOrDefault(x => x.word == beginWord));
            Q_end.Enqueue(graph.FirstOrDefault(X => X.word == endWord));

            //Build visited dictionary for begin word BFS
            HashSet<LadderElement> visitedBegin = new HashSet<LadderElement>();
            //Build visited dictionary for ending word BFS
            HashSet<LadderElement> visitedEnd = new HashSet<LadderElement>();
            graph.FirstOrDefault(x => x.word == beginWord).level = 1;
            graph.FirstOrDefault(x => x.word == endWord).level = 1;
            visitedBegin.Add(graph.FirstOrDefault(x => x.word == beginWord));
            visitedEnd.Add(graph.FirstOrDefault(x => x.word == endWord));

            while (Q_begin.Count > 0 && Q_end.Count > 0)
            {
                //One hop from begin word
                var ans = visitWordNode(Q_begin, visitedBegin, visitedEnd);
                if (ans > -1)
                {
                    return ans;
                }
                // One hop from end word
                ans = visitWordNode(Q_end, visitedEnd, visitedBegin);
                if (ans > -1)
                {
                    return ans;
                }
            }
            return 0;
        }

        private int visitWordNode(Queue<LadderElement> startWordQueue, HashSet<LadderElement> visitedBegin, HashSet<LadderElement> visitedEnd)
        {
            var element = startWordQueue.Dequeue();
            string word = element.word;
            int level = element.level;
            List<string> intermediateStates = element.intermediateStates;
            foreach (var interstate in intermediateStates)
            {
                var allNodes = graph.Where(x => x.intermediateStates.Contains(interstate)).Select(x => x.word).ToList();
                if (allNodes != null && allNodes.Count > 0)
                {
                    foreach (var newWords in allNodes)
                    {
                        if (visitedEnd.Any(x => x.word == newWords))
                        {
                            return level + visitedEnd.FirstOrDefault(x => x.word == newWords).level;
                        }
                        if (!visitedBegin.Any(x => x.word == newWords))
                        {
                            graph.FirstOrDefault(x => x.word == newWords).level = 2;
                            visitedBegin.Add(graph.FirstOrDefault(x => x.word == newWords));
                            startWordQueue.Enqueue(graph.FirstOrDefault(x => x.word == newWords));
                        }
                    }
                }
            }
            return -1;
        }
    }
}

public class LadderElement
{
    public string word;
    public int level { get; set; }
    public List<string> intermediateStates;
    public LadderElement(string currWord, int currLevel, List<string> children)
    {
        this.word = currWord;
        this.level = currLevel;
        this.intermediateStates = children;
    }
}
