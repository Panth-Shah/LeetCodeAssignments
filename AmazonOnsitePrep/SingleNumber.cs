using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class SingleNumber
    {
        public SingleNumber()
        {

        }

        //Bit Manipulation
        //Time Complaxity: O(N)
        //Space Complaxity: O(1)
        public int SingleNumberProblem(int[] nums)
        {
            int x = 0;
            foreach (int num in nums) x ^= num;
            return x;
        }
    }
}
