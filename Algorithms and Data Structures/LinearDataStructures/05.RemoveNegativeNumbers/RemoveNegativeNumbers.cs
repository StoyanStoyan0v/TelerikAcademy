using System;
using System.Collections.Generic;
using System.Linq;

class RemoveNegativeNumbers
{
    private static readonly List<int> numbers = new List<int>();

    static void Main(string[] args)
    {
        GetNumbers();
        Console.WriteLine(string.Join(" ", numbers.Where(num => num >= 0)));
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