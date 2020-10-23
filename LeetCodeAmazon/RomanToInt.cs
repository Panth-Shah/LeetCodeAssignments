using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class RomanToInt
    {
        public RomanToInt()
        {

        }
        public string IntToRoman(int num)
        {
            Dictionary<int, string> romanintMapping = new Dictionary<int, string>()
            {
                { 1 , "I" },
                { 5 , "V" },
                { 10 , "X" },
                { 50 , "L" },
                { 100 , "C" },
                { 500 , "D" },
                { 1000 , "M" },
            };
            int count = 0;
            int remainder = 0;
            int temp = 0;
            string romanOutput = null;
            List<int> keyList = romanintMapping.Keys.ToList();
            keyList.Reverse();
            while (count < romanintMapping.Count)
            {
                if (num >= keyList[count])
                {
                    num = num % keyList[count];
                    //assign num to remainder of num/key[count]
                    //reset count
                }
                else if (num == keyList[count] - 1)
                {
                    romanOutput += romanintMapping[1] + romanintMapping[keyList[count]];
                    break;
                }
                else
                {
                    count++;
                }
            }

            return romanOutput;
        }
    }
}
