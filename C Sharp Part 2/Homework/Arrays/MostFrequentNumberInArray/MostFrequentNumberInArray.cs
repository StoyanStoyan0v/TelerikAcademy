using System;

class MostFrequentNumberInArray
{
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

    static void Main()
    {
        Console.Write("N= ");
        int n = int.Parse(Console.ReadLine());
        int[] nums = new int[n];

        for (int i = 0; i < n; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }

        SelectionSortMethod(nums); //Sort the array...

        int tempCounter = 1, maxCounter = 1, element=0;

        for (int i = 1; i < n; i++)
        {
            if (nums[i] == nums[i - 1])
            {
                tempCounter++;
                //If the element is same as the previous one, increase the counter and compare to the maximal one.
                if (tempCounter > maxCounter)
                {
                    //If we have maximal count of equial elemts, we keep the cound and the element.
                    maxCounter = tempCounter;
                    element = nums[i];
                }
            }
            else
            {
                //If the element is different than the previous one, the counter starts from 1.
                tempCounter = 1;
            }
        }

        Console.WriteLine("{0} ({1} times)",element,maxCounter);

    }
}
