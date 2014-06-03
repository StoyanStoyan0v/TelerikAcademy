using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparePerformanceBasic
{
    public static class ElementsGenerator
    {
        public static IList<string> StringsRandomGenerator(int count)
        {
            IList<string> collection = new string[count];
            for (int i = 0; i < count; i++)
            {
                collection[i] = "String" + new Random().Next();
            }
            return collection;
        }

        public static IList<int> IntegersRandomGenerator(int count)
        {
            IList<int> collection = new int[count];
            for (int i = 0; i < count; i++)
            {
                collection[i] = new Random().Next();
            }
            return collection;
        }

        public static IList<double> DoubleRandomGenerator(int count)
        {
            IList<double> collection = new double[count];
            for (int i = 0; i < count; i++)
            {
                collection[i] = new Random().NextDouble() * 100000;
            }
            return collection;
        }

        public static IList<string> StringsReversedGenerator(int count)
        {
            IList<string> collection = new string[count];
            for (int i = count - 1; i >= 0; i--)
            {
                collection[i] = "String" + i;
            }
            return collection;
        }

        public static IList<int> IntegersReversedGenerator(int count)
        {
            IList<int> collection = new int[count];
            for (int i = count - 1; i >= 0; i--)
            {
                collection[i] = i;
            }
            return collection;
        }

        public static IList<double> DoubleReversedGenerator(int count)
        {
            IList<double> collection = new double[count];
            for (int i = count - 1; i >= 0; i--)
            {
                collection[i] = (count - 1) * 0.1;
            }
            return collection;
        }
    }
}