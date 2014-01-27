using System;
using System.Numerics;

class Tribonacci
{
    static void Main()
    {
        BigInteger firstTribonacci = BigInteger.Parse(Console.ReadLine());
        BigInteger secondTribonacci = BigInteger.Parse(Console.ReadLine());
        BigInteger thirdTribonacci = BigInteger.Parse(Console.ReadLine());
        BigInteger nextFibonacci = firstTribonacci + secondTribonacci + thirdTribonacci;

        int n = int.Parse(Console.ReadLine());

        switch (n)
        {
            case 1: Console.WriteLine(firstTribonacci); break;
            case 2: Console.WriteLine(secondTribonacci); break;
            case 3: Console.WriteLine(thirdTribonacci); break;
            case 4: Console.WriteLine(nextFibonacci); break;
                default: break;
        }

        if (n > 4)
        {
            for (int i = 5; i <= n; i++)
            {
                firstTribonacci = secondTribonacci;
                secondTribonacci = thirdTribonacci;
                thirdTribonacci = nextFibonacci;
                nextFibonacci = firstTribonacci + secondTribonacci + thirdTribonacci;
            }
            Console.WriteLine(nextFibonacci);
        }
    }
}

