using System;

class PrintAreaAndPerimeterOfCircle
{
    static void Main()
    {
        int r = int.Parse(Console.ReadLine());
        Console.WriteLine("Area: {0}",Math.PI*r*r);
        Console.WriteLine("Perimeter: {0}",Math.PI*2*r);
    }
}

