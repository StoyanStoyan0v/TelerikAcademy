using System;

class FormatNumber
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("{0,15}",number);
        Console.WriteLine("{0,15:X}",number);
        Console.WriteLine("{0,15:P}",(double)number/100);
        Console.WriteLine("{0,15:E}",number);
    }
}

