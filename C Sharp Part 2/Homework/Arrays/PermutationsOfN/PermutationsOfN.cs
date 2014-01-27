using System;
using System.Collections.Generic;

class PermutationsOfN
{
   
    static void Permutations(int[] arr)
    {
        int k = 0; //Initialize k.
        while (k != -1)
        {
            k = -1; //Set k with a default of -1, if the condition below does not match, there is no more permutations and loop will stop.
            // Find the largest index k such that arr[k] < arr[k + 1]. If no such index exists, the permutation is the last permutation.
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (i != arr.Length - 1 && arr[i] < arr[i + 1])
                {
                    k = i;
                    break;
                }
            }

            int l = 0; //Initialize l.
            if (k != -1)  //If k is not found above, it will stay -1 and the loop will stop.
            {
                // Find the largest index l such that arr[k] < arr[l].
                for (int i = arr.Length - 1; i >= k; i--)
                {
                    if (arr[i] > arr[k])
                    {
                        l = i;
                        break;
                    }
                }

                //Swap the value of arr[k] with that of arr[l].
                SwapElements(ref arr[k], ref arr[l]);

                // Reverse the sequence from arr[k + 1] up to and including the final element arr[arr.length-1]. 
                ReverseArray(arr, arr.Length-1 , k+1);

               //Print current permutation.
                Console.WriteLine(string.Join(" ", arr));
            }            
        }
    }

    static void SwapElements(ref int firstElement, ref int secondElement)
    {
        int tempElement = firstElement;
        firstElement = secondElement;
        secondElement = tempElement;
    }

    static void ReverseArray(int[] arr, int end, int start)
    {
        while (end > start)
        {
            SwapElements(ref arr[start], ref arr[end]);
            end--;
            start++;
        }
    }

    static void Main()
    {
        int length = int.Parse(Console.ReadLine());
        int[] arr=new int[length];
        for (int i = 0; i < length; i++)
        {
            arr[i] = i + 1;
        }
        Console.WriteLine(string.Join(" ",arr));
        Permutations(arr);

    }
}

