using System;

class SequenceOfMaximalSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int [] nums = new int[n];

        for (int i = 0; i < n; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }

        int maxSum = nums[0], currentSum = nums[0], begin = 0, beginTemp = 0, end = 0;

        
        for (int i = 1; i < n; i++)
        {
            if (currentSum < 0)
            {
                currentSum = nums[i]; //If current sum (til the previous elemet is added) is negative, it takes the value of the current                                         element.
                beginTemp = i; //Current sequence beginning index takes the value of the current element index.
            }
            else
            {
                currentSum += nums[i]; // If the sum is positive, continue to add elements.
            }

            if (currentSum > maxSum)
            {
                //If we have maximum sum reached, we keep the sum and both(beggining and ending) indexes of the sequence.
                maxSum = currentSum;
                begin = beginTemp;
                end = i;
            }            
        }

        for (int i = begin; i <= end; i++)
        {
            Console.Write(nums[i]+" ");
        }

        Console.WriteLine("="+maxSum);
    }
}

