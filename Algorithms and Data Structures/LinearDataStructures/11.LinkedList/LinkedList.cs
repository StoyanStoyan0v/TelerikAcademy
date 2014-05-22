using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class LinkedList<T> : IEnumerable<T>
    {
        private class ListItem
        {
            public T Value { get; set; }

            public ListItem NextItem { get; set; }
        }
        
        private ListItem firstValue;

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            ListItem newItem = new ListItem();
            newItem.Value = element;
            newItem.NextItem = this.firstValue;
            this.firstValue = newItem;
            this.Count++;
        }

        public void AddLast(T element)
        {
            ListItem nextItem = this.firstValue;

            if (this.firstValue == null)
            {
                this.firstValue = new ListItem();
                this.firstValue.Value = element;
                this.firstValue.NextItem = null;
                this.Count++;
            }
            else
            {
                ListItem currentItem = this.firstValue;
                while (currentItem.NextItem != null)
                {
                    currentItem = currentItem.NextItem;
                }

                ListItem newItem = new ListItem();
                newItem.Value = element;
                newItem.NextItem = null;
                currentItem.NextItem = newItem;
                this.Count++;
            }
        }

        public void Remove(T element)
        {
            ListItem currentItem = this.firstValue;
            while (true)
            {
                if (currentItem.NextItem.Value.Equals(element))
                {
                    ListItem newItem = currentItem.NextItem.NextItem;                   
                    
                    currentItem.NextItem = newItem;
                    break;
                }
                currentItem = currentItem.NextItem;
            }
        }

        public void Clear()
        {
            this.firstValue = null;
            this.Count = 0;
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListItem currentItem = this.firstValue;
            while (currentItem != null)
            {
                yield return currentItem.Value;
                currentItem = currentItem.NextItem;
            }
        }
    }
}