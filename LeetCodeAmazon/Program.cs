using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeAmazon
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] input = new int[] { 5,5,11,2};
            //TwoSumProblem problem1 = new TwoSumProblem();
            //problem1.optimizedTwoSum(input, 10);

            //LongestSubString subStringProblem = new LongestSubString();
            //subStringProblem.LengthOfLongestSubstring("aaaaaaaaaabbbbbbb");

            //StringToInt stringInt = new StringToInt();
            //Console.WriteLine(stringInt.MyAtoi("0-2"));
            //Console.ReadLine();

            //int[] input = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            //MostWaterContainerProblem prob = new MostWaterContainerProblem();
            //prob.MaxArea(input);

            //RomanToInt pro = new RomanToInt();
            //Console.WriteLine(pro.IntToRoman(998));
            //Console.ReadLine();

            //3Sum Problem
            //int[] input = new int[] {-1, 0, 1, 2, -1, -4};
            //_3SumProblem sumProblem = new _3SumProblem();
            //sumProblem.ThreeSum(input);

            //strStr problem
            //ImplementstrStr__ strStr = new ImplementstrStr__();
            //Console.WriteLine(strStr.StrstrbyHash("aaaa", "aab"));
            //Console.ReadLine();

            //Group Anargam problem
            //string[] input = { "eat", "tea", "tan", "ate", "nat", "bat" };
            //GroupAnagram grpAna = new GroupAnagram();
            //grpAna.improvedGroupAnagrams(input);

            //Linked List Add Two Numbers
            //[2,4,3]
            //[5,6,4]
            //LLAddTwoNumbers addNumbers = new LLAddTwoNumbers();
            //ListNode value1 = new ListNode(243);
            //ListNode value2 = new ListNode(564);

            //addNumbers.addTwoNumbers(value1, value2);

            //Rotate image
            //int[,] arr = new int[3, 3] {
            //                           {1, 2, 3} ,   /*  initializers for row indexed by 0 */
            //                           {4, 5, 6} ,   /*  initializers for row indexed by 1 */
            //                           {7, 8, 9}/*  initializers for row indexed by 2 */
            //                        };
            //RotateImage imgObj = new RotateImage();
            //imgObj.Rotate(arr);

            //Maximum rectengle from matrix
            //char[,] arr = new char[4, 5] {
            //                           { '1','0','1','0','0'},   /*  initializers for row indexed by 0 */
            //                           {'1','0','1','1','1'},   /*  initializers for row indexed by 1 */
            //                           {'1','1','1','1','1'},
            //                           {'1','0','0','1','0'}/*  initializers for row indexed by 2 */
            //                           };
            ////char[,] arr = new char[1, 2] { {'0', '1'} };
            //MaximumRectangleFromMatrix maxRec = new MaximumRectangleFromMatrix();
            //maxRec.MaximalRectangle(arr);

            //Kth Largest

            KthLargest kLarge = new KthLargest(3, new int[] { 4, 5, 8, 2});
            kLarge.Add(3);
            kLarge.Add(5);
            kLarge.Add(10);
            kLarge.Add(9);
            kLarge.Add(4);
        }
    }
}
