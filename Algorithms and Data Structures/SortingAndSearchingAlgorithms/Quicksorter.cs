namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        private IList<T> elements;

        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection for sorting cannot be null!");
            }
            this.elements = collection;
            QuickSort(0, collection.Count - 1);
        }

        private void QuickSort(int left, int right)
        {
            if (left < right)
            {
                int i = left, j = right;
                T pivot = elements[(left + right) / 2];
 
                while (i <= j)
                {
                    while (elements[i].CompareTo(pivot) < 0)
                    {
                        i++;
                    }
 
                    while (elements[j].CompareTo(pivot) > 0)
                    {
                        j--;
                    }
 
                    if (i <= j)
                    {
                        // Swap
                        T tmp = elements[i];
                        elements[i] = elements[j];
                        elements[j] = tmp;
 
                        i++;
                        j--;
                    }
                }
                
                // Recursive calls
                if (left < j)
                {
                    QuickSort(left, j);
                }
 
                if (i < right)
                {
                    QuickSort(i, right);
                }
            }
        }
    }
}