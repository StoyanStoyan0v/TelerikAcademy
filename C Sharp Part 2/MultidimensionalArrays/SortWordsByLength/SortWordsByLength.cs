using System;

class SortWordsByLength
{   
    static void ReadArray(string[] arr)
    {
        Console.Write("Words: ");
        string[] separator = { " " };
        string array = Console.ReadLine();
        string[] numbersAsString = array.Split(separator, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < numbersAsString.Length; i++)
        {
            arr[i] = numbersAsString[i];
        }
    }

    static void PrintArray(string[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]+" ");
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        Console.Write("Count of words: ");
        int length = int.Parse(Console.ReadLine());
       
        string[] words = new string[length];
        ReadArray(words);
        
        Array.Sort(words,(x,y)  => x.Length.CompareTo(y.Length)); //Sort array elements comparing them by their length(lambda function).

        Console.Write("Sorted words by length: ");
        PrintArray(words);
    }
}

