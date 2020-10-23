using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrookingCodingPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //KthSmallestNumberInSortedListcs kElement = new KthSmallestNumberInSortedListcs();
            //List<int[]> input = new List<int[]>() { new int[] { 2, 6, 8}, new int[] { 3, 6, 7} , new int[] { 1, 3, 4} };
            //kElement.findKthSmallestEle(input, 5);
            //Subsets_FindAllDistinctSubsets ss = new Subsets_FindAllDistinctSubsets();
            //int[] input = new int[] { 1, 2, 3};
            //ss.findSubsets(input);
            //Subset_StringPermutations ss = new Subset_StringPermutations();
            //ss.findLetterCaseStringPermutations("Ax5POs");
            //Subset_Permutations perm = new Subset_Permutations();
            //perm.findPermutations(new int[] { 1, 2, 3});
            int[] input = new int[] { 3,2,3,1,2,4,5,5,6};
            KthLargesrNumberInSortedList kLarg = new KthLargesrNumberInSortedList();
            kLarg.FindKthLargest(input, 4);
        }
    }
}
