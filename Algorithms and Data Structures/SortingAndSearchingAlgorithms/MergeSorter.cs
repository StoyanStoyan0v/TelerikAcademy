namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection for sorting cannot be null!");
            }

            var sortedCollection = MergeSortMethod(collection.ToArray());
            collection.Clear();
            foreach (var item in sortedCollection)
            {
                collection.Add(item);
            }
        }

        private static T[] MergeSortMethod(T[] array)
        {
            if (array.Length == 1)
            {
                return array; //If the left/right subarray reach a length of 1, this bottom of the recursion returns the array of 1 element...
            }

            //Split the array into two parts...
            int middle = array.Length / 2;
            T[] left = new T[middle];
            for (int i = 0; i < middle; i++)
            {
                left[i] = array[i];
            }
            T[] right = new T[array.Length - middle];
            for (int i = 0; i < array.Length - middle; i++)
            {
                right[i] = array[i + middle];
            }

            //Recursively invoke this method to split and merge every left and right subarray into two parts until their length is 1...
            left = MergeSortMethod(left);
            right = MergeSortMethod(right);

            int l = 0;
            int r = 0;

            //Here we merge the recieved  subarrays from the recursions in otder to merge them...
            //After all the parts are recursively splited and sorted, the first started method comes here and merge the first two already         
            // sorted arrays and finally returns the whole array sorted...
            T[] sorted = new T[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if (l < left.Length && r < right.Length)
                {
                    if (left[l].CompareTo(right[r]) < 0)
                    {
                        sorted[i] = left[l];
                        l++;
                    }
                    else
                    {
                        sorted[i] = right[r];
                        r++;
                    }
                }
                else
                {
                    if (l < left.Length)
                    {
                        sorted[i] = left[l];
                        l++;
                    }
                    else
                    {
                        sorted[i] = right[r];
                        r++;
                    }
                }
            }
            return sorted;
        }
    }
}