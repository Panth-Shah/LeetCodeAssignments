using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    class CArray
    {
        private int[] arr;
        private int upper;
        private int numElements;
        private int size;

        public CArray()
        {
            size = 10;
            arr = new int[size];
            upper = size - 1;
            numElements = 0;
        }

        //Initialize Array with given Size
        public CArray(int size)
        {
            this.size = size;
            arr = new int[size];
            upper = size - 1;
            numElements = 0;
        }

        //Insert element in array
        public void Insert(int item)
        {
            arr[numElements] = item;
            numElements++;
        }

        //Display All the elements in array
        public void DisplayElements()
        {
            for(int i = 0; i <= upper; i++)
            {
                Console.WriteLine(arr[i] + " ");
            }
        }
        
        //Clear array: Remove all the elements from the array
        public void Clear()
        {
            for(int i = 0; i <= upper; i++)
            {
                arr[i] = 0;
            }
            numElements = 0;
        }

        public void performBubbleSort(int[] nums)
        {
            int temp;
            for (int outer = nums.Length - 1; outer >= 1; outer--)
            {
                //We won't check swap for last element of an array and so we will iterate through outer - 1 
                //so for Array of size 5, we will only iterate through index 3 and index 4 will be the end of an array
                for (int inner = 0; inner <= outer - 1; inner++)
                {
                    if ((int)nums[inner] > nums[inner + 1])
                    {
                        swap(nums[inner], nums[inner + 1]);
                    }
                }
            }
            DisplayElements();
        }

        public void performSelectionSort(int[] nums)
        {
            for(int x = 0; x <= upper; x++)
            {
                //Assign first element of an array as min value
                int min = x;
                //From second element of an array loop through end of an arry to find if min is minimum element of an array
                for (int i = x + 1; i <= upper; i++)
                {
                    //If element at i is small than value at the beggining of an unsorted array, assign smaller value to min location in the beggining of an array
                    if (nums[i] > nums[min])
                    {
                        min = i;
                    }
                }
                //Swap min element with currently pointed element
                swap(nums[x], nums[min]);
            }
            DisplayElements();
        }

        public void performInsertionSort(int[] nums)
        {
            int temp;
            //outer loop will loop through unsorted array starting from index 1 as index 0 is defaulted to sorted array
            for (int outer = 1; outer <= upper; outer ++)
            {
                //assign first value of unsorted value into temp variable
                temp = nums[outer];
                int inner = outer;
                //Loop backwards to sorted list and check where to place temp and shift other elements one place in sorted manner
                while (inner > 0 && nums[inner-1] >= temp )
                {
                    nums[inner] = nums[inner - 1];
                    inner -= 1;
                }
                //Insert temp value at a place in array where any element before that index will be less than temp value
                nums[inner] = temp;
            }
        }

        public void performShellSort(int[] nums)
        {
            upper = nums.Length - 1;
            int gap = Math.Abs(upper / 2);
            while (gap >= 1)
            {
                for (int outer = gap; outer <= upper; outer++)
                {
                    int inner = outer - gap;
                    while (inner >= 0 && inner <= gap)
                    {
                        if (nums[inner + gap] > nums[inner])
                        {
                            break;
                        }
                        else
                        {
                            int temp = nums[inner + gap];
                            nums[inner + gap] = nums[inner];
                            nums[inner] = temp;
                            inner++;
                            outer++;
                        }
                    }
                }
                gap = gap / 2;
            }
        }

        private void swap(int ele1, int ele2)
        {
            int temp = ele1;
            ele1 = ele2;
            ele2 = temp;
        }

        static void Main(string[] args)
        {
            CArray nums = new CArray(11);
            Random rand = new Random(100);
            for (int i = 0; i < nums.size; i++)
            {
                nums.Insert((int)(rand.NextDouble() * 100));
            }

            int[] input = new int[] { 23,29,15,19,31,7,9,5,2};
            nums.performShellSort(input);

            Console.WriteLine("Before Bubble Sort: ");
            nums.DisplayElements();
            Console.WriteLine("In between Bubble Sort: ");
            nums.performBubbleSort(nums.arr);
            Console.WriteLine("After Bubble Sort: ");
            nums.DisplayElements();
            Console.WriteLine("Before Select Sort: ");
            nums.DisplayElements();
            Console.WriteLine("In between Select Sort: ");
            nums.performSelectionSort(nums.arr);
            Console.WriteLine("After Select Sort: ");
            nums.DisplayElements();
            Console.ReadLine();
        }
    }
}
