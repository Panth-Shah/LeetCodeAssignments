using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class MostCommonWords
    {
        public MostCommonWords()
        {

        }

        public string MostCommonWordLogic(string paragraph, string[] banned)
        {
            HashSet<string> banSet = new HashSet<string>(banned);
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            Regex reg = new Regex(@"[^0-9a-zA-Z]+");
            string result = reg.Replace(paragraph, " ");
            string[] quoteWords = result.ToLower().Trim().Split(' ');
            foreach (string word in quoteWords)
            {
                if (!banSet.Contains(word))
                {
                    if (!wordCount.ContainsKey(word))
                    {
                        wordCount.Add(word, 1);
                    }
                    wordCount[word] += 1;
                }
            }
            List<string> lst = wordCount.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();
            return lst[0];
        }
    }
}
