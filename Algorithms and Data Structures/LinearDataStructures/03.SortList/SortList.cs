using System;
using System.Collections.Generic;
using System.Linq;

class SortList
{
    private static readonly List<int> numbers = new List<int>();

    static void Main(string[] args)
    {
        GetNumbers();
        Console.WriteLine(string.Join(" ", numbers.OrderBy(num=>num)));
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
