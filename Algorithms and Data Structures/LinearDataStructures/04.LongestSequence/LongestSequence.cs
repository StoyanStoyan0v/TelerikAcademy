using System;
using System.Collections.Generic;

class LongestSequence
{
    private static readonly List<int> numbers = new List<int>();

    static void Main()
    {
        GetNumbers();
        var sequence = GetLongestSeq();
        Console.WriteLine(string.Join(" ", sequence));
    }

    private static List<int> GetLongestSeq()
    {
        int currentCount = 1;
        int maxCount = 1;
        int startIndex = 0;
        int currentIndex = 0;

        for (int i = 1; i < numbers.Count; i++)
        {
            if (numbers[i] == numbers[i - 1])
            {
                currentCount++;

                if (maxCount < currentCount)
                {
                    maxCount = currentCount;
                    startIndex = currentIndex;
                }
            }
            else
            {
                currentIndex = i;
                currentCount = 1;
            }
        }
        return numbers.GetRange(startIndex, maxCount);
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
