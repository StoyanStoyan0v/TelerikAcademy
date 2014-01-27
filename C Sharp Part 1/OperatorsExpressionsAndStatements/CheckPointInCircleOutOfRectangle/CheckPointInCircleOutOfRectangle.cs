using System;

class CheckPointInCircleOutOfRectangle
{
    static void Main()
    {
        float x = float.Parse(Console.ReadLine());
        float y = float.Parse(Console.ReadLine());
        bool inCircle = Math.Sqrt((x-1) * (x-1) + (y-1) * (y-1)) < 3;
        bool outOfRectangle = (x < (-1)) || ((x>(-1)&&x<(5))&&(y > 1 || y < (-1)));
        bool inCircleAndOutOfRectangle = inCircle && outOfRectangle;
        Console.Write("Is point (x,y) in circle K(1,1) and out of rectangle R: ");
        Console.WriteLine(inCircleAndOutOfRectangle);
    }
}

