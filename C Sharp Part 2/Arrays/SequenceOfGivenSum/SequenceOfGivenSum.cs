using System;

class SequenceOfGivenSum
{
    static void Main()
    {
        Console.Write("N= ");
        int length = int.Parse(Console.ReadLine());
        Console.Write("S= ");
        int sum = int.Parse(Console.ReadLine());
        int[] nums = new int[length];

        for (int i = 0; i < length; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }

        int currentSum = nums[0],startPos = 1, endPos = 1;
        for (int i = 1; i < length; i++)
        {
            currentSum+=nums[i];

            if (currentSum > sum)
            {
                currentSum = nums[i];
                startPos = i;
            }
            else if(currentSum==sum)
            {              
                endPos = i;
                break;
            }
        }

        for (int i = startPos; i <= endPos; i++)
        {
            Console.Write(nums[i] +" ");
        }
        Console.WriteLine("= " + sum);
    }
}

