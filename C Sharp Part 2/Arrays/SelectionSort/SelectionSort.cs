using System;

class SelectionSort
{
    //The selection sort method
    static void SelectionSortMethod(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            int tempNumber = 0;
            for (int j = i; j < nums.Length; j++)
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

    static void Main(string[] args)
    {
        Console.Write("N= ");
        int n = int.Parse(Console.ReadLine());
        int[] nums = new int[n];

        for (int i = 0; i < n; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }
      
        Console.Write("Initial array: ");
        for (int i = 0; i < n; i++)
        {
            Console.Write("{0} ", nums[i]);
        }

        Console.WriteLine();

        SelectionSortMethod(nums);

        Console.Write("Sorted array: ");
        for (int i = 0; i < n; i++)
        {
            Console.Write("{0} ", nums[i]);
        }
        Console.WriteLine();
    }

   
}

