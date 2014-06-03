namespace PriorityQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;
    
    public class PriorityQueue<T> : IEnumerable<T> where T : IEquatable<T>
    {
        private readonly OrderedBag<T> queue;

        public int Count
        {
            get
            {
                return this.queue.Count;
            }
        }

        public PriorityQueue()
        {
            this.queue = new OrderedBag<T>();
        }

        public T Dequeue()
        {
            return this.queue.RemoveFirst();
        }

        public void Enqueue(T element)
        {
            this.queue.Add(element);
        }

        public void EnqueueMany(IEnumerable<T> collection)
        {
            this.queue.AddMany(collection);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.queue)
            {
                yield return item;
            }
        }
    }
}