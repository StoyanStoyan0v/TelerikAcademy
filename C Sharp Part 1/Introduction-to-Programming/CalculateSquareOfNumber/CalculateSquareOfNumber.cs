using System;

class CalculateSquareOfNumber
{
    static void Main()
    {        
        //First version of finding the square:
        int number = 12345;
        int numberSquare = number * number;
        Console.WriteLine(numberSquare);
        //Second version of finding the square:
        double nmb = 12345;
        double nmbSquare = Math.Pow(nmb, 2);
        Console.WriteLine(nmbSquare);
        

    }
}

