using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialValue
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int>[] path = new List<int>[n];
            List<bool>[] isVisited = new List<bool>[n];
            for (int i = 0; i < n; i++)
            {
                path[i] = new List<int>();
                isVisited[i] = new List<bool>();
                string[] nums = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                
                for (int j = 0; j < nums.Length; j++)
                {
                    path[i].Add(int.Parse(nums[j]));
                    isVisited[i].Add(false);
                }
            }

            

            int maxSpecialValue = 0;
            for (int asd = 0; asd < path[0].Count; asd++)
            {
                int counter = 0;
                int specialValue = 0;
                int startIndex = asd;
                for (int i = 0; i < path.Length; i++)
                {
                    if (isVisited[i][startIndex] || path[i][startIndex] < 0)
                    {
                        if (isVisited[i][startIndex])
                        {

                            specialValue = counter;
                            ReinitializeVisitedValues(isVisited, i);
                            break;
                        }
                        counter++;
                        specialValue = counter + Math.Abs(path[i][startIndex]);
                        ReinitializeVisitedValues(isVisited, i);
                        break;
                    }
                    counter++;
                    isVisited[i][startIndex] = true;
                    startIndex = path[i][startIndex];
                    if (i == path.Length - 1)
                    {
                        i = -1;
                    }
                }
                if (maxSpecialValue < specialValue)
                {
                    maxSpecialValue = specialValue;
                }
                
            }

            Console.WriteLine(maxSpecialValue);
        }

        static void ReinitializeVisitedValues(List<bool>[] isVisited, int i)
        {
            for (int a = 0; a <= i; a++)
            {
                for (int b = 0; b < isVisited[a].Count; b++)
                {
                    isVisited[a][b] = false;
                }
            }
        }
    }
}
