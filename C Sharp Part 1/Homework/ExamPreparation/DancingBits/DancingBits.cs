using System;

class DancingBits
{
    static void Main()
    {
        int k = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        string allNumbers = null;
        int dancingGroupsCounter = 0;
        int bitCounter = 1;

        

        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
            allNumbers += Convert.ToString(numbers[i], 2);
        }

        if (k == 1)
        {

            if (allNumbers[0] != allNumbers[1])
            {
                dancingGroupsCounter++;
            }

            if (allNumbers[allNumbers.Length - 1] != allNumbers[allNumbers.Length - 2])
            {
                dancingGroupsCounter++;
            }
        }

        for (int i = 1; i < allNumbers.Length; i++)
        {
            if (allNumbers[i] == allNumbers[i - 1])
            {
                bitCounter++;
            }
            else
            {
                bitCounter = 1;
            }

            if (bitCounter == k && i!=allNumbers.Length-1 && allNumbers[i] != allNumbers[i+1])
            {
                dancingGroupsCounter++;
            }
            else if (i == allNumbers.Length - 1 && bitCounter == k)
            {
                dancingGroupsCounter++;
            }
        }
        Console.WriteLine(dancingGroupsCounter);
    }
}

