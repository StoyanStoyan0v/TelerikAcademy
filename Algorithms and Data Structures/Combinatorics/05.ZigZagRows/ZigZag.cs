using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ZigZagRows
{
    class ZigZag
    {
        private static int k;

        private static int n;

        private static int counter = 0;

        private static bool[] used;

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var numbers = input.Split(' ');
            k = int.Parse(numbers[1]);
            n = int.Parse(numbers[0]);
            used = new bool[n];
            Variations(new int[k], 0, n);
            Console.WriteLine(counter);
        }

        private static void Variations(int[] arr, int index, int n)
        {
            if (index == k)
            {
                if (IsZigZagSequence(arr))
                {
                    counter++;
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        arr[index] = i;
                        Variations(arr, index + 1, n);
                        used[i] = false;
                    }
                }
            }
        }

        private static bool IsZigZagSequence(int[] seq)
        {
            for (int i = 1; i < seq.Length - 1; i++)
            {
                if (i % 2 == 0)
                {
                    if (seq[i - 1] >= seq[i] || seq[i] <= seq[i + 1])
                    {
                        return false;
                    }
                }
                else
                {
                    if (seq[i - 1] <= seq[i] || seq[i] >= seq[i + 1])
                    {
                        return false;
                    }
                }
            }

            if (seq.Length == 2)
            {
                if (seq[0] < seq[1])
                {
                    return false;
                }
               
            }
             return true;
        }
    }
}
