using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class TopKBuzzWordsUisngHeap
    {
        public void TopKBuzzWords()
        {

        }

        public IList<string> TopNBuzzwords(int numToys, int n, String[] toys, int numQuotes, String[] quotes)
        {
            IList<string> result = new List<string>();
            List<string> toyInQuote = new List<string>();

            Dictionary<string, int[]> toy_freq = new Dictionary<string, int[]>();
            foreach (var toy in toys)
            {
                toy_freq[toy] = new int[] { 0,0};
            }

            foreach(var quote in quotes)
            {
                var cleanQuote = quote.Replace("[!'?;,.]", "");
                string[] qwords = cleanQuote.Trim().ToLower().Split(' ');

                foreach (var qword in qwords)
                {
                    if (toys.Contains(qword))
                    {
                        toy_freq[qword][0] += 1;

                        if (!toyInQuote.Contains(qword))
                        {
                            toyInQuote.Add(qword);
                            toy_freq[qword][1] += 1;
                        }
                    }
                }

                toyInQuote.Clear();
            }
            return result;
        }
    }
    

}
