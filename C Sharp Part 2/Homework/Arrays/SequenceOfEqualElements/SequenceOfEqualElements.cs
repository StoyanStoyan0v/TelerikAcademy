using System;

class SequenceOfEqualElements
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());
        int [] nums = new int[length];
       

        for (int i = 0; i < length; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }

        int lastElement = 0; // Here we keep the index of last element of the longest sequence
        int sequenceLength = 1; // The length of the current longest sequence
        int tempLength = 1; // The length of the current sequence.

        for (int i = 1; i < length; i++)
        {
            
            if (nums[i] == nums[i - 1])
            {               
                tempLength++; // If this element is equial to the previous one, we increase the length of the current sequence.
                if (tempLength > sequenceLength)
                {
                    sequenceLength = tempLength; //If the current sequence is longer than the longest one we have, our longest one takes                                                     the length of the current one.
                    lastElement = i; // If this element is equial to the previous one, we keep its index as the last one of the sequence.
                }              
            }
            else
            {
                tempLength = 1; // If the element is different than the previous one, then our current sequence length becomes 1 because                                     we have one new different number in this current sequence.
            }
        }

        if (sequenceLength == 1) //If we have longest sequence of elements equal to 1, then all of our elements are different.
        {
            Console.Write("There is no longest sequence. Every element is different from the others.");
        }
        else
        {
            Console.Write("The longest sequence is: ");
            for (int i = lastElement; i > lastElement - sequenceLength; i--)
            {
                Console.Write("{0} ", nums[i]);
            }
        }
        Console.WriteLine();
        
    }
}

