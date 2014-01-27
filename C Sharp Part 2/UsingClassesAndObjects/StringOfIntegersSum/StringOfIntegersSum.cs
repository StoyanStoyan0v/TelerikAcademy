using System;
using System.Collections.Generic;

class StringOfIntegersSum
{
    static int CalculateSum(string numbers)
    {
        //Split the string into an array of its substrings and parse the array elements into numbers then add them to a sum.
        int sum = 0;
        char[] separators = { ' ' };
        string[] numbersAsStrings = numbers.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < numbersAsStrings.Length; i++)
        {
            sum += int.Parse(numbersAsStrings[i]);
        }

        return sum;
    }

    static void Main()
    {
        Console.Write("Enter numbers: ");
        string numbersAsString = Console.ReadLine();
        int sum = CalculateSum(numbersAsString);
        Console.WriteLine("Sum: "+sum);
    }
}

