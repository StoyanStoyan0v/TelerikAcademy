using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class AcademyTasks
{
    static void Main()
    {
        string pleasantnessAsString = Console.ReadLine();
        int variety = int.Parse(Console.ReadLine());
        string[] pleasantnessParts = pleasantnessAsString.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        int[] pleasantness = pleasantnessParts.Select(x => int.Parse(x)).ToArray();
        int result = MinNumber(pleasantness, variety);
        Console.WriteLine(result);

    }
    static int MinNumber(int[] pleasuntness, int variety)
    {
        int minValue = 2;
        bool isFound = false;
        for (int i = 0; i < pleasuntness.Length; i++)
        {
            for (int j = i+1; j < pleasuntness.Length; j++)
            {
                if(Math.Abs(pleasuntness[i]-pleasuntness[j])>=variety)
                {
                    isFound = true;

                    for (int k = 1; k < j-i; k++)
                    {
                        if (k % 2 == 0)
                        {
                            minValue++;
                        }
                    }

                    for (int k = 0; k < i; k++)
                    {
                        if(k%2==0)
                        {
                            minValue++;
                        }
                    }
                }
                if(isFound)
                {
                    break;
                }
            }
            if(isFound)
            {
                break;
            }
        }
        if (isFound)
        {
            return minValue;
        }
        else
        {
            return pleasuntness.Length;
        }

    }

}

