using System;
using System.Collections.Generic;
using System.Linq;

class CalculateSumAndAverage
{
    private static readonly List<int> numbers = new List<int>();

    static void Main()
    {
        GetNumbers();
        int sum = numbers.Sum();
        Console.WriteLine("Sum : {0}", sum);
        Console.WriteLine("Average : {0}", sum / numbers.Count);
    }

    private static void GetNumbers()
    {
        Console.WriteLine("Enter number:");
        string num = Console.ReadLine();
        while (!string.IsNullOrEmpty(num))
        {
            
            numbers.Add(int.Parse(num));
            Console.WriteLine("Enter number: ");
            num = Console.ReadLine();
        }
    }
}