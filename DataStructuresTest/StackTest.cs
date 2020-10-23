using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresTest
{
    //Stack is a one-ended liner data structure which models a real world stack by having two primary operations: POP & PUSH
    //USAGE:
    //Text Editors, COmpiler syntex checking for matching brackets and braces, model a pile of books or plates, used behind the scenes to support recurrsion by
    //keeping track of previous function calls, used to do a Deapth First Search (DFS) on a graph

    //Example: Bracket Sequence is Valid or Invalid
    public class StackTest<T>
    {
        private int p_index;
        private List<T> _list;
        
        //Create empty list with Index set to -1 
        public StackTest()
        {
            _list = new List<T>();
            p_index = -1;
        }

        //Returns size of stack
        public int count
        {
            get
            {
                return _list.Count;
            }
        }

        //Push an element on the stack
        public void push(T element)
        {
            _list.Add(element);
            p_index++;
        }
        public bool isEmpty()
        {
            return count == 0;
        }

        //Pop element off of stack
        //Throw an error if the stack is empty
        public T pop()
        {
            if (isEmpty()) throw new InvalidOperationException("Sequence contains no elements");
            T element = _list[p_index];
            _list.RemoveAt(p_index);
            p_index--;
            return element;
        }

        //Remove all the elements from stack
        public void clear()
        {
            _list.Clear();
            p_index = -1;
        }

        //Peek the top of the stack without removing an element
        //Throw exception if stack is empty
        public object peek()
        {
            if (isEmpty()) throw new InvalidOperationException("Sequence contains no elements");
            return _list[p_index];
        }
    
    }
}
