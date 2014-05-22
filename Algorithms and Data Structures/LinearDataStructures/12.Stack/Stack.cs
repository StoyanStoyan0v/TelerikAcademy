namespace Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    public class Stack<T> : IEnumerable<T> 
    {
        private const int DEFAULT_CAPACITY = 16;
        private T[] stack;
        private int capacity;

        public int Count { get; private set; }

        public Stack(int capacity = DEFAULT_CAPACITY)
        {
            this.capacity = capacity;
            stack = new T[this.capacity];
        }

        public void Push(T element)
        {
            if (this.Count < this.capacity)
            {
                stack[this.Count] = element;
            }
            else
            {
                this.Resize();
                stack[this.Count] = element;
            }
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("The stack is empty.");
            }
            
            T item = stack[this.Count - 1];
            
            this.Count--;
            return item;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("The stack is empty.");
            }

            return stack[this.Count - 1];
        }

        public bool Contains(T element)
        {
            for (int item = 0; item < this.Count; item++)
            {
                if (stack[item].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            this.stack = new T[DEFAULT_CAPACITY];
            this.Count = 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 1; i <= this.Count; i++)
            {
                yield return stack[i - 1];
            }
        }

        private void Resize()
        {
            this.capacity *= 2;
            T[] newArray = new T[this.capacity];
            for (int i = 0; i < stack.Length; i++)
            {
                newArray[i] = stack[i];
            }
            stack = newArray;
        }
    }
}