using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirlsGoneWild
{
    class Program
    {
        static int k = 0;

        static bool[] used;

        static char[] skirts;

        static SortedSet<string> output = new SortedSet<string>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            skirts = Console.ReadLine().ToCharArray();
            used = new bool[skirts.Length];
            k = int.Parse(Console.ReadLine());
            Comb(0, 0, new int[k], n);

            var result = new StringBuilder();
            result.AppendLine(output.Count.ToString());
            foreach (var item in output)
            {
                result.AppendLine(item);
            }
            Console.Write(result.ToString());
        }

        static void Comb(int index, int start, int[]arr, int n)
        {
            if (index >= k)
            {
                GenerateVariationsNoReps(0, new char[k], skirts.Length, arr);               
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    arr[index] = i;
                    Comb(index + 1, i + 1, arr, n);
                }
            }
        }

        static void GenerateVariationsNoReps(int index, char[]arr, int n, int[] combs)
        {
            if (index >= k)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < combs.Length; i++)
                {
                    sb.Append(combs[i]  + arr[i].ToString());
                    if (i != combs.Length - 1)
                    {
                        sb.Append("-");
                    }
                }

                output.Add(sb.ToString());
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        arr[index] = skirts[i];
                        GenerateVariationsNoReps(index + 1, arr, n, combs);
                        used[i] = false;
                    }
                }
            }

        }
    }
}