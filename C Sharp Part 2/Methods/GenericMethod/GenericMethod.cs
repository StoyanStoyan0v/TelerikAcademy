using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class GenericMethod
{
    static void CalculateMin<T>(params T[] integers) where T : System.IComparable<T>
    {
        //The minimal value gets the type of the array of the parameters.
        T min = integers[0];      
        foreach (T integer in integers)
        {
            if (integer.CompareTo(min)<0)
            {
                min = integer;
            }
        }
        Console.WriteLine("Min value of the sequence is: " + min);
    }

    static void CalculateMax<T>(params T[] integers) where T: System.IComparable<T>
    {
        //The maximal value gets the type of the array of the parameters.
        T max = integers[0];
        foreach (T integer in integers)
        {
            if (integer.CompareTo(max) > 0)
            {
                max = integer;
            }
        }
        Console.WriteLine("Max value of the sequence is: " + max);
    }

    static void CalculateAverage<T>(params T[] integers)
    {
        //Use the dynamic type to store the sum and the average variables.
        //Dynamic type takes the suitable type or the type of the parameters which are given to the generic method.
        dynamic sum = 0;
        dynamic average = 0;
        foreach (T integer in integers)
        {
            sum += integer;
        }
        average = sum / integers.Length;
        Console.WriteLine("Average of the sequence is: " + average);
    }

    static void CalculateSum<T>(params T[] integers)
    {
        dynamic sum = 0;
        foreach (T integer in integers)
        {
            sum += integer;
        }
        Console.WriteLine("Sum of the sequence is: " + sum);
    }

    static void CalculateProduct<T>(params T[] integers)
    {
        dynamic product = 1;
        foreach (T integer in integers)
        {
            product *= integer;
        }
        Console.WriteLine("Product of the sequence is: " + product);
    }

    static void Main()
    {
        CalculateMin<decimal>(3, 5, 4, 7, 2.99999999999934592392m, 8, 10);
        CalculateMax<double>(3, 5, 4, 7, 1, 8, 10.2);
        CalculateAverage<float>(3.3f, 5, 4, 7.2f, 1, 8, 10);
        CalculateSum<byte>(3, 5, 4, 7, 1, 8, 10);
        CalculateProduct<decimal>(3.8732m, 5, 4.12341m, 7.4123m, 1.45m, 8, 10);
    }
}

