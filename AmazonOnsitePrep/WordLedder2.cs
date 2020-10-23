using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class WordLadder2
    {
        private List<List<string>> result = new List<List<string>>();
        private HashSet<LadderElement2> graphNodes;

        public int ledderLength(string beginWord, string endWord, List<string> wordList)
        {
            //Build Graph
            if (wordList.Count == 0 || !wordList.Contains(endWord))
            {
                return 0;
            }

            LadderGraph graph = new LadderGraph();
            graph.buildNodes(beginWord, wordList);
            graphNodes = graph.getNodes();

            //Queue for bidirectional BFS
            //BFS Starting from startWord
            Queue<LadderElement2> Q_begin = new Queue<LadderElement2>();
            //BFS starting from endWord
            Queue<LadderElement2> Q_end = new Queue<LadderElement2>();
            Q_begin.Enqueue(graphNodes.FirstOrDefault(x => x.word == beginWord));
            Q_end.Enqueue(graphNodes.FirstOrDefault(X => X.word == endWord));

            //Build visited dictionary for begin word BFS
            HashSet<LadderElement2> visitedBegin = new HashSet<LadderElement2>();
            //Build visited dictionary for ending word BFS
            HashSet<LadderElement2> visitedEnd = new HashSet<LadderElement2>();
            graphNodes.FirstOrDefault(x => x.word == beginWord).level = 1;
            graphNodes.FirstOrDefault(x => x.word == endWord).level = 1;
            visitedBegin.Add(graphNodes.FirstOrDefault(x => x.word == beginWord));
            visitedEnd.Add(graphNodes.FirstOrDefault(x => x.word == endWord));

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

        private int visitWordNode(Queue<LadderElement2> startWordQueue, HashSet<LadderElement2> visitedBegin, HashSet<LadderElement2> visitedEnd)
        {
            var element = startWordQueue.Dequeue();
            string word = element.word;
            int level = element.level;
            List<string> intermediateStates = element.intermediateStates;
            foreach (var interstate in intermediateStates)
            {
                var allNodes = graphNodes.Where(x => x.intermediateStates.Contains(interstate)).Select(x => x.word).ToList();
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
                            graphNodes.FirstOrDefault(x => x.word == newWords).level = 2;
                            visitedBegin.Add(graphNodes.FirstOrDefault(x => x.word == newWords));

                            startWordQueue.Enqueue(graphNodes.FirstOrDefault(x => x.word == newWords));
                        }
                    }
                }
            }
            return -1;
        }
    }
}

public class LadderGraph
{
    //Build List of Nodes
    private HashSet<LadderElement2> nodes;
    //build dependencies
    private Dictionary<string, List<LadderElement2>> dependencies;
    //Build Inter States for Word
    private Dictionary<string, List<string>> allKeyMap = new Dictionary<string, List<string>>();

    public LadderGraph()
    {
        nodes = new HashSet<LadderElement2>();
        dependencies = new Dictionary<string, List<LadderElement2>>();
    }

    public HashSet<LadderElement2> getNodes()
    {
        return nodes;
    }

    public void buildNodes(string beginWord, List<string> wordList)
    {
        //Each word is of same length
        StringBuilder buildWord = new StringBuilder();
        int wordLength = beginWord.Length;
        List<string> states = new List<string>();
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
                states.Add(buildWord.ToString());

            }
            nodes.Add(new LadderElement2(word, 0, states));

        }
    }
}

public class LadderElement2
{
    public string word;
    public int level { get; set; }
    public List<string> intermediateStates;
    private List<string> children;
    public LadderElement2(string currWord, int currLevel, List<string> children)
    {
        this.word = currWord;
        this.level = currLevel;
        this.intermediateStates = children;
        this.children = new List<string>();
    }

    public void addChildren(string child)
    {
        children.Add(child);
    }

    public List<string> getChildren()
    {
        return children;
    }
}
