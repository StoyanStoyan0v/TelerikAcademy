using System;

class Program
{
    static void Main()
    {
        string words = Console.ReadLine();
        string[] arrayOfWords = words.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Array.Sort(arrayOfWords);
        Console.WriteLine("Sorted alphabetically: ");
        foreach (string word in arrayOfWords)
        {
            Console.WriteLine(word);
        }
    }
}

