namespace Permutations
{
    using System;

    class Permutations
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] permutation = new int[n];

            for (int i = 0; i < permutation.Length; i++)
            {
                permutation[i] = i + 1;
            }
            GetPermutatuions(permutation, 0);
        }

        private static void GetPermutatuions(int[] permutation, int index)
        {
            if (index == permutation.Length - 1)
            {
                Console.WriteLine(string.Join(" ", permutation));
            }
            else
            {
                for (int i = index; i < permutation.Length; i++)
                {
                    Swap(permutation, i, index);                   
                    GetPermutatuions(permutation, index + 1);
                    Swap(permutation, i, index);
                }
            }
        }

        private static void Swap(int[] arr, int firstIndex, int secondIndex)
        {
            var firstValue = arr[firstIndex];

            arr[firstIndex] = arr[secondIndex];

            arr[secondIndex] = firstValue;
        }
    }
}