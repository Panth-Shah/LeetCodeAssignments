using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrookingCodingPattern
{
    public class Subset_Permutations
    {
        public Subset_Permutations()
        {

        }

        public List<List<int>> findPermutations(int[] nums)
        {
            List<List<int>> result = new List<List<int>>();
            result.Add(nums.ToList());
            Queue<List<int>> perm = new Queue<List<int>>();
            perm.Enqueue(new List<int>() { });
            foreach(int num in nums)
            {
                int n = perm.Count;
                for (int a = 0; a < n; a++ )
                {
                    var oldPerm = perm.Dequeue();
                    //create new permutation by adding the current number at every index of the oldPerm
                    for (int j = 0; j < oldPerm.Count; j++)
                    {
                        List<int> newPerm = new List<int>(oldPerm);
                        //Create new permutation by adding new number at every index
                        if(newPerm.Count == 0)
                        {
                            newPerm.Add(num);
                        }
                        else
                        {
                            newPerm[j] = num;
                        }
                        if (newPerm.Count == nums.Count())
                        {
                            result.Add(newPerm);
                        }
                        else
                        {
                            perm.Enqueue(newPerm);
                        }
                    }
                }
            }
            return result;
        }
    }
}
