using System;

class Combinations
{
    //Implement almost the same algorithm as the previous excerise.
    static void PrintCombinations(int[] array, int index, int n, int currentNumber)
    {
        if (index == array.Length)
        {
            Console.WriteLine(string.Join(" ", array)); ;
        }
        else
        {
            for (int i = currentNumber; i <= n; i++)
            {
                array[index] = i;

                //Go to the next elements of the variation starting with i, giving the next index to this method recursively.
                //The difference from the previous excerceise is that the combination do not contain repetetive elements,so besides the
                // next index the next element (i+1) is passed to the method recursively.
                PrintCombinations(array, index + 1, n, i+1);
            }
        }
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        int[] combinations = new int[k];
        PrintCombinations(combinations, 0, n,1);
    }
}

