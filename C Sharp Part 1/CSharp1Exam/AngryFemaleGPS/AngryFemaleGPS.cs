using System;

class AngryFemaleGPS
{
    static void Main()
    {
        string input = Console.ReadLine();
        input = Math.Abs(long.Parse(input)).ToString();
        int evenSum = 0;
        int oddSum = 0;
        for (int i = 0; i < input.Length; i++)
        {
            int digit = int.Parse((input[i]).ToString());
            if (digit % 2 != 0)
            {
                oddSum +=digit;
            }
            else
            {
                evenSum += digit;
            }
        }

        if (oddSum > evenSum)
        {
            Console.WriteLine("left {0}",oddSum);
        }
        else if (evenSum > oddSum)
        {
            Console.WriteLine("right {0}", evenSum);
        }
        else
        {
            Console.WriteLine("straight {0}", evenSum);
        }

    }
}

