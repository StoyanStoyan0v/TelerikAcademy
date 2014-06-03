namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection for sorting cannot be null!");
            }
        
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[i].CompareTo(collection[j]) > 0)
                    {
                        T newValue = collection[i];
                        collection[i] = collection[j];
                        collection[j] = newValue;
                    }
                }
            }
        }
    }
}