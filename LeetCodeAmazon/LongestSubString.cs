using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class LongestSubString
    {
        public LongestSubString()
        {

        }
        //public int LengthOfLongestSubstring(string s)
        //{
        //    HashSet<char> set = new HashSet<char>();

        //    //Cpature length of the string
        //    int len = s.Length;
        //    int ans = 0, i = 0, j = 0;

        //    while (i < len && j < len)
        //    {
        //        if (!set.Contains(s.ElementAt(j)))
        //        {
        //            set.Add(s.ElementAt(j++));
        //            ans = Math.Max(ans, j - i);
        //        }
        //        else
        //        {
        //            set.Remove(s.ElementAt(i++));
        //        }
        //    }
        //    return ans;
        //}

        public int LengthOfLongestSubstring(string s)
        {
            int left_pointer = 0;
            int right_pointer = 0;
            int max = 0;
            HashSet<char> hash = new HashSet<char>();

            while (right_pointer < s.Length)
            {
                if (!hash.Contains(s[right_pointer]))
                {
                    hash.Add(s[right_pointer]);
                    right_pointer++;
                    max = Math.Max(hash.Count, max);
                }
                else
                {
                    hash.Remove(s[left_pointer]);
                    left_pointer++;
                }
            }
            return max;
        }
    }
}
