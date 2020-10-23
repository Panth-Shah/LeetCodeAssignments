using System;
using System.Collections.Generic;
using System.Linq;
// IMPORT LIBRARY PACKAGES NEEDED BY YOUR PROGRAM
// SOME CLASSES WITHIN A PACKAGE MAY BE RESTRICTED
// DEFINE ANY CLASS AND METHOD NEEDED
// CLASS BEGINS, THIS CLASS IS REQUIRED
public class Solution
{
    // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
    public List<string> popularNToys(int numToys,
                                     int topToys,
                                     List<string> toys,
                                     int numQuotes, List<string> quotes)
    {
        var result = new List<string>();
        int index = 0;

        //Toy direvtory defined -> dict(toys, [#repetations, #quotes])
        Dictionary<string, int[]> toys_freq
        = new Dictionary<string, int[]>();

        //Load all toys given in input into directory key with #repetation & #quotes set to 0
        foreach (var toy in toys)
        {
            toys_freq[toy] = new int[] { 0, 0 };
        }

        //List to keep track in how many quotes each toy mentioned
        List<string> toyInQuote = new List<string>();

        //Parse through entire quote list to fill toys_freq dictionary
        foreach (var quote in quotes)
        {
            //split each quote into array of words
            string[] quoteWords = quote.Trim().ToLower().Split(' ');
            
            foreach(var qword in quoteWords)
            {
                if (toys.Contains(qword))
                {
                    //increment count of toys if it exists in toy dictionary
                    //this count will track number of repitations of toy in all quotes
                    toys_freq[qword][0] += 1;

                    //This cpount will track number of quotes each toy appeared mimimum one time
                    if (!toyInQuote.Contains(qword))
                    {
                        toyInQuote.Add(qword);
                     }
                }
            }

            toyInQuote.Count();
        }

        //From toys_freq dictionary, order toys by #repetations & #quotes each
        //repitation occured and from that select only toys counted from input argument
        //numberToys
        return toys_freq.Where(x => x.Value[0] != 0).OrderBy(x => x.Key)
                        .Select(x => x.Key).Take(topToys).ToList();
    }
    // METHOD SIGNATURE ENDS
}

