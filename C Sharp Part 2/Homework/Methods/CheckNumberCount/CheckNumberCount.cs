using System;

class CheckNumberCount
{
    static void ReadArray(int[] arr)
    {
        //The method reads the array as a row with intervals and split it into subarrays which are applied to the array of integers.
        string arrayAsString = Console.ReadLine();
        string[] numbersAsStrings = arrayAsString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < numbersAsStrings.Length; i++)
        {
            arr[i] = int.Parse(numbersAsStrings[i]);
        }
    }

    static int ReturnCounter(int[] array, int number)
    {
        int counter = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i]==number)
            {
                counter++;
            }           
        }
        return counter;
    }

    static void Main()
    {
        Console.Write("Enter the count of numbers: ");
        int numbersCount = int.Parse(Console.ReadLine());

        Console.Write("Enter the numbers: ");       
        int [] numbers = new int[numbersCount];
        ReadArray(numbers);

        Console.Write("Enter the number whose count in the sequence is about to be found: " );
        int num = int.Parse(Console.ReadLine());

        int numberCount = ReturnCounter(numbers, num);
        Console.WriteLine("The number {0} is found {1} times in the sequence. ",num,numberCount);
    }
}

