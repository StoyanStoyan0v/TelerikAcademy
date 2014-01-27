using System;

class CompareFloatingPointNumbers
{
    static void Main()
    {
        Console.Write("Enter value for a: ");
        float a = float.Parse(Console.ReadLine());
        Console.Write("Enter value for a: ");
        float b = float.Parse(Console.ReadLine());
        bool isAEquialToB = (a == b);
        Console.WriteLine(isAEquialToB);
    }
}

