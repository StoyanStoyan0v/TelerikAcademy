using System;
using System.Numerics;

class FirstNMembersOfFibonacci
{
    static void Main()
    {
        string fibonacciLast = Console.ReadLine();
        uint lastFibonacci = uint.Parse(fibonacciLast);
        BigInteger firstFibonacci = 0;
        BigInteger secondFibonacci = 1;
        BigInteger thirdFibonacci = firstFibonacci + secondFibonacci;
        Console.Write(firstFibonacci+" ");
        Console.Write(secondFibonacci + " ");
        Console.Write(thirdFibonacci + " ");
        for (int i = 4; i <= lastFibonacci; i++)
        {
            firstFibonacci = secondFibonacci;
            secondFibonacci = thirdFibonacci;
            thirdFibonacci = firstFibonacci + secondFibonacci;
            Console.Write(thirdFibonacci + " ");
        }
        Console.WriteLine();
    }
}

