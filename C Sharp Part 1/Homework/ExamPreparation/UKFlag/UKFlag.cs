using System;

class UKFlag
{
    static void Main()
    {
        byte n = 0;
        while (n % 2 == 0 || n < 5 || n > 79)
        {
            string input = Console.ReadLine();
            n = byte.Parse(input);
        }
        int outterPointPrinter = 0;
        int innerPointPrinter = (n - 3) / 2;
        for (int i = 0; i < (n-1)/2; i++)
        {
            Console.Write(new string('.', outterPointPrinter));
            Console.Write('\\');
            Console.Write(new string('.', innerPointPrinter));
            Console.Write('|');
            Console.Write(new string('.', innerPointPrinter));
            Console.Write('/');
            Console.Write(new string('.', outterPointPrinter));
            Console.WriteLine();
            outterPointPrinter++;
            innerPointPrinter--;
        }

        Console.WriteLine(new string('-', (n - 1) / 2) + '*' + new string('-', (n - 1) / 2));

        outterPointPrinter--;
        innerPointPrinter++;
        for (int i = 0; i < (n - 1) / 2; i++)
        {
            Console.Write(new string('.', outterPointPrinter));
            Console.Write('/');
            Console.Write(new string('.', innerPointPrinter));
            Console.Write('|');
            Console.Write(new string('.', innerPointPrinter));
            Console.Write('\\');
            Console.Write(new string('.', outterPointPrinter));
            Console.WriteLine();
            outterPointPrinter--;
            innerPointPrinter++;
        }
    }
}

