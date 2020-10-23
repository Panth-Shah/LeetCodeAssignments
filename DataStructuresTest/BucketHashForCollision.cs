using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresTest
{
    public class BucketHashForCollision<T>
    {
        ArrayList[] data;
        public BucketHashForCollision()
        {
            data = new ArrayList[101];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = new ArrayList(4);
            }
        }
        public int betterHash(string hashValue)
        {
            //HashKey will be addition of all the ASCII values
            long hashIndex = 0;
            char[] cname;
            cname = hashValue.ToCharArray();
            byte[] asciiBytes = Encoding.ASCII.GetBytes(cname);

            //for (int i = 0; i <= cname.GetUpperBound(0); i++)
            //    tot += (int)cname[i];
            foreach (byte val in asciiBytes)
            {
                hashIndex += 37 * hashIndex + val;
            }
            hashIndex = hashIndex % data.Length;
            if (hashIndex < 0)
            {
                hashIndex += data.Length;
            }
            return (int)hashIndex;
        }

        public void InsertElement (string element)
        {
            int hashIndex;
            hashIndex = betterHash(element);
            if (!data[hashIndex].Contains(element))
                data[hashIndex].Add(element);
        }

        public void removeElement(string element)
        {
            int hashIndex;
            hashIndex = betterHash(element);
            if (data[hashIndex].Contains(element))
                data[hashIndex].Remove(element);
        }

        public void ShowDistrib()
        {
            for (int i = 0; i <= data.Length; i++)
                if (data[i] != null)
                    Console.WriteLine(i + " " + data[i]);
            Console.ReadLine();
        }


    }
}
