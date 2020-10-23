using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresTest
{
    public class _2DArray
    {
        private int endingRowIndex;
        private int endingColumnIndex;
        private int[,] arr;
        Random random = new Random();

        public _2DArray(int m, int n)
        {
            this.endingRowIndex = m - 1;
            this.endingColumnIndex = n - 1;
            this.arr = new int[4, 5] {
                                       {0, 1, 2, 3, 2} ,   /*  initializers for row indexed by 0 */
                                       {4, 5, 6, 7, 11} ,   /*  initializers for row indexed by 1 */
                                       {8, 9, 10, 11, 17},
                                       {0, 1, 2, 3, 2}/*  initializers for row indexed by 2 */
                                    };

            //for (int row = 0; row <= endingRowIndex; row++)
            //{
            //    for (int column = 0; column <= endingColumnIndex; column++)
            //    {
            //        arr[row, column] = random.Next(0,25);
            //    }
            //}
        }

        public void SpiralPrint()
        {
            int startingRowIndex = 0;
            int startingColumnIndex = 0;

            while (startingRowIndex <= endingRowIndex && startingColumnIndex <= endingColumnIndex)
            {
                for(int i = startingColumnIndex; i <= endingColumnIndex; i++)
                {
                    Console.WriteLine(" {0} ", arr[startingRowIndex, i]);
                }
                startingRowIndex++;

                for (int i = startingRowIndex; i <= endingRowIndex; i++)
                {
                    Console.WriteLine(" {0} ", arr[i, endingColumnIndex]);
                }
                endingColumnIndex--;

                if(startingRowIndex<= endingRowIndex)
                {
                    for(int i = endingColumnIndex; i >= startingColumnIndex; i--)
                    {
                        Console.WriteLine(" {0} ", arr[endingRowIndex, i]);
                    }
                    endingRowIndex--;
                }

                if (startingColumnIndex <= endingColumnIndex)
                {
                    for (int i = endingRowIndex; i >= startingRowIndex; i--)
                    {
                        Console.WriteLine(" {0} ", arr[i, startingColumnIndex]);
                    }
                    startingColumnIndex++;
                }
            }
            //for (int i = startingColumnIndex; i <= endingColumnIndex; i++)
            //{
            //    Console.WriteLine(" {0} ", arr[startingRowIndex, i]);
            //}

            //startingColumnIndex = endingColumnIndex;

            //startingRowIndex += 1;

            //for (int j = startingRowIndex; j <= endingRowIndex; j++)
            //{
            //    Console.WriteLine(" {0} ", arr[j, endingColumnIndex]);
            //}

            //startingRowIndex = endingRowIndex;
            //endingColumnIndex -= 1;

            //for (int k = endingColumnIndex; k >= 0; k--)
            //{
            //    Console.WriteLine(" {0} ", arr[startingRowIndex, k]);
            //}
            //endingColumnIndex = 0;
            //startingRowIndex -= 1;
            //startingColumnIndex -= 1;

            //for (int l = endingColumnIndex; l <= startingColumnIndex; l++)
            //{
            //    Console.WriteLine(" {0} ", arr[startingRowIndex, l]);
            //}
        }
    }
}
