using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorfulBalls
{
    class Program
    {
        private static readonly HashSet<string> permutations = new HashSet<string>();

        private static int count = 0;
        
        static void Main(string[] args)
        {
            var balls = Console.ReadLine();
            var sb = new StringBuilder(balls);           
            GetPermutationsCount(sb, 0);
            Console.WriteLine(count);
        }

        private static void GetPermutationsCount(StringBuilder permutation, int index)
        {
            if (index == permutation.Length - 1)
            {
                var perm = permutation.ToString();
                if (!permutations.Contains(perm))
                {
                    permutations.Add(perm);
                    count++;
                }
            }
            else
            {
                GetPermutationsCount(permutation, index + 1);
                for (int i = index + 1; i < permutation.Length; i++)
                {
                    if (permutation[i] != permutation[index])
                    {
                        Swap(permutation, i, index);
                        GetPermutationsCount(permutation, index + 1);
                        Swap(permutation, i, index);
                    }
                }
            }
        }
        
        private static void Swap(StringBuilder arr, int firstIndex, int secondIndex)
        {
            var firstValue = arr[firstIndex];

            arr[firstIndex] = arr[secondIndex];

            arr[secondIndex] = firstValue;
        }
    }
}