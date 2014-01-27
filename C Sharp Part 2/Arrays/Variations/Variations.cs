using System;
using System.Collections.Generic;

class Variations
{   
    //Generates variations recursively.
    static void Combinations(int[] array, int index, int n)
    {
        if (index == array.Length)
        {
            Console.WriteLine(string.Join(" ",array)); //If the index reaches the variation length, print the sequence.
        }
        else
        {
            for (int i = 1; i <= n; i++)
            {
                //Initialize the current index with the corresponding element.
                array[index] = i; 

                //Go to the next elements of the variation starting with i, giving the next index to this method recursively.
                Combinations(array, index + 1,n);
            }
        }
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        int[] variation = new int[k];//Keep the variation here.
        Combinations(variation, 0,n);
    }
}

