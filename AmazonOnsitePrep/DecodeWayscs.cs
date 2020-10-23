using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class DecodeWayscs
    {
        //Complaxity Analysis: Time Complaxity: O(N), where N is length of the string. We iterate the length of dp array which is N+1.
        //Space Complaxity: O(N), the length of the DP array
        //We can optimize this to use linear time if we don't store another DP array and update values by using only two variables
        Dictionary<int, int> memo = new Dictionary<int, int>();
        public DecodeWayscs()
        {

        }

        public int IterativeDecode(string s)
        {
            //Iterative Approach
            int[] dp = new int[s.Length + 1];
            dp[0] = 1;

            dp[1] = s[0] == '0' ? 0 : 1;

            for (int i = 2; i < dp.Length; i++)
            {
                if (s[i - 1] != '0')
                    dp[i] += dp[i - 1];
                int twoSum = int.Parse(s.Substring(i - 2, 2));

                if (twoSum >= 10 && twoSum <= 26)
                    dp[i] += dp[i - 2];
            }
            return dp[s.Length];
        }

        public int reccursiveDecodeWays(string s)
        {
            if (s == null || s.Length == 0)
                return 0;
            return reccursiveWithMemo(0, s);
        }

        private int reccursiveWithMemo(int index, string str)
        {
            //If end of string reached, pass success
            if (index == str.Length)
                return 1;

            if (str[index] == '0')
                return 0;

            if (index == str.Length - 1)
                return 1;

            //Memoization perform
            if (memo.ContainsKey(index))
                return memo[index];

            int ans = reccursiveWithMemo(index + 1, str);
            if (int.Parse(str.Substring(index + 2, 2)) <= 26)
            {
                ans += reccursiveWithMemo(index + 2, str);
            }

            //Save result in Memo
            memo.Add(index, ans);

            return ans;
        }
    }
}
