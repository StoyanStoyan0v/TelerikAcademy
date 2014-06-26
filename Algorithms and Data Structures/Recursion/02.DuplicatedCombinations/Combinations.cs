namespace DuplicatedCombinations
{
    using System;
    
    class Combinations
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] combination = new int[k];

            GetCombinations(combination, n, 0, 1);
        }
 
        private static void GetCombinations(int[] combination, int n, int index, int number)
        {
            if (index == combination.Length)
            {
                Console.WriteLine(string.Join(" ", combination));
            }
            else
            {
                for (int i = number; i <= n; i++)
                {
                    combination[index] = i;
                    GetCombinations(combination, n, index + 1, number++);
                }
            }
        }
    }
}