namespace HashTable
{
    using System;
    using System.Collections;    
    using System.Collections.Generic;

    public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        private const float RESIZING_FACTOR = 0.75f;
        private int capacity = 16;
        private LinkedList<KeyValuePair<K, T>>[] keyValuePairs;
        private readonly HashSet<K> keys = new HashSet<K>();
        private int bucketsOccupied = 0;

        public int Count { get; private set; }

        public T this[K key]
        {
            get
            {
                return this.Find(key);
            }
            set
            {
                int index = this.GetIndex(key);
                if (this.keyValuePairs[index] == null)
                {
                    this.Add(key, value);
                }
                else
                {
                    foreach (var item in this.keyValuePairs[index])
                    {
                        if (item.Key.Equals(key))
                        {
                            var pair = new KeyValuePair<K, T>(key, value);
                            this.keyValuePairs[index].Remove(item);
                            this.keyValuePairs[index].AddFirst(pair);
                            return;
                        }
                    }
                }
            }
        }

        public HashSet<K> Keys
        {
            get
            {
                return this.keys;
            }
        }

        public HashTable()
        {
            this.keyValuePairs = new LinkedList<KeyValuePair<K, T>>[this.capacity];
        }

        public void Add(K key, T value)
        {
            if (key == null)
            {
                throw new ArgumentException("Key cannot be null!");
            }

            if (value == null)
            {
                throw new ArgumentException("Value cannot be null!");
            }

            this.ResizeArray();

            int index = this.GetIndex(key);

            if (this.keyValuePairs[index] == null)
            {
                this.keyValuePairs[index] = new LinkedList<KeyValuePair<K, T>>();
                this.bucketsOccupied++;
            }
            else
            {
                foreach (var keyValuePair in this.keyValuePairs[index])
                {
                    if (keyValuePair.Key.Equals(key))
                    {
                        throw new ArgumentException("The key " + key + " has already been added!");
                    }
                }
            }

            this.Keys.Add(key);
            var newPair = new KeyValuePair<K, T>(key,value);
            this.keyValuePairs[index].AddFirst(newPair);
            this.Count++;
        }

        public void Remove(K key)
        {
            int index = this.GetIndex(key);
            if (this.keyValuePairs[index] == null)
            {
                throw new ArgumentException("An element with key" + key + " does not exist!");
            }
            else
            {
                foreach (var item in this.keyValuePairs[index])
                {
                    if (item.Key.Equals(key))
                    {
                        this.keyValuePairs[index].Remove(item);
                        this.Count--;
                        keys.Remove(key);
                        return;
                    }
                }
            }
            throw new ArgumentException("An element with key" + key + " does not exist!");
        }

        public T Find(K key)
        {
            int index = this.GetIndex(key);
            if (this.keyValuePairs[index] == null)
            {
                throw new ArgumentException("The element with this key does not exist!");
            }
            else
            {
                foreach (var item in this.keyValuePairs[index])
                {
                    if (item.Key.Equals(key))
                    {
                        return item.Value;
                    }
                }

                throw new ArgumentException("There is no element with this key!");
            }
        }

        public void Clear()
        {
            foreach (var item in this.keyValuePairs)
            {
                if (item != null)
                {
                    item.Clear();
                }
            }
            this.Count = 0;
        }

        public bool ContainsKey(K key)
        {
            if (this.Keys.Contains(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            foreach (var item in this.keyValuePairs)
            {
                if (item != null)
                {
                    var next = item.First;
                    while (next != null)
                    {
                        yield return next.Value;
                        next = next.Next;
                    }
                }
            }
        }
        
        private void ResizeArray()
        {
            if (bucketsOccupied >= this.capacity * RESIZING_FACTOR)
            {
                var newKeyValuePairs = new LinkedList<KeyValuePair<K, T>>[this.capacity * 2];
                Array.Copy(this.keyValuePairs, newKeyValuePairs, this.capacity);
                this.keyValuePairs = newKeyValuePairs;
                this.capacity *= 2;
            }
        }

        private int GetIndex(K key)
        {
            return Math.Abs(key.GetHashCode() % this.keyValuePairs.Length);
        }
    }
}