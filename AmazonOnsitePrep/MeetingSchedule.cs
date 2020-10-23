using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class MeetingSchedule
    {
        public MeetingSchedule()
        {

        }
        //public int MinMeetingRooms(int[][] intervals)
        //{
        //    if (intervals == null || intervals[0].Length == 0)
        //        return 0;
        //    SortedSet<int> allocator = new SortedSet<int>(Comparer<int>.Create((a, b) => a - b));
        //    intervals.OrderBy(x => x[0]).ThenBy(x => x[1]);

        //    allocator.Add(intervals[0][0]);
        //    for (int i = 0; i < intervals.Length - 1; i++)
        //    {
        //        if (intervals[i][0] >= allocator.Min())
        //        {
        //            var minElement = allocator.Min();
        //            allocator.Remove(minElement);
        //        }
        //        allocator.Add(intervals[i][0]);
        //    }
        //    return allocator.Count;
        //}

        public int MinMeetingRooms(int[][] intervals)
        {
            int len = intervals.Length;
            if (len == 0)
                return 0;

            var points = new List<Point>();
            for (int i = 0; i < len; i++)
            {
                points.Add(new Point() { value = intervals[i][0], start = true });
                points.Add(new Point() { value = intervals[i][1], start = false });
            }

            points.Sort((x, y) => x.value != y.value ? x.value.CompareTo(y.value) : x.start.CompareTo(y.start));

            int min = 0;
            int count = 0;
            foreach (var p in points)
            {
                count += p.start ? 1 : -1;
                min = Math.Max(min, count);
            }

            return min;
        }

        public int MinMeetingRoomFastest(int[][] intervals)
        {
            int rooms = 0, endItr = 0;
            int[] starts = new int[intervals.Length];
            int[] ends = new int[intervals.Length];

            for (int i = 0; i < intervals.Length; i++)
            {
                starts[i] = intervals[i][0];
                ends[i] = intervals[i][1];
            }
            Array.Sort(starts);
            Array.Sort(ends);

            for (int i = 0; i < starts.Length; i++)
            {
                if (starts[i] < ends[endItr])
                {
                    rooms++;
                }
                else
                {
                    endItr++;
                }
            }
            return rooms;
        }

    }
    public class Point
    {
        public int value;
        public bool start;
    }
}