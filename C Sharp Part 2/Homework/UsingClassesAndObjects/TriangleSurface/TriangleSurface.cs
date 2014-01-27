using System;

class TriangleSurface
{
    //Overload a method to take diffent count ot type of parameters.
    static void CalculateSurface(double side,double attitude)
    {
        double surface = side * attitude / 2;
        Console.WriteLine("Side: "+side);
        Console.WriteLine("Attitude: "+attitude);
        Console.WriteLine("Surface: " +surface);
        Console.WriteLine();
    }

    static void CalculateSurface(double firstSide, double secondSide, double thirdSide)
    {
        //The formula is S= Sqrt(p*(p-a)*(p-b)*(p-c)).
        double halfPerimeter = (firstSide + secondSide + thirdSide)/2; //Get p.
        //Get "p*(p-a)*(p-b)*(p-c)" part.
        double squareBase = halfPerimeter*(halfPerimeter-firstSide)*(halfPerimeter-secondSide)*(halfPerimeter-thirdSide);
        //Calculate the formula.
        double surface = Math.Sqrt(squareBase);
        Console.WriteLine("First side: " + firstSide);
        Console.WriteLine("Second side: " + secondSide);
        Console.WriteLine("Third side: " + thirdSide);
        Console.WriteLine("Surface: "+surface);
        Console.WriteLine();
    }

    static void CalculateSurface(double firstSide,double secondSide,int angleInDegrees)
    {
        double angleInRadians = angleInDegrees*Math.PI/180.0;
        double sinAngle = Math.Sin(angleInRadians);
        double surface = firstSide * secondSide * sinAngle / 2;
        Console.WriteLine("First side: " + firstSide);
        Console.WriteLine("Second side: " +secondSide);
        Console.WriteLine("Angle in degrees: "+angleInDegrees);
        Console.WriteLine("Surface: "+surface);
        Console.WriteLine();
    }

    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Surface by given side and altitude to it:");
        Console.ForegroundColor = ConsoleColor.Green;
        CalculateSurface(10.0,5.0);
        
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Surface by given three sides:");
        Console.ForegroundColor = ConsoleColor.Green;
        CalculateSurface(10.00, 10.00, 12.00);        

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Surface by given two sides and an angle between them:");
        Console.ForegroundColor = ConsoleColor.Green;
        CalculateSurface(8.00, 8.00, 30);

        Console.ResetColor();
    }
}

