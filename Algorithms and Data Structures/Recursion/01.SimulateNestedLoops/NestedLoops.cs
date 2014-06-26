using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateNestedLoops
{
    class NestedLoops
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());            
            SimulateLoops(new int[n], 0, n);
        }

        private static void SimulateLoops(int[]arr, int index, int n)
        {
            if (n == index)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    arr[index] = i;
                    SimulateLoops(arr, index + 1, n);
                }
            }
        }
    }
}