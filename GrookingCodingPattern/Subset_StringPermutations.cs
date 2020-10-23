using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrookingCodingPattern
{
    public class Subset_StringPermutations
    {
        public Subset_StringPermutations()
        {

        }

        public List<string> findLetterCaseStringPermutations(string str)
        {
            List<string> result = new List<string>();
            if (str == null)
            {
                return new List<string>();
            }
            result.Add(str);
            //Process everycharacter of the string one by one
            for (int i = 0; i < str.Length; i++)
            {
                //We will take all existing permutations and change the letter case
                //Only process letters and not numbers
                if (char.IsLetter(str[i]))
                {
                    int n = result.Count();
                    for (int j = 0; j < n; j++)
                    {
                        var chs = result[j].ToCharArray();
                        //If current letter is in upper case, change it to lower case
                        chs[i] = char.IsUpper(chs[i]) ? char.ToLower(chs[i]) :
                            char.ToUpper(chs[i]);
                        result.Add(string.Concat(chs));
                    }
                }
            }
            return result;
        }
    }
}
