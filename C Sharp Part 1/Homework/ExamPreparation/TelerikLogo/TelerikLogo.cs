using System;

class TelerikLogo
{
    static void Main()
    {        
        byte x = 0;
        while (x % 2 == 0 || (x < 3 || x > 27))
        {
            string input = Console.ReadLine();
            x = byte.Parse(input);
        }

        int z = (x+1)/2;


        Console.Write(new string('.',z-1));
        Console.Write('*');
        Console.Write(new string('.', z - 1));
        Console.Write(new string('.', x - 2));
        Console.Write(new string('.', z - 1));
        Console.Write('*');
        Console.Write(new string('.', z - 1));
        Console.WriteLine();
        z--;

        int dotPrinter = 0;
        for (int i = z; i > 0; i--)
        {
            Console.Write(new string('.', i - 1));
            Console.Write('*');
            Console.Write(new string('.',2*dotPrinter+1));
            Console.Write('*');
            Console.Write(new string('.', i - 1));
            Console.Write(new string('.', x - 2));
            Console.Write(new string('.', i - 1));
            Console.Write('*');
            Console.Write(new string('.', 2 * dotPrinter + 1));
            Console.Write('*');
            Console.Write(new string('.', i - 1));
            dotPrinter++;
            Console.WriteLine();
        }

        z = (x + 1) / 2;
        dotPrinter = x - 2;
        for (int i = 1; i < z-1; i++)
        {

            Console.Write(new string('.',x-1));
            Console.Write(new string('.', i));
            Console.Write('*');
            Console.Write(new string('.', dotPrinter - 2*i));
            Console.Write('*');
            Console.Write(new string('.', i));
            Console.Write(new string('.', x - 1));
            Console.WriteLine();
        }


        Console.Write(new string('.',x +z-2));
        Console.Write('*');
        Console.Write(new string('.',x +z-2));
        Console.WriteLine();


        dotPrinter = 0;
        for (int i =x-1; i > 0; i--)
        {
            Console.Write(new string('.',z - 1));
            Console.Write(new string('.', i - 1));
            Console.Write('*');
            Console.Write(new string('.', 2 * dotPrinter + 1));
            Console.Write('*');
            Console.Write(new string('.', i - 1));
            Console.Write(new string('.', z - 1));
            dotPrinter++;
            Console.WriteLine();
        }
        dotPrinter--;
        for (int i = 1; i < x-1; i++)
        {
            Console.Write(new string('.', z - 1));
            Console.Write(new string('.', i));
            Console.Write('*');
            Console.Write(new string('.', 2*dotPrinter +1 - 2*i));
            Console.Write('*');
            Console.Write(new string('.', i));
            Console.Write(new string('.', z - 1));
            Console.WriteLine();
        }

        Console.Write(new string('.', x + z - 2));
        Console.Write('*');
        Console.Write(new string('.', x + z - 2));
        Console.WriteLine();
    }
}

