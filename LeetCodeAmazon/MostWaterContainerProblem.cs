using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class MostWaterContainerProblem
    {
        public MostWaterContainerProblem()
        {

        }
        public int MaxArea(int[] height)
        {
            int len = height.Length;
            int left = 0, right = len - 1, area = 0, min = 0;
            while(left < right)
            {
                min = Math.Min(height[left], height[right]);
                area = Math.Max(area, min * (right - left));
                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return area;
        }
    }
}
