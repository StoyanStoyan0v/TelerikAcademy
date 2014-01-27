using System;

class PrintNumbers
{
    static void Main()
    {
        //First Version:
        Console.WriteLine(1);
        Console.WriteLine(101);
        Console.WriteLine(1001);
        Console.WriteLine();
        //Second Version:
        int digitOne = 1;
        int digitZero = 0;
        Console.WriteLine(digitOne);
        Console.WriteLine(digitOne+""+digitZero+""+digitOne);
        Console.WriteLine(digitOne + "" + digitZero + "" + digitOne +"" +digitOne);
        
    }
}

