using System;

class PrintSequence
{
    static void Main()
    {
        Console.Write(2 + " ");

        double nextNumber;
        for (int iterator = 3; iterator < 12; iterator++)
        {
            nextNumber = iterator * Math.Pow((-1), iterator);
            Console.Write(nextNumber + " ");
        }

        Console.WriteLine();

    }
}
