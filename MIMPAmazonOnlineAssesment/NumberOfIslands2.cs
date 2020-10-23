using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class NumberOfIslands2
    {
        List<List<int>> listDirections = new List<List<int>>();

        public NumberOfIslands2()
        {

        }
        public IList<int> NumIslands2(int m, int n, int[][] positions)
        {
            IList<int> result = new List<int>();
            int num_Islands = 0;
            Dictionary<int, List<List<int>>> islandId = new Dictionary<int, List<List<int>>>();

            foreach(int[] pos in positions)
            {
                if (islandId.Count == 0)
                {
                    num_Islands += 1;
                    islandId[num_Islands] = fillPossiblePositons(pos);
                    result.Add(num_Islands);
                    break;
                }
                else
                {
                    for (int i = 1; i <= islandId.Count; i++)
                    {
                        var value = islandId[i];
                        if (value.Exists(x => x[0] == pos[0] && x[1] == pos[1]))
                        {
                            result.Add(i);
                            break;
                        }
                    }
                }

                num_Islands += 1;
                islandId[num_Islands] = fillPossiblePositons(pos);
                result.Add(num_Islands);
                continue;
            }

            return result;
        }

        public List<List<int>> fillPossiblePositons(int[] pos)
        {
            listDirections.Add(pos.ToList());
            listDirections.Add(new List<int>() { pos[0] + 1, pos[1] });
            listDirections.Add(new List<int>() { pos[0] - 1, pos[1] });
            listDirections.Add(new List<int>() { pos[0], pos[1] + 1 });
            listDirections.Add(new List<int>() { pos[0], pos[1] - 1 });

            return listDirections;
        }
    }
}
