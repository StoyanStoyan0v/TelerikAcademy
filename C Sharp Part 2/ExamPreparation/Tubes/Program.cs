using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes
{
    class Program
    {
        static int GetResult(int[]arr,int m)
        {
            
            int segments = 0;
            int min = 1;
            int max = arr[arr.Length - 1];
            int maxResult = -1;
            int result = min+max/2;

            while (min<=max)
            {
                
                segments=0;
                for (int i = 0; i < arr.Length; i++)
                {
                    segments += arr[i] / result;
                }

                if (segments >= m)
                {
                    min = result+1;
                    maxResult = result;
                }
                else 
                {
                    max = result-1;
                }
                result = (min + max) / 2;
            }


            return result;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[] lengths = new int[n];
            for (int i = 0; i < n; i++)
            {
                lengths[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(lengths);
            int result = GetResult(lengths, m);
            Console.WriteLine(result);
        }
    }
}
