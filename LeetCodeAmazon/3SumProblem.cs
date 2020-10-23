using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class _3SumProblem
    {
        public _3SumProblem()
        {

        }
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            //sorting array will bring same numbers together
            Array.Sort(nums);

            for (int pivot = 0; pivot < nums.Length; pivot++)
            {
                //no need to pivot on the same number as the one previosuly used
                if (pivot > 0 && nums[pivot] == nums[pivot - 1])
                {
                    continue;
                }
                int targetSum = -(nums[pivot]);

                int startIndex = pivot + 1;
                int endIndex = nums.Length - 1;
                while (startIndex < endIndex)
                {
                    int sumOfValuesAtStartAndEndIndex = nums[startIndex] + nums[endIndex];
                    if (sumOfValuesAtStartAndEndIndex == targetSum)
                    {
                        result.Add(new int[] { nums[pivot], nums[startIndex], nums[endIndex]});

                        //No need to look at the same number if already in the result
                        while (startIndex < endIndex && nums[startIndex] == nums[startIndex + 1])
                        {
                            startIndex++;
                        }

                        //No need to look at the same number if its already is in the result.
                        while (startIndex < endIndex && nums[endIndex] == nums[endIndex - 1])
                        {
                            endIndex--;
                        }
                        startIndex++;
                        endIndex--;
                    }
                    else
                    {
                        //If sumOfValuesAtStartAndEndIndex is less than the targetSum,
                        //we need to increase the sumOfValuesAtStartAndEndIndex
                        //by taking the next big number.
                        if (sumOfValuesAtStartAndEndIndex < targetSum)
                        {
                            startIndex++;
                        }
                        //Else we need to decrease the sumOfValuesAtStartAndEndIndex,
                        //by taking the next smaller number.
                        else
                        {
                            endIndex--;
                        }
                    }
                }
            }

            return result;
        }
    }
}
