using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class KSubstringKChar
    {
        //public List<string> kSubstring(string s, int k)
        //{
        //    HashSet<char> window = new HashSet<char>();
        //    HashSet<string> result = new HashSet<string>();

        //    for (int start = 0, end = 0; end < s.Length; end++)
        //    {
        //        for (; start < s.Length; start++)
        //        {
        //            window.Remove(s[start]);
        //        }

        //        window.Add(s[end]);

        //        if(window.Count == k)
        //        {
        //            int length = end - start + 1;
        //            result.Add(s.Substring(start, length));
        //            window.Remove(s[start++]);
        //        }
        //    }

        //    return result.ToList();
        //}

        //O(N^2 solution)

        public List<string> kSubstring(string s, int k)
        {
            List<string> set = new List<string>();
            int[] ch = new int[26];
            int lo = 0;
            int hi = 0;

            while (lo <= hi && hi < s.Length)
            {
                ch[s[hi] - 'a']++;
                while(ch[s[hi] - 'a'] != 1)
                {
                    ch[s[lo] - 'a']--;
                    lo++;
                }
                if (hi - lo + 1 == k)
                {
                    set.Add(s.Substring(lo, k));
                    ch[s[lo] - 'a']--;
                    lo++;
                }
                hi++;
            }

            return set.Distinct().ToList();
        }
    }
}
