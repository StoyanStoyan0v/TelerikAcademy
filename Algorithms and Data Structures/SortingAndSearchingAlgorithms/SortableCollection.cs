namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public bool BinarySearch(T item)
        {
            int start = 0;
            int end = this.Items.Count - 1;

            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (this.Items[mid].Equals(item))
                {
                    return true;
                }
                else if (this.Items[mid].CompareTo(item) > 0)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }
            return false;
        }

        public void Shuffle()
        {
            for (int i = this.Items.Count - 1; i >= 0; i--)
            {
                var position = new Random().Next(i);
                var temp = this.Items[i];
                this.Items[i] = this.Items[position];
                this.Items[position] = temp;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}