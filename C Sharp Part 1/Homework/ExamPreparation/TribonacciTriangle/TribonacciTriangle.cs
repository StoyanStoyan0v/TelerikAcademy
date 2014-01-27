using System;
using System.Numerics;

class TribonacciTriangle
{
    static void Main()
    {
        BigInteger firstTribonacci = BigInteger.Parse(Console.ReadLine());
        BigInteger secondTribonacci = BigInteger.Parse(Console.ReadLine());
        BigInteger thirdTribonacci = BigInteger.Parse(Console.ReadLine());
        BigInteger nextFibonacci = firstTribonacci + secondTribonacci + thirdTribonacci;

        int l = int.Parse(Console.ReadLine());
        for (int i = 1; i <= l; i++)
        {
            if (i == 1)
            {
                Console.Write(firstTribonacci);
            }
            else if (i == 2)
            {
                Console.Write(secondTribonacci + " " + thirdTribonacci);
            }
            else
            {
                for (int j = 1; j <= i; j++)
                {                   
                    Console.Write(nextFibonacci);
                    firstTribonacci = secondTribonacci;
                    secondTribonacci = thirdTribonacci;
                    thirdTribonacci = nextFibonacci;
                    nextFibonacci = firstTribonacci + secondTribonacci + thirdTribonacci;
                    if (j != l)
                    {
                        Console.Write(" ");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}

