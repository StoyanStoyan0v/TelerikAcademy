using System;
using System.Collections.Generic;

class RemainingSortedArray
{
    //Check if current sequence is sorted...
    static bool isSequenceSorted(List<int> list)
    {
        bool isSorted = true;

        for (int i = 0; i < list.Count - 1; i++)
        {
            if (list[i] > list[i + 1])
            {
                isSorted = false;
            }
        }

        return isSorted;
    } 

    static List<int> LongestSortedSequence(List<int> arrayOfNumbers) 
    {
        List<int> maxSequence = new List<int>(); 

        int maxi = (int)Math.Pow(2, arrayOfNumbers.Count) - 1; // Keep all possible combinations of numbers for a sequence..
        int maxElements = 0;

        for (int i = 1; i <= maxi; i++) //We loop througout each combination represented by a combination of bits with value 1...
        {
            List<int> currentSequence = new List<int>(); 
            int counter = 0;

            for (int j = 1; j <= arrayOfNumbers.Count; j++)
            {
                if (((i >> (j - 1)) & 1) == 1) //If the bit is one... this mean the number is not used in that combination for a sequence
                {
                    currentSequence.Add(arrayOfNumbers[j - 1]); //Add the element to the current sequence...
                    counter++;
                }
            }

            if (counter > maxElements && isSequenceSorted(currentSequence)) //If this sequence is longer than the current longest and the sequence is sorted, then we keep it as the longest one...
            {
                maxSequence = currentSequence;
                maxElements = counter;
            }

            counter = 0;
        }
        return maxSequence;
    }

    static void Main()
    {
        int listCount = int.Parse(Console.ReadLine());
        List<int> arrayOfNumbers = new List<int>();
        for (int i = 1; i <= listCount; i++)
        {
            int num = int.Parse(Console.ReadLine());
            arrayOfNumbers.Add(num);
        }

        List<int> maxSequence = LongestSortedSequence(arrayOfNumbers); 

        Console.WriteLine("Initial array: " + string.Join(" ",arrayOfNumbers));
        Console.WriteLine("Maximal sequence after removing minimum elements: " + string.Join(" ",maxSequence));
    } 
}

