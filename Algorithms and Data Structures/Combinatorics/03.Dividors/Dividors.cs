namespace _03.Dividors
{
    using System;
    using System.Linq;

    internal class Dividors
    {
        private static int result = int.MaxValue;

        private static int lowestDividors = int.MaxValue;
        
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var digits = new int[n];

            for (int i = 0; i < n; i++)
            {
                digits[i] = int.Parse(Console.ReadLine());
            }
            
            GetNumber(digits, 0);
            
            Console.WriteLine(result);
        }

        private static void GetNumber(int[] permutation, int index)
        {
            if (index == permutation.Length - 1)
            {
                var currentResult = int.Parse(string.Join(string.Empty, permutation));
                var currentDividors = GetDividors(currentResult);
                if (currentDividors < lowestDividors)
                {
                    lowestDividors = currentDividors;
                    result = currentResult;
                }
                else if (currentDividors == lowestDividors)
                {
                    if (currentResult < result)
                    {
                        result = currentResult;
                    }
                }
            }
            else
            {
                for (int i = index; i < permutation.Length; i++)
                {
                    Swap(permutation, i, index);                   
                    GetNumber(permutation, index + 1);
                    Swap(permutation, i, index);
                }
            }
        }

        private static int GetDividors(int number)
        {
            int dividors = 0;
            for (int i = 2; i < Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    dividors++;
                }
            }
            return dividors;
        }

        private static void Swap(int[] arr, int firstIndex, int secondIndex)
        {
            var firstValue = arr[firstIndex];

            arr[firstIndex] = arr[secondIndex];

            arr[secondIndex] = firstValue;
        }
    }
}