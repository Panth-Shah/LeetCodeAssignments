using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrookingCodingPattern
{
    class KthSmallestNumberInSortedListcs
    {
        //Input: L1=[2, 6, 8], L2=[3, 6, 7], L3=[1, 3, 4], K=5
        //Output: 4
        //Explanation: The 5th smallest number among all the arrays is 4, this can be verified from the merged
        //list of all the arrays: [1, 2, 3, 3, 4, 6, 6, 7, 8]

        //Approach: We can start by merging all the arrays, but instead of inserting numbers into a merge list, we will keep count to see
        //how many elements are inserted. Ones that count reaches to K, we have found our required number.
        //We need to keep track of number we are pushing next in the list as this is simple list and not linkedList
        //To insert elements into minHeap, we will have to keep track of the array and the element indices.
        public KthSmallestNumberInSortedListcs()
        {

        }
        //public int findKthSmallest(List<int[]> lists, int k)
        //{
        //    // TODO: Write your code here
        //    //Put first element of each array in minHeap
        //    SortedSet<ListNode> minHeap = new SortedSet<ListNode>(Comparer<ListNode>.Create((a, b) => lists[a.arrayIndex][a.elementIndex] - lists[b.arrayIndex][a.elementIndex]));

        //    //Build placeholder for each element in all the lists
        //    for (int i = 0; i < lists.Count; i++)
        //    {
        //        if (lists[i] != null || lists[i].Count() == 0)
        //        {
        //            minHeap.Add(new ListNode(0, i));
        //        }
        //    }

        //    //Take the smallest element from min heap, if the running count is equal to K, return the number
        //    //If the array of the top element has more elements, add the next element to the heap
        //    int numberCount = 0, result = 0;
        //    while (minHeap.Count > 0)
        //    {
        //        var node = minHeap.Min;
        //        minHeap.Remove(node);
        //        result = lists[node.arrayIndex][node.elementIndex];
        //        if (++numberCount == k)
        //        {
        //            break;
        //        }
        //        node.elementIndex++;
        //        if (lists[node.arrayIndex].Length > node.elementIndex)
        //        {
        //            minHeap.Add(new ListNode(node.elementIndex, node.arrayIndex));
        //        }
        //    }

        //    return result;
        //}

        public int findKthSmallestEle(List<int[]> lists, int k)
        {
            int result = 0, numberCount = 0;
            SortedDictionary<int, int[]> minHeap = new SortedDictionary<int, int[]>();
            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i] != null || lists[i].Count() > 0)
                {
                    if (!minHeap.ContainsKey(lists[i][0]))
                    {
                        minHeap.Add(lists[i][0], new int[] { 0, i});
                    }
                }
            }

            while (minHeap.Count > 0)
            {
                //capture placeholder of min element
                result = minHeap.Keys.First();
                var node = minHeap[result];
                //capture value of min element
                minHeap.Remove(result);
                numberCount++;
                if (numberCount == k)
                {
                    break;
                }
                else
                {
                    node[0]++;
                    if (lists[node[1]].Length > node[0])
                    {
                        if (minHeap.ContainsKey(lists[node[1]][node[0]]))
                        {
                            numberCount++;
                            node[0]++;
                        }
                        minHeap.Add(lists[node[1]][node[0]], new int[] { node[0], node[1] });
                    }
                }

            }
            return result;
        }
    }

    public class ListNode
    {
        public int elementIndex;
        public int arrayIndex;
        public ListNode(int eleIndex, int arrIndex)
        {
            this.elementIndex = eleIndex;
            this.arrayIndex = arrIndex;
        }
    }
}
