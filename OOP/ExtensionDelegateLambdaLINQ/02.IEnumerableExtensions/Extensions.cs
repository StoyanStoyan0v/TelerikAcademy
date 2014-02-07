namespace IEnumerableExtensions
{
    using System.Collections.Generic;

    public static class Extensions
    {
        //All the methods have constraits to structures (int, double, float...) so they can be manipulated...

        public static T Sum<T> (this IEnumerable<T> collection) where T : struct
        {
            dynamic sum = 0;

            foreach (var item in collection)
            {
                sum += item;
            }

            return sum;
        }

        public static T Product<T>(this IEnumerable<T> collection) where T : struct
        {
            dynamic element = 1;

            foreach (var item in collection)
            {
                element *= item;
            }

            return element;
        }

        public static T Min<T>(this IEnumerable<T> collection) where T : struct
        {
            dynamic element = ulong.MaxValue;

            foreach (var item in collection)
            {
                if(item<element)
                {
                    element = item;
                }
            }

            return element;
        }

        public static T Max<T>(this IEnumerable<T> collection) where T : struct
        {
            dynamic element = ulong.MinValue;

            foreach (var item in collection)
            {
                if(item>element)
                {
                    element = item;
                }
            }

            return element;
        }

        public static T Average<T>(this IEnumerable<T> collection) where T : struct
        {
            dynamic sum = 0;
            int count = 0;

            foreach (var item in collection)
            {
                sum += item;
                count++;
            }

            return sum/count;
        }
    }
}
