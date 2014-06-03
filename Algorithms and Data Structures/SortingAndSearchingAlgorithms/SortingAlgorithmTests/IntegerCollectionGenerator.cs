using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithmTests
{
    public static class IntegerCollectionGenerator
    {
        private static readonly IList<int> collection = new List<int>();

        public static IList<int> Generate(int countOfElements)
        {
            for (int i = 0; i < countOfElements; i++)
            {
                collection.Add(new Random().Next(int.MinValue,int.MaxValue));
            }

            return collection;
        }
    }
}