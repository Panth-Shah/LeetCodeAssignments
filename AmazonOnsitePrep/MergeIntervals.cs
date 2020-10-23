using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class MergeIntervals
    {
        public MergeIntervals()
        {

        }
        public int[][] Merge(int[][] intervals)
        {
            //Sort intervals
            var sortedInt = intervals.OrderBy(X => X[0]);
            //Array.Sort(intervals, (i1, i2) => i1[0].CompareTo(i2[0]));

            LinkedList<int[]> merged = new LinkedList<int[]>();
            foreach(var ele in sortedInt)
            {      // if the list of merged intervals is empty or if the current
                   // interval does not overlap with the previous, simply append it.
                if (merged.Count == 0 || merged == null || merged.Last()[1] < ele[0])
                {
                    merged.AddLast(ele);
                }
                // otherwise, there is overlap, so we merge the current and previous
                // intervals.
                else
                {
                    merged.Last()[1] = Math.Max(merged.Last()[1], ele[1]);
                }
            }
            return merged.ToArray();
        }
    }
}
