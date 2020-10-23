using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrookingCodingPattern
{
    public class Subsets_FindAllDistinctSubsets
    {
        public Subsets_FindAllDistinctSubsets()
        {

        }
        public List<List<int>> findSubsets(int[] nums)
        {
            List<List<int>> subsets = new List<List<int>>();
            Queue<List<int>> subsetQueue = new Queue<List<int>>();
            List<int> mainList = new List<int>();
            subsets.Add(new List<int>() { });
            foreach(int input in nums)
            {
                int n = subsets.Count;
                //we will take all the existing subsets and insert current number in them
                for (int i = 0; i < n; i++)
                {
                    //Create new element for subset with inserting only current number
                    List<int> set = new List<int>(subsets[i]);
                    set.Add(input);
                    subsets.Add(set);
                }
            }
            return subsets;
        }
    }
}
