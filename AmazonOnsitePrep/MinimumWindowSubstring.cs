using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    //public class MinimumWindowSubstring
    //{
    //    public string minWindow(string searchString, string t)
    //    {
    //        Dictionary<char, int> requiredchars = buildMappingOfcharsToOccurrences(t);
    //        Dictionary<char, int> windowcharMapping = new Dictionary<char, int>();

    //        int left = 0;
    //        int right = 0;

    //        int totalCharFrequenciesToMatch = requiredchars.Count;
    //        int charFrequenciesInWindowThatMatch = 0;

    //        int minWindowLengthSeenSoFar = int.MaxValue
    //        string minWindow = "";

    //        while (right < searchString.Length)
    //        {
    //            char charAtRightPointer = searchString[right];
    //            addcharToHashtableMapping(windowcharMapping, charAtRightPointer);

    //            bool rightCharIsARequirement = requiredchars.containsKey(charAtRightPointer);
    //            if (rightCharIsARequirement)
    //            {
    //                bool requirementForcharMet =
    //                  requiredchars.get(charAtRightPointer).intValue() ==
    //                  windowcharMapping.get(charAtRightPointer).intValue();

    //                if (requirementForcharMet)
    //                {
    //                    charFrequenciesInWindowThatMatch++;
    //                }
    //            }

    //            while (charFrequenciesInWindowThatMatch == totalCharFrequenciesToMatch && left <= right)
    //            {
    //                char charAtLeftPointer = searchString.charAt(left);
    //                int windowSize = right - left + 1;

    //                if (windowSize < minWindowLengthSeenSoFar)
    //                {
    //                    minWindowLengthSeenSoFar = windowSize;
    //                    minWindow = searchString.substring(left, right + 1);
    //                }

    //                windowcharMapping.put(
    //                  charAtLeftPointer,
    //                  windowcharMapping.get(charAtLeftPointer) - 1
    //                );

    //                boolean leftCharIsARequirement = requiredchars.containsKey(charAtLeftPointer);
    //                if (leftCharIsARequirement)
    //                {
    //                    boolean charFailsRequirement =
    //                      windowcharMapping.get(charAtLeftPointer).intValue() <
    //                      requiredchars.get(charAtLeftPointer).intValue();

    //                    if (charFailsRequirement)
    //                    {
    //                        charFrequenciesInWindowThatMatch--;
    //                    }
    //                }

    //                left++;
    //            }

    //            right++;
    //        }

    //        return minWindow;
    //    }

    //    private Dictionary<char, int> buildMappingOfcharsToOccurrences(string s)
    //    {
    //        Dictionary<char, int> map = new Dictionary<char, int>();

    //        for (int i = 0; i < s.Length; i++)
    //        {
    //            int? occurrencesOfchar = map[s[i]];
    //            map.Add(s[i], occurrencesOfchar + 1);
    //        }

    //        return map;
    //    }

    //    private void addcharToHashtableMapping(
    //      Dictionary<char, int> map,
    //      char c
    //    )
    //    {
    //        int occurrences = map.getOrDefault(c, 0);
    //        map.put(c, occurrences + 1);
    //    }

    //}
}
