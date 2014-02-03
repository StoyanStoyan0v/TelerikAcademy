using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    //Inherit the IComparable interface for generic types to make the data comparison available.
    public class GenericList<T> where T:IComparable<T>
    {
        private const int DEFAULT_CAPACITY = 10;
        private T[] array;

        public GenericList(int capacity = DEFAULT_CAPACITY)
        {
            this.array = new T[capacity];
            this.Count = 0;
            this.Capacity = capacity;
        }

        public int Capacity { get; private set; }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= array.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                return array[index];
            }

            set
            {
                if (index < 0 || index >= array.Length)
                {
                    throw new IndexOutOfRangeException();
                }

                array[index] = value;
            }
        }

        public void Add(T element)
        {
            if(Count>=array.Length)
            {
                ResizeList();
            }
            this.array[Count] = element;
            Count++;
        }
       
        public void Insert(T element, int position)
        {
            if (position < 0 || position >= this.array.Length)
            {
                throw new IndexOutOfRangeException();
            }

            T[] left = new T[position];
            T[] right = new T[array.Length - position];
            Array.Copy(this.array, 0, left, 0, left.Length);
            Array.Copy(this.array, position, right, 0, right.Length);      
                                   
            ResizeList();            
                        
            Array.Copy(left, 0, this.array, 0, left.Length);
            this.array[position] = element;
            Array.Copy(right, 0, this.array, position + 1, right.Length); 
        }

        public void RemoveAt(int position)
        {
            if (position < 0 || position >= this.array.Length)
            {
                throw new IndexOutOfRangeException();
            }
            T[] left = new T[position];
            T[] right = new T[array.Length - position-1];
            Array.Copy(this.array, 0, left, 0, left.Length);
            Array.Copy(this.array, position+1, right, 0, right.Length);
            Array.Copy(left, 0, this.array, 0, left.Length);
            Array.Copy(right, 0, this.array, position, right.Length); 
        }

        public int IndexOf(T element)
        {
            return Array.IndexOf(this.array, element);
        }

        public override string ToString()
        {
            
            return string.Join(" ", this.array);
        }

        public void Clear()
        {
            Array.Clear(array, 0, array.Length);
        }


        public T Min() 
        {
            T min = this.array[0];
            for (int i = 1; i < Count; i++)
            {

                if ( this.array[i].CompareTo(min) < 0)
                {
                    min = this.array[i];
                }
            }

            return min;
        }

        public T Max()
        {
            T max = this.array[0];
            for (int i = 1; i < Count; i++)
            {

                if (this.array[i].CompareTo(max) > 0)
                {
                    max = this.array[i];
                }
            }

            return max;
        }

        private void ResizeList()
        {
            Capacity *= 2;
            T[] tempArr = new T[Capacity];           
            Array.Copy(this.array, tempArr, Count);
            array = new T[Capacity];
            Array.Copy(tempArr, this.array, Count);
        }
    }
}
