using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class ImplementstrStr__
    {
        public ImplementstrStr__()
        {

        }
        public int StrStrTwoPointer(string haystack, string needle)
        {
            var stringList = !string.IsNullOrEmpty(haystack) ? haystack.ToList() : null;
            int haystack_len = haystack.Length;
            int needle_len = needle.Length;
            if (needle_len == 0) return 0;
            int pn = 0;

            while (pn < haystack_len - needle_len + 1)
            {
                //find position of the first needele character
                while (pn < haystack_len - needle_len + 1 && haystack[pn] != needle[0]) pn++;

                //compute the max match length
                int current_len = 0, pL = 0;
                while(pL < needle_len && pn < haystack_len && haystack[pn] == needle[pL])
                {
                    pn++;
                    pL++;
                    current_len++;
                }

                //if the whole needle string is not found
                //return its start position
                if (current_len == needle_len) return pn - needle_len;

                //otherwise backtrack
                pn = pn - current_len + 1;

            }

            return -1;

        }

        public int StrstrbyHash(string haystack, string needle)
        {
            int haystack_len = haystack.Length;
            int needle_len = needle.Length;

            if (needle_len == 0) return 0;
            if (needle_len > haystack_len) return -1;

            //Get Hash value for Needle
            int needle_hash = GenerateHashValue(needle);
            int haystack_hash = 0;
            for (int i = 0; i < haystack_len - needle_len + 1; i++)
            {
                //capture hash code of substring with length = needle_len & slide window by 1 til haystack_len - needle_len + 1
                haystack_hash = GenerateHashValue(haystack.Substring(i, needle_len));
                if (needle_hash == haystack_hash) return i;
            }
            return -1;

        }

        private int GenerateHashValue(string x)
        {

            //Generate asciivalues for each characters of Needle
            byte[] asciiBytes = Encoding.ASCII.GetBytes(x);

            //Hashvalue is generated using Horner's rule to computer the polinomial function
            //10,007 is used to control overflow problem
            long tot = 0;
            foreach (byte val in asciiBytes)
            {
                tot += 37 * tot + val;
            }
            tot = tot % 10007;
            if (tot < 0)
            {
                tot += 10007;
            }
            return (int)tot;
        }

    }
}
