using System;

class KElementsWithMaxSum
{
    //The selection sort algorithm implemented as a method which we invoke in the main...
    static void SelectionSortMethod(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            int tempNumber = 0;
            for (int j = i; j < nums.Length; j++)
            {
                if (nums[j] > nums[i])
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
        Console.Write("K= ");
        int k = int.Parse(Console.ReadLine());
        int[] nums = new int[n];

        for (int i = 0; i < n; i++)
        {
            nums[i] = 1;
        }

        Console.Write("Array: ");
        Console.WriteLine(string.Join(" ",nums));

        SelectionSortMethod(nums); //Here is the sorting part...in a descending order


        //Now we iterate k times starting from the biggest element and when the k-th loop is over we have our sequence...
        int sum = 0;
        for (int i = 0; i < k; i++)
        {
            sum += nums[i];
            if (i != k - 1)
            {
                Console.Write("{0}+",nums[i]);
            }
            else
            {
                Console.Write("{0}=",nums[i]);
            }
        }

        Console.Write(sum);
        Console.WriteLine();
    }
}

