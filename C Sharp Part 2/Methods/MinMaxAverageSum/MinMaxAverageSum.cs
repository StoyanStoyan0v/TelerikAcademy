using System;

class MinMaxAverageSum
{
    static void CalculateMin(params int[] integers)
    {
        int min = int.MaxValue;
        foreach (int integer in integers)
        {
            if(integer<min)
            {
                min = integer;
            }
        }
        Console.WriteLine("Min value of the sequence is: "+min);
    }

    static void CalculateMax(params int[] integers)
    {
        int max = int.MinValue;
        foreach (int integer in integers)
        {
            if (integer > max)
            {
                max = integer;
            }
        }
        Console.WriteLine("Max value of the sequence is: " + max);
    }

    static void CalculateAverage(params int[] integers)
    {
        int sum = 0;
        int average = 0;
        foreach (int integer in integers)
        {
            sum += integer;
        }
        average = sum / integers.Length;
        Console.WriteLine("Average of the sequence is: "+average);
    }

    static void CalculateSum(params int[] integers)
    {
        int sum = 0;
        foreach (int integer in integers)
        {
            sum += integer;
        }
        Console.WriteLine("Sum of the sequence is: "+sum);
    }

    static void CalculateProduct(params int[] integers)
    {
        int product = 1;
        foreach (int integer in integers)
        {
            product *= integer;
        }
        Console.WriteLine("Product of the sequence is: " + product);
    }

    static void Main()
    {
        CalculateMin(3, 5, 4, 7, 1, 8, 10);
        CalculateMax(3, 5, 4, 7, 1, 8, 10);
        CalculateAverage(3, 5, 4, 7, 1, 8, 10);
        CalculateSum(3, 5, 4, 7, 1, 8, 10);
        CalculateProduct(3, 5, 4, 7, 1, 8, 10);
    }
}

