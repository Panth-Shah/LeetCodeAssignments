using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    class Program
    {
        static void Main(string[] args)
        {
            //LongestPalindromicSubstring pal = new LongestPalindromicSubstring();
            //pal.longestPalindrome("abba");

            //WordBreak2 wb = new WordBreak2();
            //IList<string> input = new List<string>() { "cats", "dog", "sand", "and", "cat" };
            ////wb.WordBreakApproach3("catsanddog", input);
            ////string IP = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            //WordBreak2 wb2 = new WordBreak2();
            ////IList<string> input = new List<string>()
            ////{ "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa"};
            //wb2.WordBreakApproach2("catsanddog", input);

            //WordSearchUsingTie ws = new WordSearchUsingTie();

            //Topological Sorting
            //string[] projects = new string[] { "a", "b", "c", "d", "e", "f"};
            //string[][] dependencies = new string[][] { new string[] { "f", "c"}, new string[] { "f", "b"},
            //new string[] { "f", "a"}, new string[] { "c", "a"}, new string[] { "b", "a"}, new string[] { "a", "e"},
            //new string[] { "b", "c"}, new string[] { "d", "g"}};
            //PackageDependencyDesign topologicalSort = new PackageDependencyDesign();
            //topologicalSort.findBuildOrder(projects, dependencies);
            //string beginWord = "hit";
            //string endWord = "cog";
            //List<string> wordList = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" };
            //BTWordLadder wordLadder = new BTWordLadder();
            //wordLadder.ladderLength(beginWord, endWord, wordList);

            //CourseScheduler2 cs = new CourseScheduler2();
            //int[][] dependencies = new int[][] { new int[] { 1, 0 } , new int[] { 2, 0 }, new int[] { 3, 1 }, new int[] { 3, 2 } };
            //cs.FindOrder(5, dependencies);

            //BestTimeToBuySellStocks stocks = new BestTimeToBuySellStocks();
            //int[] prices = new int[] { 7, 1, 5, 3, 6, 4};
            //stocks.maxProfit2(prices);
            //int[][] courses = new int[][] { new int[] { 7, 17 }, new int[] { 3, 12 }, new int[] { 10, 20 }, new int[] { 9, 10 } ,
            //    new int[] { 5, 20 }, new int[] { 10, 19 }, new int[] { 4, 18 } };
            //CourseSchedulerHard hard = new CourseSchedulerHard();
            //hard.ScheduleCourse(courses);

            //MedianFinder mf = new MedianFinder();
            //mf.FindMedian();
            //mf.addNum(1);
            //mf.addNum(2);
            //mf.FindMedian();
            //mf.addNum(3);
            //mf.FindMedian();
            //MeetingSchedule ms = new MeetingSchedule();
            //int[][] input = new int[][] { new int[] { 2, 11 }, new int[] { 6, 16 }, new int[] { 11, 16 } };
            //ms.MinMeetingRoomFastest(input);
            //int[][] input = new int[][] { new int[] { 2, 3 }, new int[] { 2, 2 }, new int[] { 3, 3 }, new int[] { 1, 3 }
            //, new int[] { 5, 7 }, new int[] { 2, 2 }, new int[] { 4, 6 }};
            //MergeIntervals mi = new MergeIntervals();
            //mi.Merge(input);
            //Heap_CostToConnectRopes connectRopes = new Heap_CostToConnectRopes();
            //connectRopes.minCostToConnectRopes(new int[] { 5, 9, 10, 5, 4, 1});
            //Hash_TopKFrequentNumbers htk = new Hash_TopKFrequentNumbers();
            //htk.TopKFrequent(new int[] { 9, 8,1 ,2, 10, 1, 8, 1, 2, 1, 3, 9, 10, 1}, 2);

            //Heap_FrequencySort freq = new Heap_FrequencySort();
            //freq.frequencySort("Programming");
            //WordSearchUsingTie ws = new WordSearchUsingTie();
            //char[][] input = new char[][] { new char[] { 'p', 'a', 'a', 'n'}, new char[] { 'e', 't', 'a', 'e' }
            //, new char[]{ 't', 'h', 'd', 'o'}, new char[]{ 'i', 'f', 'l', 'g'}};
            //string[] words = new string[] {"oath","doag","doags","dig"};
            //ws.findWords(input, words);

            ConcatenateWordUsingTrie con = new ConcatenateWordUsingTrie();
            con.findAllConcatenatedWordsInADict(new string[] { "cat", "cats", "catsdogcats", "dog", "dogcatsdog", "hippopotamuses", "rat", "ratcatdogcat" });
        }
    }
}
