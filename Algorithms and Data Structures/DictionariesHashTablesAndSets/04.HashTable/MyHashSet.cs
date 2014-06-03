namespace HashTable
{
    using System;
    using System.Collections;    
    using System.Collections.Generic;

    public class MyHashSet<T> : IEnumerable<T>
    {
        private readonly HashTable<int, T> set;

        public int Count { get; private set; }

        public MyHashSet(IEnumerable<T> collection = null)
        {
            this.set = new HashTable<int, T>();

            if (collection != null)
            {
                foreach (var item in collection)
                {
                    if (!this.Find(item))
                    {
                        this.Add(item);
                    }
                }
            }
        }

        public void Add(T element)
        {
            if (!this.Find(element))
            {
                this.set.Add(this.Count, element);
                this.Count++;
            }
        }

        public void Remove(T element)
        {
            if (!this.Find(element))
            {
                throw new ArgumentException("There is no such element in the set!");
            }

            foreach (var item in this.set)
            {
                if (item.Value.Equals(element))
                {
                    this.set.Remove(item.Key);
                    return;
                }
            }
        }

        public bool Find(T element)
        {
            foreach (var item in this.set)
            {
                if (item.Value.Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            this.set.Clear();
            this.Count = 0;
        }

        public MyHashSet<T> UnionWith(MyHashSet<T> other)
        {
            var newSet = new MyHashSet<T>(this);

            foreach (var item in other)
            {
                if (!newSet.Find(item))
                {
                    newSet.Add(item);
                }
            }
            return newSet;
        }

        public MyHashSet<T> IntersectWith(MyHashSet<T> other)
        {
            var newSet = new MyHashSet<T>();

            foreach (var item in this)
            {
                if (other.Find(item))
                {
                    newSet.Add(item);
                }
            }

            return newSet;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.set)
            {
                yield return item.Value;
            }
        }
    }
}