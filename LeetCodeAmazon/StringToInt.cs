using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class StringToInt
    {
        public StringToInt()
        {

        }

        public int MyAtoi(string s)
        {
            int result = 0;
            long res;
            int MAX_VALUE = Int32.MaxValue;
            int MIN_VALUE = Int32.MinValue;
            string[] stringArray = new string[] { };
            if (!string.IsNullOrEmpty(s.Trim()))
            {
                stringArray = s.TrimStart().Split(' ');
                string sub = stringArray[0][0] == '.' ? "." : stringArray[0].Contains('.') ? stringArray[0][0].ToString() : stringArray[0];
                if (Regex.Matches(sub, @"[a-zA-Z]").Count > 0 && Regex.Matches(sub, @"[0-9]").Count > 0)
                {
                    string[] splitString = Regex.Split(sub, @"[a-zA-Z]");
                    sub = splitString[0];
                }
                if (Int32.TryParse(sub, out result))
                    return result;
                else if (Int64.TryParse(sub, out res))
                    return sub.Contains("+") ? MAX_VALUE : sub.Contains("-") ? MIN_VALUE : MAX_VALUE;
                else if (Regex.Matches(sub, @"[a-zA-Z]").Count == 0 && Regex.Matches(sub, @"[0-9]").Count > 0 && !sub.Contains('.'))
                    return sub.Contains("-") && sub.Contains("+") ? result : sub.Contains("+") ? MAX_VALUE : sub.Contains("-") ? MIN_VALUE : MAX_VALUE;
                else
                    return result;
            }
            else
            {
                return result;
            }

        }
    }
}
