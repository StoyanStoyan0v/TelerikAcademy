using System;

class BinarySearch
{  
    //We make a method for implementing the binary search algorithm...
    static int BinarySearchMethod(int element, int[] nums )
    {
        int mid = 0;
        int upper = nums.GetUpperBound(0);
        int lower = nums.GetLowerBound(0);
        while (upper >= lower)
        {
            mid = (lower + upper) / 2;
            if (nums[mid] == element)
            {
                return mid;
            }
            else if (nums[mid] > element)
            {
                upper = mid - 1;
            }
            else
            {
                lower = mid + 1;
            }
        }
        return -1; //If there is no such index, the method reutnrs -1

    }

    //Here is the selection sorting algorithm presented in a method...
    static void SortArray(int n, int[] nums)
    {
        for (int i = 0; i < n; i++)
        {
            int tempNumber = 0;
            for (int j = i; j < n; j++)
            {
                if (nums[j] < nums[i])
                {
                    tempNumber = nums[j];
                    nums[j] = nums[i];
                    nums[i] = tempNumber;
                }
            }
        }
    }

    static void Main()
    {
        Console.Write("N= ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Element: ");
        int element = int.Parse(Console.ReadLine());
        int[] nums = new int[n];

        for (int i = 0; i < n; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }

        SortArray(n, nums);  //Invoke the sorting method and sort the array...
        Console.WriteLine("Sorted array: "+string.Join(" ",nums));
        element = BinarySearchMethod(element, nums); //Invoke the binary search method to check any position for the element we are                                                              looking for...
        if (element != -1)
        {
            Console.WriteLine("Element found in position \"{0}\" in the sorted array.",element);
        }
        else
        {
            Console.WriteLine("Element not found!");
        }
    }
}

