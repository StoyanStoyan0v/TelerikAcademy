using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class Queue<T> : IEnumerable<T>
    {
        private class Node
        {
            public T Value { get; set; }

            public Node NextNode { get; set; }
        }
        
        private Node firstValue;

        public int Count { get; private set; }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("The queue is empty.");
            }

            T item = this.firstValue.Value;
            this.firstValue = this.firstValue.NextNode;
            this.Count--;

            return item;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("The queue is empty.");
            }

            return this.firstValue.Value;
        }

        public void Enqueue(T element)
        {
            if (this.firstValue == null)
            {
                this.firstValue = new Node();
                this.firstValue.Value = element;
                this.firstValue.NextNode = null;
                this.Count++;
            }
            else
            {
                Node currentItem = this.firstValue;
                while (currentItem.NextNode != null)
                {
                    currentItem = currentItem.NextNode;
                }

                Node newItem = new Node();
                newItem.Value = element;
                newItem.NextNode = null;
                currentItem.NextNode = newItem;
                this.Count++;
            }
        }

        public bool Contains(T element)
        {
            foreach (var item in this)
            {
                if (item.Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            this.firstValue = null;
            this.Count = 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currentItem = this.firstValue;
            while (currentItem != null)
            {
                yield return currentItem.Value;
                currentItem = currentItem.NextNode;
            }
        }
    }
}