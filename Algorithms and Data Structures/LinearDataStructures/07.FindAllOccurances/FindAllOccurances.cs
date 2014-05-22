using System;
using System.Collections.Generic;
using System.Linq;

class FindAllOccurances
{
    private static readonly List<int> numbers = new List<int>();

    static void Main()
    {
        GetNumbers();
        var removedOddCount = RemoveOddCountNumbers();
        Console.WriteLine(string.Join(Environment.NewLine, removedOddCount.Select(x => string.Format("{0} -> {1} times.", x.Key, x.Value))));
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

    private static Dictionary<int, int> RemoveOddCountNumbers()
    {
        Dictionary<int, int> result = new Dictionary<int, int>();

        foreach (var num in numbers)
        {
            if (result.ContainsKey(num))
            {
                result[num]++;
            }
            else
            {
                result.Add(num, 1);
            }
        }
        return result;
    }
}