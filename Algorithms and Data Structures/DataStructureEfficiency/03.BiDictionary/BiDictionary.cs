namespace BiDictionary
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    public class BiDictionary<K1, K2, V> : IEnumerable<Triple<K1, K2, V>>
    {
        private readonly HashSet<Triple<K1, K2, V>> dictionary;
        
        public int Count
        {
            get
            {
                return this.dictionary.Count;
            }
        }

        public BiDictionary()
        {
            this.dictionary = new HashSet<Triple<K1, K2, V>>();
        }

        public void Add(K1 key1, K2 key2, V value)
        {
            dictionary.Add(new Triple<K1, K2, V>(key1, key2, value));
        }

        public void Add(K1 key1, V value)
        {
            dictionary.Add(new Triple<K1, K2, V>(key1, value));
        }

        public bool Contains(K1 key1, K2 key2, V value)
        {
            return this.dictionary.Any((x) => x.Key1.Equals(key1) && x.Key2.Equals(key2) && x.Value.Equals(value));
        }

        public bool Contains(K1 key1, V value)
        {
            return this.dictionary.Any((x) => x.Key1.Equals(key1) && x.Value.Equals(value) && x.Key2 == null);
        }

        public IEnumerable<V> GetByFirstKey(K1 key)
        {
            var values = this.dictionary.Where(item => item.Key1.Equals(key)).Select(item => item.Value);
            if (values.Count() == 0)
            {
                throw new ArgumentException("There are no values with such key!");
            }
            return values;
        }

        public IEnumerable<V> GetBySecondKey(K2 key)
        {
            var values = this.dictionary.Where(item => item.Key2.Equals(key)).Select(item => item.Value);
            if (values.Count() == 0)
            {
                throw new ArgumentException("There are no values with such key!");
            }
            return values;
        }

        public IEnumerable<V> GetByBothKeys(K1 key1, K2 key2)
        {
            var values = this.dictionary.Where(item => item.Key1.Equals(key1) && item.Key2.Equals(key2)).Select(item => item.Value);
            if (values.Count() == 0)
            {
                throw new ArgumentException("There are no values with such key!");
            }
            return values;
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<Triple<K1, K2, V>> GetEnumerator()
        {
            foreach (var item in this.dictionary)
            {
                yield return item;
            }
        }
    }
}