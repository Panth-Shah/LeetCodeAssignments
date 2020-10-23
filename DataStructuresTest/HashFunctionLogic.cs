using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresTest
{
    public class HashFunctionLogic
    {
        private string[] names;
        public HashFunctionLogic()
        {
            names = new string[10007];
        }

        public void simpleHash(string s)
        {
            int tot = 0;
            char[] cname;
            cname = s.ToCharArray();
            byte[] asciiBytes = Encoding.ASCII.GetBytes(cname);

            //for (int i = 0; i <= cname.count; i++)
            //    tot += (int)cname[i];
            foreach (byte val in asciiBytes)
            {
                tot += val;
            }
            int hashValue = tot % names.Length;
            names[hashValue] = s;
        }

        public void betterHash(string s)
        {
            long tot = 0;
            char[] cname;
            cname = s.ToCharArray();
            byte[] asciiBytes = Encoding.ASCII.GetBytes(cname);

            //for (int i = 0; i <= cname.GetUpperBound(0); i++)
            //    tot += (int)cname[i];
            foreach (byte val in asciiBytes)
            {
                tot += 37*tot + val;
            }
            tot = tot % names.Length;
            if (tot < 0)
            {
                tot += names.Length;
            }
            int hashValue = (int)tot;
            names[hashValue] = s;
        }

        public void ShowDistrib()
        {
            for (int i = 0; i <= names.Length; i++)
                if (names[i] != null)
                    Console.WriteLine(i + " " + names[i]);
            Console.ReadLine();
        }
    }
}
