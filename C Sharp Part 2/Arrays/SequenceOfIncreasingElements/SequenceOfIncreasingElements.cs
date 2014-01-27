using System;

class SequenceOfIncreasingElements
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());
        int[] nums = new int[length];


        for (int i = 0; i < length; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }

        int lastElement = 0; // Here we keep the index of last element of the longest sequence
        int sequenceLength = 1; // The length of the current longest sequence
        int tempLength = 1; // The length of the current sequence.

        for (int i = 1; i < length; i++)
        {

            if (nums[i] > nums[i - 1])
            {               
                tempLength++; // If this element is greater than the previous one, we increase the length of the current sequence.
                if (tempLength > sequenceLength)
                {
                    sequenceLength = tempLength; //If the current sequence is longer than the longest one we have, our longest one takes                                                     the length of the current one.
                    lastElement = i; // If this element is greater than the previous one, we keep its index as the lastone of the                                                 sequence.
                }
            }
            else
            {
                tempLength = 1; // If the element is lesser of equial ot the previous one, then our current sequence length becomes 1                                        because we have one new lesser/equal number in this current sequence.
            }
        }

        if (sequenceLength == 1) //If we have longest sequence of elements equal to 1, then the elements are in descending order.
        {
            Console.Write("There is no longest sequence. The elements are in descending order.");
        }
        else
        {
            Console.Write("The longest sequence is: ");
            for (int i = (lastElement - sequenceLength) +1; i <=lastElement; i++)
            {
                Console.Write("{0} ", nums[i]);
            }
        }
        Console.WriteLine();

    }
}
