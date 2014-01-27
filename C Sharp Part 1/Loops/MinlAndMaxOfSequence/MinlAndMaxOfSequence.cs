using System;

class MinlAndMaxOfSequence
{
    static void Main()
    {
        string number = Console.ReadLine();
        int n = int.Parse(number);        
        Console.WriteLine();

        //First initialize the min and max value with the first input and then compare the values with every next input.
        int nextNumber = int.Parse(Console.ReadLine());        
        int maxNumber = nextNumber;
        int minNumber = nextNumber;

        for (int i = 2; i <= n; i++)
        {
            nextNumber = int.Parse(Console.ReadLine());
            if (nextNumber > maxNumber)
            {
                maxNumber = nextNumber;
            }
            if (minNumber > nextNumber)
            {
                minNumber = nextNumber;
            }
        }
        Console.WriteLine("Maximal number: {0}",maxNumber);
        Console.WriteLine("Minimal number: {0}", minNumber);
    }
}

