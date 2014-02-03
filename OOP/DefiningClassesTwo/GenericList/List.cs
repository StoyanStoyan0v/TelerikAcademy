namespace GenericList
{
    using System;
    using System.Text;
    //Inherit the IComparable interface for generic types to make the data comparison available.
    public class GenericList<T>  where T : IComparable<T>
    {
        private const int DEFAULT_CAPACITY = 10;
        private T[] array;
        private int capacity;

        public GenericList(int capacity = DEFAULT_CAPACITY)
        {           
            this.Count = 0;
            this.Capacity = capacity;
            this.array = new T[capacity];
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set
            {
                if(value<0)
                {
                    throw new IndexOutOfRangeException("The list capacity cannot be a negative number!");
                }
                this.capacity = value;
            }
        }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.array.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                return this.array[index];
            }

            set
            {
                if (index < 0 || index >= this.array.Length)
                {
                    throw new IndexOutOfRangeException();
                }

                this.array[index] = value;
            }
        }

        public void Add(T element)
        {
            if(this.Count>=this.array.Length)
            {
                ResizeList();
            }
            this.array[this.Count] = element;
            this.Count++;
        }
       
        public void Insert(T element, int position)
        {
            if (position < 0 || position >= this.array.Length)
            {
                throw new IndexOutOfRangeException();
            }

            T[] left = new T[position];
            T[] right = new T[this.array.Length - position];
            Array.Copy(this.array, 0, left, 0, left.Length);
            Array.Copy(this.array, position, right, 0, right.Length);      
                                   
            this.ResizeList();            
                        
            Array.Copy(left, 0, this.array, 0, left.Length);
            this.array[position] = element;
            Array.Copy(right, 0, this.array, position + 1, right.Length);
            Count++;
        }

        public void RemoveAt(int position)
        {
            if (position < 0 || position >= this.array.Length)
            {
                throw new IndexOutOfRangeException();
            }
            T[] left = new T[position];
            T[] right = new T[this.array.Length - position-1];
            Array.Copy(this.array, 0, left, 0, left.Length);
            Array.Copy(this.array, position+1, right, 0, right.Length);
            Array.Copy(left, 0, this.array, 0, left.Length);
            Array.Copy(right, 0, this.array, position, right.Length);
            Count--;
           
        }

        public int IndexOf(T element)
        {
            return Array.IndexOf(this.array, element);
        }        

        public void Clear()
        {
            this.array = new T[this.Capacity];
            this.Count = 0;
        }


        public T Min() 
        {
            T min = this.array[0];
            for (int i = 1; i < this.Count; i++)
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
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                result.Append(array[i]+" ");
            }

            return result.ToString().Trim();
        }

        private void ResizeList()
        {
            this.Capacity *= 2;
            T[] tempArr = new T[this.Capacity];           
            Array.Copy(this.array, tempArr, this.Count);
            this.array = new T[this.Capacity];
            Array.Copy(tempArr, this.array, this.Count);
        }
    }
}
