using System;

class IsPointInCircle
{
    static void Main()
    {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        if (Math.Sqrt((-x) * (-x) + (-y) * (-y)) < 5)
        {
            Console.WriteLine("The point(x,y) is inside circle K(0,5).");
        }
        else if (Math.Sqrt((-x) * (-x) + (-y) * (-y)) == 5)
        {
            Console.WriteLine("The point(x,y) is lying on circle K(0,5).");
        }
        else
        {
            Console.WriteLine("The point(x,y) is outside circle K(0,5).");
        }
    }
}

