using System;

class FirTree
{
    static void Main()
    {
        string input = Console.ReadLine();
        byte n=0;
        while (n < 4 || n > 100)
        {
            n = byte.Parse(input);
        }
        int dotPrinter = n - 2;
        int starPrinter = 1;
        for (int i = 1; i <= n-1; i++)
        {
            Console.Write(new string('.', dotPrinter));
            Console.Write(new string('*', starPrinter));
            Console.Write(new string('.', dotPrinter));
            Console.WriteLine();
            dotPrinter--;
            starPrinter += 2;
            
        }
        dotPrinter = n-2 ;
        starPrinter = 1;
        Console.Write(new string('.', dotPrinter));
        Console.Write(new string('*', starPrinter));
        Console.Write(new string('.', dotPrinter));

    }
}

