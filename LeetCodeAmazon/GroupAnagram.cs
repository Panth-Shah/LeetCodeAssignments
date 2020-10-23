using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCodeAmazon
{
    public class GroupAnagram
    {
        public GroupAnagram()
        {

        }

        //Time Complaxity: O(NKlogK), where N is the length of strs, K is the maximum length of a string strs. 
        //Outer loop has complaxity O(N) as we iterate through each string. Then, we sort each string in O(KlogK)
        //Space Complaxity: O(NK), the total information content stored in list of lists
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> output = new List<IList<string>>();
            Dictionary<string,List<string>> map = new Dictionary<string,List<string>>();
            if (strs.Length == 0) return new List<IList<string>>();
            foreach (string str in strs)
            {
                char[] charArray = str.ToCharArray();
                Array.Sort(charArray);
                string key = new string(charArray);
                List<string> anargams = map.ContainsKey(key) ? map[key] : new List<string>();
                anargams.Add(str);
                map[key] = anargams;
            }

            foreach(var value in map)
            {
                output.Add(new List<string>(value.Value));
            }
            return output;
        }

        public IList<IList<string>> improvedGroupAnagrams(string[] strs)
        {
            IList<IList<string>> output = new List<IList<string>>();
            Dictionary<int, List<string>> map = new Dictionary<int, List<string>>();
            if (strs.Length == 0) return new List<IList<string>>();

            foreach(var str in strs)
            {
                int key = 0;

                byte[] asciiBytes = Encoding.ASCII.GetBytes(str);
                
                foreach (byte b in asciiBytes)
                {
                    key += b;
                }
                if (!map.ContainsKey(key))
                {
                    map[key] = new List<string>();
                }
                var lst = map[key];
                lst.Add(str);
            }

            foreach (var value in map)
            {
                output.Add(new List<string>(value.Value));
            }
            return output;
        }

    }
}
