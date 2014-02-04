using System;

class PrintGreaterNumber
{
    static void Main()
    {
        double numberOne = double.Parse(Console.ReadLine());
        double numberTwo = double.Parse(Console.ReadLine());
        Console.WriteLine(Math.Max(numberOne,numberTwo));
    }
}

