using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class TwoSumProblem
    {
        public TwoSumProblem()
        {

        }
        //Bruto Forse Solution
        public int[] TwoSum(int[] nums, int target)
        {
            int[] duplicatNums = nums;
            int[] result = new int[2];
            for (int x = 0; x < nums.Length; x++)
            {
                for (int y = x + 1; y < nums.Length; y++)
                {
                    if (nums[y] == target - nums[x])
                    {
                        result[0] = x;
                        result[1] = y;
                    }
                }
            }
            return result;
        }

        //Optimized Solution
        public int[] optimizedTwoSum(int[] nums, int target)
        {
            Dictionary<int, int> hashMap = new Dictionary<int, int>();
            for (int x = 0; x < nums.Length; x++)
            {
                int complement = target - nums[x];
                if (hashMap.ContainsKey(complement))
                {
                    return new int[] { hashMap[complement] , x };
                }
                hashMap[nums[x]] = x;
            }
            throw new AggregateException("No two number present which adds upto target value " + target);
        }
    }
}
