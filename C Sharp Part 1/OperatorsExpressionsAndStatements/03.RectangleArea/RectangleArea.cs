using System;

class RectangleArea
{
    static void Main()
    {
        Console.Write("Length: ");
        double length = double.Parse(Console.ReadLine());
        Console.Write("Width: ");
        double width = double.Parse(Console.ReadLine());
        Console.Write("Rectangle area: ");
        Console.WriteLine(length*width);

    }
}

