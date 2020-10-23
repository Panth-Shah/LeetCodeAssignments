using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    //You work on a team whose job is to understand the most sought after toys for the holiday season.A teammate of yours has built a webcrawler 
    //that extracts a list of quotes about toys from different articles.You need to take these quotes and identify which toys are mentioned most frequently.Write an algorithm that identifies the top N toys out of a list of quotes and list of toys.

    //Your algorithm should output the top N toys mentioned most frequently in the quotes.


    //Input:
    //The input to the function/method consists of five arguments:


    //numToys, an integer representing the number of toys
    //topToys, an integer representing the number of top toys your algorithm needs to return;
    //toys, a list of strings representing the toys,
    //numQuotes, an integer representing the number of quotes about toys;
    //quotes, a list of strings that consists of space-sperated words representing articles about toys

    //Output:
    //Return a list of strings of the most popular N toys in order of most to least frequently mentioned

    //Note:
    //The comparison of strings is case-insensitive.If the value of topToys is more than the number of toys, 
    //return the names of only the toys mentioned in the quotes.If toys are mentioned an equal number of times in quotes, sort alphabetically.
    public class TopKBuzzWords
    {
        public TopKBuzzWords()
        {

        }
        //Find top N Buzz Words from the list
        //public IList<string> TopKFrequent(string[] words, int k)
        //{
        //    if (words == null || words.Length == 0 || k <= 0 || k > words.Length)
        //        return new List<string>();
        //    //create dictionary to store  
        //    Dictionary<string, int> dict = new Dictionary<string, int>();

        //    foreach(var word in words)
        //    {
        //        if (dict.ContainsKey(word))
        //        {
        //            dict.Add(word,0);
        //        }
        //        //increment value
        //        dict[word]++;
        //    }
        //}

        public IList<string> TopKFrequent(int numToys, int topToys, string[] toys, int numQuotes, string[] quotes)
        {
            var result = new List<string>();
            int index = 0;
            //Toys dictionary -> dict(toys, [#repitations, #quotes])
            Dictionary<string, int[]> toys_freq = new Dictionary<string, int[]>();

            foreach (var toy in toys)
            {
                toys_freq[toy] = new int[] { 0, 0 };
            }


            foreach (var quote in quotes)
            {
                string[] quoteWords = quote.Trim().ToLower().Split(' ');

                //List is to keep track in how many quotes each toy mentioned
                List<string> toyInQuote = new List<string>();

                foreach (var qword in quoteWords)
                {
                    if (toys.Contains(qword))
                    {
                        //increment count of toy if it exists in toys dictionary
                        //this count will track number of repitations of toy in all quotes
                        toys_freq[qword][0] += 1;

                        //This count will track number of quotes each toy appeared minimum one time
                        if (!toyInQuote.Contains(qword))
                        {
                            toyInQuote.Add(qword);
                            toys_freq[qword][1] += 1;
                        }
                    }
                }

                index++;
            }

            return toys_freq.OrderByDescending(x => x.Value[0]).OrderByDescending(x => x.Value[1]).Select(x => x.Key)
                    .Take(topToys).ToList();
        }
    }
}
