using System;

class TrapezoidArea
{
    static void Main()
    {
        float a = float.Parse(Console.ReadLine());
        float b = float.Parse(Console.ReadLine());
        float h = float.Parse(Console.ReadLine());
        float area = ((a + b) * h) / 2;
        Console.WriteLine(area);
    }
}

