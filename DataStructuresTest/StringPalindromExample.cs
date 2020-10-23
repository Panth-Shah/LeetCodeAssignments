using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresTest
{
    public class StringPalindromExample
    {
        private StackTest<string> stringStack;
        public StringPalindromExample()
        {
            stringStack = new StackTest<string>();
        }

        public void StringPalindromCheck(string inputString)
        {
            string ch;
            bool isPalindrom = true;
            for (int x = 0; x < inputString.Length; x++)
            {
                stringStack.push(inputString.Substring(x, 1));
            }
            int pos = 0;
            while (stringStack.count > 0)
            {
                ch = stringStack.pop().ToString();
                if (ch != inputString.Substring(pos, 1))
                {
                    isPalindrom = false;
                    break;
                }
                pos++;
            }
            if (isPalindrom)
                Console.WriteLine(inputString + " is a palindrom. ");
            else
                Console.WriteLine(inputString + " is not a palindrom. ");
            Console.Read();
        }
    }
}
