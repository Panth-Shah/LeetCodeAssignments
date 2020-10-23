using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresTest
{
    public class ArrayTest<T>
    {
        private int len = 0;
        private int Capacity = 0;
        private T[] arr = new T[0];

        public ArrayTest()
        {
            this.Capacity = 16;
        }
        public ArrayTest(int capacity)
        {
            if (capacity < 0) throw new ArgumentException("Illigal Capacity: " + capacity);
            this.Capacity = capacity;
            this.arr = new T[Capacity];
        }
        public int size() { return len; }
        public bool isEmpty() { return size() == 0; }
        public T GetT(int index) { return arr[index]; }
        public void SetT(int index, T elem) { arr[index] = elem; }
        public void clear()
        {
            for (int i = 0; i < Capacity; i++)
            {
                arr[i] = default(T);
            }
            len = 0;
        }
        public void add(T elem)
        {
            if (len + 1 >= Capacity)
            {
                if (Capacity == 0)
                {
                    Capacity = 1;
                }
                else
                {
                    Capacity *= 2;
                }

                T[] new_arr = new T[Capacity];
                for (int i = 0; i < len; i++)
                {
                    new_arr[i] = arr[i];
                }
                arr = new_arr;
            }
            arr[len++] = elem;
        }

        public T removeAt(int rm_index)
        {
            if (rm_index >= len && rm_index < 0) throw new IndexOutOfRangeException();
            T data = arr[rm_index];
            T[] new_arr = new T[len - 1];
            for (int i = 0, j = 0; i < len; i++, j++)
            {
                if (i == rm_index)
                {
                    j--;
                }
                else
                {
                    new_arr[j] = arr[i];
                }
            }
            arr = new_arr;
            Capacity = --len;
            return data;
        }
        //public IEnumerator GetEnumerator()
        //{

        //}
        //    }
    }
}
