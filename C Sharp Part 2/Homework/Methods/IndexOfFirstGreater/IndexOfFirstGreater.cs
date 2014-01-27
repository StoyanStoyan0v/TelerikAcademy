using System;

//Enter the numbers on a single line with spaces... e.g."5 3 4 2 1 8"..

class IndexOfFirstGreater
{
    static string []numbersAsStrings;
    static int[] numbers;

    static void ReadArray()
    {
        string arrayAsString = Console.ReadLine();
        numbersAsStrings = arrayAsString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < numbersAsStrings.Length; i++)
        {
            numbers[i] = int.Parse(numbersAsStrings[i]);
        }
    }

    static bool CheckNumber(int position)
    {
        bool isGreater = false;
        if (numbers[position] > numbers[position - 1] && numbers[position] > numbers[position + 1])
        {
            isGreater = true;
        }
        else
        {
            isGreater = false;
        }
        return isGreater;
    }

    static int FirstIndex()
    {
        //Checks every index from the second(1) to the one before last(array's length -1).
        //If larget element not found, returns index of -1.

        int index = -1;
        for (int col = 1; col < numbers.Length - 1; col++)
        {
            if (CheckNumber(col))//Invoke the method to recieve boolean result.
            {
                index = col;
            }
        }
        return index;
    }

    static void PrintResult( int index)
    {
        if (index == -1)
        {
            Console.WriteLine("There is no element greater than its neighbours.");
        }
        else
        {
            for (int i = 0; i < numbersAsStrings.Length; i++)
            {
                if (int.Parse(numbersAsStrings[i]) == numbers[index])
                {
                    //Prints the sequence and paints our element. :)
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(numbersAsStrings[i] + " ");
                }
                else
                {
                    Console.ResetColor();
                    Console.Write(numbersAsStrings[i] + " ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Element: "+numbers[index]);
            Console.WriteLine("Position: " + index);
        }
    }

    static void Main()
    {
        Console.Write("Enter the count of numbers: ");
        int numbersCount = int.Parse(Console.ReadLine());

        Console.Write("Enter the numbers: ");
        numbers = new int[numbersCount];
        ReadArray();
        Console.WriteLine();

        int index = FirstIndex();
        PrintResult(index);
    }   
}

