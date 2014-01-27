using System;
using System.Collections.Generic;

class SubsetOfS
{

    //The algorithm is almost the same. Here we sort the array with the Quick Sort algorithm first and add a counter for the length in 
    // the method which checks for a subset.
    static void SwapElements(ref int firstElement, ref int secondElement)
    {
        int tempElement = firstElement;
        firstElement = secondElement;
        secondElement = tempElement;
    }

    static int PivotIndex(int[] arr, int left, int right, int pivotIndex)
    {
        double pivotValue = arr[pivotIndex];

        SwapElements(ref arr[pivotIndex], ref arr[right]);

        int storeIndex = left;
        for (int i = left; i < right; i++)
        {
            if (arr[i] <= pivotValue)
            {
                SwapElements(ref arr[i], ref arr[storeIndex]);
                storeIndex++;
            }
        }
        SwapElements(ref arr[storeIndex], ref arr[right]);
        return storeIndex;
    }

    static void QuickSortMethod(int[] arr, int left, int right)
    {

        if (left < right)
        {
            int pivotIndex = left;
            int pivotNewIndex = PivotIndex(arr, left, right, pivotIndex);
            QuickSortMethod(arr, left, pivotNewIndex - 1);
            QuickSortMethod(arr, pivotNewIndex + 1, right);
        }
    }

    //Here the logic is the same as in the previous excersise with an additional parametar checking the length of the subset.
    static bool SubSetExtractor(int s, List<int> subset, int[] nums, int length)
    {
        
        int startPos = nums.Length - 1;
        bool isSubSetFound = false;

        while (startPos >= 0)
        {
            int currentSum = 0;
            int subsetLength = 0;
            subset.Clear();

            for (int i = startPos; i >= 0; i--)
            {
                currentSum += nums[i];
                
                if (currentSum < s)
                {
                    subsetLength++;
                    subset.Add(nums[i]);
                }
                else if (currentSum == s)
                {
                    subsetLength++;
                    if (subsetLength == length)
                    {
                        subset.Add(nums[i]);
                        isSubSetFound = true;
                        break;
                    }
                    else
                    {
                        currentSum -= nums[i];
                        subsetLength--;
                    }
                }
                else
                {
                    currentSum -= nums[i];
                }
            }
            if (isSubSetFound == true)
            {
                break;
            }
            else
            {              
                startPos--;
            }
        }
        return isSubSetFound;
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        int s = int.Parse(Console.ReadLine());

        List<int> subset = new List<int>();

        int[] nums = new int[n];
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }
        
        QuickSortMethod(nums, 0, nums.Length - 1);
        bool isSubSetFound = SubSetExtractor(s, subset, nums,k);
        subset.Sort();

        if (isSubSetFound == true)
        {
            string subsetString = string.Join("+", subset);
            Console.WriteLine("There is a subset of {0} elements which sum is {1}: {2}", k, s,subsetString);
           
        }
        else
        {
            Console.WriteLine("No, there is not a subset of {0} elements which sum is {1}.",k,s);
        }
    }
}