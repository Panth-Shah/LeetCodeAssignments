using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresTest
{
    public class BigOTest
    {
        public BigOTest()
        {

        }
        public static void GetNumberIndex(int number, int arraySize, bool isSortedList)
        {
            int[] arr = new int[arraySize];
            int indexValue = -1;
            for(int i = 0; i < arraySize; i++)
            {
                arr[i] = i + 1;
            }

            var lowIndex = 0;
            var highIndex = arraySize - 1;

            while (lowIndex <= highIndex)
            {
                var midIndex = (lowIndex + highIndex) / 2;
                if (arr[midIndex] < number)
                {
                    Console.WriteLine("Low Index Before: {0}", lowIndex);
                    lowIndex = midIndex + 1;
                    Console.WriteLine("Low Index After: {0}", lowIndex);
                }
                else if (arr[midIndex] > number)
                {
                    Console.WriteLine("High Index Before: " + highIndex);
                    highIndex = midIndex - 1;
                    Console.WriteLine("High Index After: " + highIndex);
                }
                else if (arr[midIndex] == number)
                {
                    indexValue = midIndex;
                    break;
                }

            }

            if(indexValue > 0)
            {
                Console.WriteLine("Index vaue for Number: " + number + " is: " + indexValue);
            }
            else
            {
                Console.WriteLine("Unable to find Index for value: " + number);
            }
        }
    }
}
