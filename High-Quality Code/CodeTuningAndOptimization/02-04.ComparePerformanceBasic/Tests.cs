using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparePerformanceBasic
{
    class Tests
    {
        static void Main(string[] args)
        {
            //02. Basic operations add, multiply, subtract, divide, increment operations tests.
            TestBasicOperations();

            //03. More advanced tests: square root, natural logarithm and sinus
            TestAdvancedOperations();

            //04. Ascendingly sorting tests: Selection, insertion and quick sort of random and descendingly sorted sets.
            TestSortingAlgorithms();
        }

        private static void TestSortingAlgorithms()
        {
            Console.WriteLine("Test random integers sorting: ");
            PrintSortingTests<int>(ElementsGenerator.IntegersRandomGenerator(20000));

            Console.WriteLine("Test random double sorting: ");
            PrintSortingTests<double>(ElementsGenerator.DoubleRandomGenerator(20000));

            Console.WriteLine("Test random strings sorting: ");
            PrintSortingTests<string>(ElementsGenerator.StringsRandomGenerator(20000));

            Console.WriteLine("Test reversed integers sorting: ");
            PrintSortingTests<int>(ElementsGenerator.IntegersReversedGenerator(20000));

            Console.WriteLine("Test reversed double sorting: ");
            PrintSortingTests<double>(ElementsGenerator.DoubleReversedGenerator(20000));

            Console.WriteLine("Test reversed strings sorting: ");
            PrintSortingTests<string>(ElementsGenerator.StringsReversedGenerator(20000));

            Console.WriteLine(new string('-',20));
        }

        private static void TestAdvancedOperations()
        {
            double numDouble = 3.14;
            Console.WriteLine("Test double operations: ");
            PrintAdvancedTests<double>(numDouble);
            float numFloat = 3.14f;
            Console.WriteLine("Test float operations: ");
            PrintAdvancedTests<float>(numFloat);
            decimal numDecimal = 3.14m;
            Console.WriteLine("Test decimal operations: ");
            PrintAdvancedTests<decimal>(numDecimal);

            Console.WriteLine(new string('-',20));
        }

        private static void TestBasicOperations()
        {
            var intCollection = new int[] { 3, 5, 2, 9, 10, 4, 32, 110000, 932819, -321421312, -2, 15151, -83215, 27 };            
            Console.WriteLine("Test integers operations: ");
            PrintBasicTests<int>(intCollection);

            var longCollection = new long[]
            {
                191919191919191, -123128382183, 55, 4, 12315412, 7, -521839214921321234, 110000,
                3213213, -8392175812, -2, 15151, 1200000000000000000, 27
            };
            Console.WriteLine("Test long operations: ");
            PrintBasicTests<long>(longCollection);

            var floatCollection = new float[]
            {
                3.14f, -3213.38321f, 55.555f, -0.92574f, 12315412.5213f, 7.0f, -52121.321234f, 110000.1f,
                3.213213f, -83921.75812f, -2.0f, 151.51f, 1000.1000f, -132.27f
            };
            Console.WriteLine("Test float operations: ");
            PrintBasicTests<float>(floatCollection);

            var doubleCollection = new double[]
            {
                3.14, -3213.383242131, 55.555555, -0.92574, 12315412.5213, 7.0, -52121.3212343212,
                110000.11111, 231233.213213, -83921.75812, -2.0, 151.51, 1000.10000000012342, -132.27
            };
            Console.WriteLine("Test double operations: ");
            PrintBasicTests<double>(doubleCollection);

            var decimalCollection = new decimal[]
            {
                332213.168921374823913264m, -3213.383281293887531342131m,
                5555555555.5555532131251231512316661235m, -0.925232232311509481256798376518274m, 12315412.5213m, 7.0m,
                -5212423123131.32123432152131232m, 110000.11111m, 231233.213213m, -83921.75812m, -2.0m, 151.51m, 1000.10000000012342m,
                -132.27m
            };
            Console.WriteLine("Test decimal operations: ");
            PrintBasicTests<decimal>(decimalCollection);

            Console.WriteLine(new string('-',20));
        }
        
        private static void PrintSortingTests<T>(IList<T> collection) where T : IComparable<T>
        {
            Console.WriteLine("Selection sort: " + new SortingTester<T>(new List<T>(collection)).SelectionSort());
            Console.WriteLine("Insertion sort: " + new SortingTester<T>(new List<T>(collection)).InsertionSort());
            Console.WriteLine("Quick sort: " + new SortingTester<T>(new List<T>(collection)).QuickSort());
            Console.WriteLine(new string('-',20));
        }

        private static void PrintAdvancedTests<T>(T num) where T : struct
        {
            AdvancedOperationsTester<T> tester = new AdvancedOperationsTester<T>(num);
            Console.WriteLine("Math square root: " + tester.TestSquareRoot());
            Console.WriteLine("Math natural lograithm: " + tester.TestLogarithm());
            Console.WriteLine("Math sinus: " + tester.TestSinus());
            Console.WriteLine(new string('-',20));
        }

        private static void PrintBasicTests<T>(IList<T> collection) where T : struct
        {
            BasicOperationsTester<T> tester = new BasicOperationsTester<T>(collection);
            Console.WriteLine("Addition: " + tester.TestAddition());           
            Console.WriteLine("Subtraction: " + tester.TestSubtraction());
            Console.WriteLine("Multiplication: " + tester.TestMultiplication());           
            Console.WriteLine("Division: " + tester.TestDivision());
            Console.WriteLine("Increments: " + tester.TestIncremention(1000));
            Console.WriteLine(new string('-',20));
        }
    }
}