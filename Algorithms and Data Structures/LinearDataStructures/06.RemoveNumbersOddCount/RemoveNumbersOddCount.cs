using System;
using System.Collections.Generic;
using System.Linq;

class RemoveNumbersOddCount
{
    private static readonly List<int> numbers = new List<int>();

    static void Main()
    {
        GetNumbers();
        var removedOddCount = RemoveOddCountNumbers();
        Console.WriteLine(string.Join(" ", removedOddCount));
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

    private static List<int> RemoveOddCountNumbers()
    {
        List<int> result = new List<int>();
        foreach (var num in numbers)
        {
            if (numbers.Count(x => x == num) % 2 == 0)
            {
                result.Add(num);
            }
        }
        return result;
    }
}
