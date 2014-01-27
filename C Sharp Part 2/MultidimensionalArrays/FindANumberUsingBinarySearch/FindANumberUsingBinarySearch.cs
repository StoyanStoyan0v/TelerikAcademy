using System;

class FindANumberUsingBinarySearch
{
    static void ReadArray(int[] arr)
    {
        string [] separator = {" "};
        string array = Console.ReadLine();
        string[] numbersAsString = array.Split(separator, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < numbersAsString.Length; i++)
        {
            arr[i] = int.Parse(numbersAsString[i]);
        }
    }

    static void GreatestNumberBeforeK(int[] arr, int k)
    {
        int num = k;
        int index = -1;
        bool isNumFound = false;

        //Check all the numbers in the sorted sequence starting with k and ending with the first element(as lowest).
        while (num >= arr[0])
        {
            index = Array.BinarySearch(arr, num); //Check for the number using binary search.

            if (index >= 0 && index < arr.Length)
            {
                isNumFound = true;//If the index of the element we are looking for is inside the array then we found
                                  // the highest number before k.
                Console.WriteLine("The greatest number found, which is lesser or equial to {0} is {1}.", k, num);
                break;
            }
            num--;
        }

        if (isNumFound == false)
        {
            Console.WriteLine("Your number is not found.");
        }
    }

    static void Main()
    {
        Console.Write("Count of numbers: ");
        int length = int.Parse(Console.ReadLine());
        Console.Write("Number to be searched: ");
        int k = int.Parse(Console.ReadLine());
        int[] numbers = new int[length];
        ReadArray(numbers);
        Array.Sort(numbers);
        GreatestNumberBeforeK(numbers, k);       
    }
}

