using System;

class PrintFrom1ToN
{
    static void Main()
    {
        string number = Console.ReadLine();
        uint n = uint.Parse(number);
        for (int i = 1; i <= n; i++)
        {
            Console.Write("{0} ",i);
        }
        Console.WriteLine();
    }
}

