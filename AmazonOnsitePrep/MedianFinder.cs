using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class MedianFinder
    {
        private int counter = 0;
        //MaxHeap
        private SortedSet<int[]> setLow = new SortedSet<int[]>(Comparer<int[]>.Create((a,b) => a[0] == b[0] ? a[0] - b[0] : a[1] - b[1]));
        //points.Sort((x, y) => x.value != y.value? x.value.CompareTo(y.value) : x.start.CompareTo(y.start));

        //MinHeap
        private SortedSet<int[]> setHigh = new SortedSet<int[]>(Comparer<int[]>.Create((a, b) => a[0] == b[0] ? a[0] - b[0] : a[1] - b[1]));

        public MedianFinder()
        {

        }

        public void addNum(int num)
        {
            int[] newNum = new int[2] { num, counter++};
            //Either both heaps are balanced or empty
            if (setLow.Count == setHigh.Count)
            {
                if (setLow.Count == 0 || num <= setLow.Max[0])
                {
                    //No balancing needed
                    setLow.Add(newNum);
                }
                else
                {
                    //Balance MaxHeap by adding an element from minHeap
                    setHigh.Add(newNum);
                    setLow.Add(setHigh.Min);
                    setHigh.Remove(setHigh.Min);
                }
            }
            else if(num <= setLow.Max[0])
            {
                //Perform balancing on MaxHeap
                setLow.Add(newNum);
                setHigh.Add(setLow.Max);
                setLow.Remove(setLow.Max);
            }
            else
            {
                setHigh.Add(newNum);
            }
        }
        
        public double FindMedian()
        {
            if (setLow.Count == 0)
            {
                return 0;
            }
            else if (setHigh.Count == setLow.Count)
            {
                return (double)(setLow.Max[0] + setHigh.Min[0]) * 0.5;
            }
            else
            {
                return (double)setLow.Max[0];
            }
        }
    }
}
