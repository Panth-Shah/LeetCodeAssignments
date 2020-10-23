using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class CoinChange
    {
        public CoinChange()
        {

        }

        public int CountChangeTest(int[] coins, int amount)
        {
            //Initialize DP matrix
            int[,] dp = new int[coins.Length + 1, amount + 1];

            //Max ways to make changes for 0 will be 1, do nothing
            dp[0, 0] = 1;

            //Iterate through coints
            for (int i = 1; i <= coins.Length; i++)
            {
                dp[i, 0] = 1;
                //Iterate through amount starting from 0
                for (int j = 1; j <= amount; j++)
                {
                    int currentCoingValue = coins[i - 1];

                    int withoutThisCoin = dp[i - 1, j];
                    int withThisCoin = currentCoingValue <= j ? dp[i, j - currentCoingValue] : 0;

                    dp[i, j] = withoutThisCoin + withThisCoin;

                }
            }

            return dp[coins.Length, amount];
        }
    }
}
