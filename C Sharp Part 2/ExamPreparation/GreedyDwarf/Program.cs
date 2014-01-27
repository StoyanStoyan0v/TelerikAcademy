using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyDwarf
{
    class Program
    {


        static void InitializeNumArray(int[]arr, string[]array)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(array[i]);
            }
        }
        static void Main(string[] args)
        {
            string valley = Console.ReadLine();
            string [] nums = valley.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = new int[nums.Length];
            
            InitializeNumArray(numbers, nums);

            int m = int.Parse(Console.ReadLine());
            int maxCount = int.MinValue;

            for (int i = 0; i < m; i++)
            {
                int curCount = 0;
                bool[] isVisited = new bool[nums.Length];
                string[]patter=Console.ReadLine().Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries);
                int[] patern = new int[patter.Length];
                InitializeNumArray(patern, patter);
                int pos = 0;
                for (int j = 0; j < patern.Length; j++)
                {
                    
                    if(pos>=0 && pos<numbers.Length && !isVisited[pos])
                    {
                        curCount += numbers[pos];
                        isVisited[pos] = true;
                        pos += patern[j];
                        
                    }
                    else
                    {
                        break;
                    }
                    if(j==patern.Length-1)
                    {
                        j = -1;
                    }
                }
                if(curCount>maxCount)
                {
                    maxCount = curCount;
                }
            }
            Console.WriteLine(maxCount);
        }
    }
}
