using System;
using System.Collections.Generic;

class MajorantOfAnArray
{
    private static readonly List<int> numbers = new List<int>();
    private static readonly Dictionary<int, int> result = new Dictionary<int, int>();

    static void Main()
    {
        GetNumbers();

        int key = GetMajorantValue();

        string majorantText = result[key] >= numbers.Count / 2 + 1 ? key.ToString() : "Majorant of the array is not avaiable.";

        Console.WriteLine("Majorant of the array: " + majorantText);
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

    private static int GetMajorantValue()
    {
        int maxValue = 0;
        int key = 0;

        foreach (var num in numbers)
        {
            if (result.ContainsKey(num))
            {
                result[num]++;
                if (maxValue < result[num])
                {
                    maxValue = result[num];
                    key = num;
                }
            }
            else
            {
                result.Add(num, 1);
            }
        }
        return key;
    }
}