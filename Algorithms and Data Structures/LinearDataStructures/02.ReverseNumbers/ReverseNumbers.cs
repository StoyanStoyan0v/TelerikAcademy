using System;
using System.Collections.Generic;

class ReverseNumbers
{
    private static readonly Stack<int> numbers = new Stack<int>();

    static void Main(string[] args)
    {
        GetNumbers();
        Console.WriteLine(string.Join(" ", numbers));
    }

    private static void GetNumbers()
    {
        Console.WriteLine("Enter number:");
        string num = Console.ReadLine();
        while (!string.IsNullOrEmpty(num))
        {
            numbers.Push(int.Parse(num));
            Console.WriteLine("Enter number: ");
            num = Console.ReadLine();
        }
    }
}
