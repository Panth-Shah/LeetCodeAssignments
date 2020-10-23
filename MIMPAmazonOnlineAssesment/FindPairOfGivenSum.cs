using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class FindPairOfGivenSum
    {
        public FindPairOfGivenSum()
        {

        }
        //Problem Statement:
        //Given list of +ve integers nums and an int target, return indices of the two numbers such that they add upto a target - 30
        //If you have multiple pairs, select the paid with the largest number.
        //Approach:
        //Tw Pass HashMap
        public int[] TwoSum(int[] nums, int target)
        {
            int sum = target - 30;
            Dictionary<int, int> map = new Dictionary<int, int>();
            int[] result = new int[] { };
            int largest = int.MinValue;
            //Load dictionary with Key as num value and Value as index
            for (int i = 0; i < nums.Length; i++)
            {
                map[nums[i]] = i;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = sum - nums[i];
                //Check if result is in the map and is not at the same index as original value
                if ((nums[i] > largest || complement > largest) && map.ContainsKey(complement) && map[complement] != i)
                {
                    result = new int[] { complement , nums[i] };
                    largest = Math.Max(nums[i], complement);
                }
            }

            return result;
        }
    }
}
