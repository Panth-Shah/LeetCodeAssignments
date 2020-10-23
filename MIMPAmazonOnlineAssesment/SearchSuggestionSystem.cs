using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class SearchSuggestionSystem
    {
        public SearchSuggestionSystem()
        {

        }

        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            List<IList<string>> result = new List<IList<string>>();
            //Lexicographically sort
            Array.Sort(products);

            for (var x = 0; x <= searchWord.Length - 1; x++)
            {
                var suggestion = products.Where(p => p.StartsWith(searchWord.Substring(0, x + 1))).Take(3).ToList();

                if(suggestion.Count > 0)
                {
                    result.Add(new List<string>(suggestion));
                }
                else
                {
                    result.Add(new List<string>());
                    break; // No match found
                }
            }

            while (result.Count < searchWord.Length)
            {
                result.Add(result.Last());
            }
            return result;
        }
    }
}
