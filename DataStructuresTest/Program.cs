using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresTest;

namespace DataStructuresTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //BigOTest.GetNumberIndex(13, 15, true);
            //ArrayTest<int> array = new ArrayTest<int>(15);
            //array.add(5);
            //array.removeAt(2);
            //_2DArray arr = new _2DArray(4, 5);
            //arr.SpiralPrint();

            //BinarySearchTree bstTest = new BinarySearchTree();
            //bstTest.Insert(50);
            //bstTest.Insert(55);
            //bstTest.Insert(57);
            //bstTest.Insert(45);
            //bstTest.Insert(52);
            //bstTest.Insert(42);
            //bstTest.Insert(47);
            //bstTest.Find(52);
            //var bstHeight = bstTest.Height(bstTest.root);
            //Console.WriteLine("InOrder Execution");
            //bstTest.InOrder(bstTest.root);
            //Console.WriteLine("PreOrder Execution");
            //bstTest.PreOrder(bstTest.root);

            //Problem: Check if the string is Palindrom
            //StringPalindromExample test1 = new StringPalindromExample();
            //test1.StringPalindromCheck("test");

            //Problem: Check if brackets are balanced
            BracketExampleForStack test2 = new BracketExampleForStack("{{}{}}{}");
            test2.resolveBrackets();

            //Problem: Generate HashFunction for String inputs
            //HashFunctionLogicTest hashTest = new HashFunctionLogicTest();
            //hashTest.TestSimpleHash(); 

            //Probelm: Separate Collision Test
            //HashFunctionLogicTest hashTest = new HashFunctionLogicTest();
            //hashTest.TestSimpleHash();
        }
    }
}
