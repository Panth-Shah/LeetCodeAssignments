using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresTest
{
    public class HashFunctionLogicTest
    {
        public HashFunctionLogicTest()
        {

        }

        public void TestSimpleHash()
        {
            //HashFunctionLogic hashFunction = new HashFunctionLogic();
            BucketHashForCollision<string> hashFunction = new BucketHashForCollision<string>();

            //string[] someNames = new string[]{"David",
            //"Jennifer", "Donnie", "Mayo", "Raymond",
            //"Bernica", "Mike", "Clayton", "Beata", "Michael"};
            string[] someNames = new string[] {"lies", "foes"};
            string name;
            for (int x = 0; x < someNames.Length; x++)
            {
                name = someNames[x];
                hashFunction.InsertElement(name);
            }
            hashFunction.ShowDistrib();
        }
    }
}
