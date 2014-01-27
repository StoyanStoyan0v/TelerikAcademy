using System;

class SwapValues
{
    static void Main()
    {
        Console.Write("a= ");
        int numberA = int.Parse(Console.ReadLine());
        Console.Write("b= ");
        int numberB = int.Parse(Console.ReadLine());

        int keeperOfA = numberA;
        numberA = numberB;
        numberB = keeperOfA;
        Console.WriteLine("a= "+numberA);
        Console.WriteLine("b= "+numberB);
    }
}
