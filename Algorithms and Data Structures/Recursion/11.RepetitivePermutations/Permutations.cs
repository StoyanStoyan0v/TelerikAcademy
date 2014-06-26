namespace RepetitivePermutations
{
    using System;
    using System.Collections.Generic;

    class Permutations
    {
        static readonly HashSet<string> used = new HashSet<string>();

        static void Main()
        {
            var nums = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] permutation = new int[nums.Length];

            for (int i = 0; i < permutation.Length; i++)
            {
                permutation[i] = int.Parse(nums[i]);
            }

            GetPermutatuions(permutation, 0, permutation.Length);

            Console.WriteLine(string.Join(Environment.NewLine, used));
        }

        private static void GetPermutatuions(int[] permutation, int start, int end)
        {
            if (end == 0)
            {
                used.Add(string.Join(" ", permutation));
            }
            else
            {
                GetPermutatuions(permutation, start, end - 1);
                for (int i = start; i < end - 1; i++)
                {
                    if (permutation[i] != permutation[end - 1])
                    {
                        Swap(permutation, i, end - 1);
                        GetPermutatuions(permutation, start + 1, end - 1);
                        Swap(permutation, i, end - 1);
                    }
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