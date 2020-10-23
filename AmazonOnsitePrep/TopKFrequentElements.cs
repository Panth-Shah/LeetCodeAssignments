using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{

    //Problem 387: First Unique Characters in String
    public class TopKFrequentElements
    {
        public TopKFrequentElements()
        {

        }
        //Time Complaxity: O(n) -> SINCE WE GO THROUGH THE STRING OF LENGTH n TWICE
        //Space Complaxity: O(N) -> since we have to keep a Dictionary with N elements
        
        public int FirstUniqChar(string s)
        {
            Dictionary<char, int> charMap = new Dictionary<char, int>();
            //Iterate through entire string
            foreach (char _chr in s)
            {
                if (!charMap.ContainsKey(_chr))
                {
                    //store each character against its index
                    charMap[_chr] = s.IndexOf(_chr);
                }
                else
                {
                    //Indicate duplicate char
                    charMap[_chr] = -1;
                }
            }

            int min = int.MaxValue;
            foreach (var elemenets in charMap)
            {
                if (elemenets.Value > -1 && elemenets.Value < min)
                {
                    min = elemenets.Value;
                }
            }

            return min == int.MaxValue ? -1 : min;
        }
    }
}
