using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class CourseSchedulerHard
    {
        public CourseSchedulerHard()
        {

        }
        public int ScheduleCourse(int[][] courses)
        {
            if (courses == null || courses[0].Length == 0)
                return 0;
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            for (int i = 0; i < courses.Length; i++)
            {
                if (!map.ContainsKey(i))
                {
                    map.Add(i, new List<int>());
                }
                map[i].Add(courses[i][0]);
                map[i].Add(courses[i][1]);
            }
            int runningTime = 0;
            List<int> result = new List<int>();
            //Sort by Duration
            //var mapSorted = map.OrderBy(x => x.Value[1]).ThenBy(x => x.Value[0]);
            var mapSorted = courses.OrderBy(x => x[1]).ThenBy(x => x[0]);
            foreach(var ele in mapSorted)
            {
                if (runningTime + ele[0] <= ele[1])
                {
                    result.Add(ele[0]);
                    runningTime += ele[0];
                }
                else
                {
                    int max_i = 0;
                    for (int i = 1; i < result.Count; i++)
                    {
                        if (result[i] > result[max_i])
                        {
                            max_i = i;
                        }
                    }
                    if (result[max_i] > ele[0])
                    {
                        runningTime += ele[0] - result[max_i];
                        result[max_i] = ele[0];
                    }
                }
            }
            return result.Count();
        }
    }
}
