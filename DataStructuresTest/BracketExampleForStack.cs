using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresTest
{
    public class BracketExampleForStack
    {
        private string brackets;
        private bool isBalanced = true;
        private Stack<string> bracketStack;

        public int chr;
        public BracketExampleForStack()
        {
            this.brackets = "{{[]}}";
            this.bracketStack = new Stack<string>();
        }

        public BracketExampleForStack(string str)
        {
            this.brackets = str;
            this.bracketStack = new Stack<string>();
        }

        public void resolveBrackets()
        {


            string _char;

            for (int x = 0; x < brackets.Length; x++)
            {
                bracketStack.Push(brackets.Substring(x,1));
            }

            int pos = 0;
            while (bracketStack.Count > 0)
            {
                _char = bracketStack.Pop();

                var reversedChar = !string.IsNullOrEmpty(reverseChar(_char)) ? reverseChar(_char) : _char;

                if (reversedChar != brackets.Substring(pos, 1))
                {
                    isBalanced = false;
                    break;
                }
                pos++;
            }

            if (isBalanced && bracketStack.Count > 0)
                Console.WriteLine(brackets + " is balanced!");
            else if (!isBalanced && bracketStack.Count > 0)
                Console.WriteLine(brackets + " is not balanced!");
            else
                throw new InvalidOperationException("Sequence has no element!");
            Console.ReadLine();
        }

        public void optimizedResolveBrackets()
        {
            bool isValid = true;
            Dictionary<string, string> charIdentifier = new Dictionary<string, string>();
            charIdentifier["}"] = "{";
            charIdentifier[")"] = "(";
            charIdentifier["]"] = "[";
            charIdentifier[">"] = "<";

            string _char;
            for(int x = 0; x < brackets.Length; x++)
            {
                _char = brackets.Substring(x,1);
                //Check if dictionary contains key
                if (charIdentifier.ContainsKey(_char))
                {
                    //Pop first element from the stack to see if that's the opening bracket
                    string topElement = bracketStack.Count == 0 ? "#" : bracketStack.Pop();

                    // If the mapping for this bracket doesn't match the stack's top element, return false.
                    if (topElement != charIdentifier[_char])
                    {
                        isValid = false;
                    }
                }
                else
                {
                    bracketStack.Push(_char);
                }
            }
            if (bracketStack.Count > 0)
            {
                isValid = false;
            }
            Console.ReadLine();
        }

        private string reverseChar(string ch)
        {
            if (ch == "}")
                return "{";
            else if (ch == "]")
                return "[";
            else if (ch == ")")
                return "(";
            if (ch == "{")
                return "}";
            else if (ch == "[")
                return "]";
            else if (ch == "(")
                return ")";
            else
                return "";
        }

    }
}
