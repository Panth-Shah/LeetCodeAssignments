using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class BestTimeToBuySellStocks
    {
        public BestTimeToBuySellStocks()
        {

        }

        public int maxProfit(int[] price)
        {
            int maxProfit = int.MaxValue;
            int minPrice = int.MinValue;

            for (int i = 0; i < price.Length; i++)
            {
                if (minPrice > price[i])
                {
                    minPrice = price[i];
                }
                else if (price[i] - minPrice > maxProfit)
                {
                    maxProfit = price[i] - minPrice;
                }
            }
            return maxProfit;
        }

        public int maxProfit2(int[] prices)
        {
            if (prices == null || prices.Length == 0)
                return 0;
            int peak = prices[0];
            int vally = prices[0];
            int maxProfit = 0;
            int i = 0;
            while (i < prices.Length - 1)
            {
                //If price will go up, I will sell the stock and I will make my profit
                //Current is my vally
                while (i < prices.Length - 1 && prices[i] >= prices[i + 1])
                {
                    i++;
                }
                vally = prices[i];

                //If price will go down,I will not sell and current is my peak
                while (i < prices.Length - 1 && prices[i] <= prices[i + 1])
                {
                    i++;
                }
                peak = prices[i];
                maxProfit += peak - vally;
            }
            return maxProfit;
        }

        //public int maxProfitHard(int[] prices)
        //{
        //    int buy = int.MinValue;
        //    int sell = int.MinValue;
        //    int maxProfit = 0;
        //    int localProfit = 0;
        //    int i = 0;
        //    while (i < prices.Length - 1)
        //    {
        //        if (prices[i] <= prices[i + 1])
        //        {
        //            buy = prices[i];
        //            i++;
        //            localProfit = prices[i + 1] - prices[i];
        //        }
        //        maxProfit = Math.Max(maxProfit, localProfit);
        //    }

        //}
    }
}
