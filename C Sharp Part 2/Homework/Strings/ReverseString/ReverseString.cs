using System;

class ReverseString
{
    static void Main()
    {
        Console.Write("Enter some text: ");
        string input = Console.ReadLine();
        char[] inputAsChars = input.ToCharArray();
        Array.Reverse(inputAsChars);
        input = new string(inputAsChars);
        Console.Write("Reversed text: ");
        Console.WriteLine(input);
    }
}

