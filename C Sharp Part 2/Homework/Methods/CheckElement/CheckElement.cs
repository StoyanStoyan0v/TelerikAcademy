using System;

class CheckElement
{
    static void ReadArray(int[] arr)
    {
        string arrayAsString = Console.ReadLine();
        string[] numbersAsStrings = arrayAsString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < numbersAsStrings.Length; i++)
        {
            arr[i] = int.Parse(numbersAsStrings[i]);
        }
    }

    static bool CheckNumber(int[] arr, int position)
    {
        //Check the surround elements if there are two of them.
        bool isGreater = false;
        if (position !=0 && position !=arr.Length-1 && arr[position] > arr[position - 1] && arr[position] > arr[position + 1])
        {
            isGreater = true;
        }
        else
        {
            isGreater = false;
        }        
        return isGreater;
    }

    static void PrintResult(int[] numbers, int position, bool isGreater)
    {
        //Print result accordin to the results.
        if (position < 0 || position >= numbers.Length)
        {
            Console.WriteLine("This index is outside the boundaries of the array.");
        }
        else if (position == 0 || position == numbers.Length - 1)
        {
            if (position == 0)
            {
                Console.WriteLine("The number at position {0} is {1} and have only one neighbour: {2}", position, numbers[position],
                   numbers[position + 1]);
            }
            else
            {
                Console.WriteLine("The number at position {0} is {1} and have only one neighbour: {2}", position, numbers[position],
                   numbers[position - 1]);
            }
        }
        else
        {


            if (isGreater)
            {
                Console.WriteLine("The number at position {0} is {1} and it is greater than its neighbours: {2} and {3}", position,
                    numbers[position], numbers[position - 1], numbers[position + 1]);
            }
            else
            {
                Console.WriteLine("The number at position {0} is {1} and it is smaller than its neighbours: {2} and {3}", position,
                    numbers[position], numbers[position - 1], numbers[position + 1]);
            }
        }
    }

    static void Main(string[] args)
    {
        Console.Write("Enter the count of numbers: ");
        int numbersCount = int.Parse(Console.ReadLine());

        Console.Write("Enter the numbers: ");
        int[] numbers = new int[numbersCount];
        ReadArray(numbers);

        Console.Write("Enter the position where the number will be checked: ");
        int position = int.Parse(Console.ReadLine());       
        Console.WriteLine();

        bool isGreater = CheckNumber(numbers, position);

        PrintResult(numbers, position, isGreater);       
    }   
}

