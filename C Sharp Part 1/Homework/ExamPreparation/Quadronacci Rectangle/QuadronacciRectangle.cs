using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        BigInteger firstTribonacci = BigInteger.Parse(Console.ReadLine());
        BigInteger secondTribonacci = BigInteger.Parse(Console.ReadLine());
        BigInteger thirdTribonacci = BigInteger.Parse(Console.ReadLine());
        BigInteger fourthTribonacci = BigInteger.Parse(Console.ReadLine());
        BigInteger nextFibonacci = firstTribonacci + secondTribonacci + thirdTribonacci+ fourthTribonacci;

        int r = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());      

        for (int i = 1; i <= r; i++)
        {
            if (i == 1)
            {
                if (c == 4)
                {
                    Console.Write("{0} {1} {2} {3} ", firstTribonacci, secondTribonacci, thirdTribonacci, fourthTribonacci);
                }
                else
                {
                    Console.Write("{0} {1} {2} {3} {4} ", firstTribonacci, secondTribonacci, thirdTribonacci, fourthTribonacci,nextFibonacci);
                }
                for (int j = 6; j <= c; j++)
                {
                    firstTribonacci = secondTribonacci;
                    secondTribonacci = thirdTribonacci;
                    thirdTribonacci = fourthTribonacci;
                    fourthTribonacci = nextFibonacci;
                    nextFibonacci = firstTribonacci + secondTribonacci + thirdTribonacci + fourthTribonacci;
                    Console.Write(nextFibonacci + " ");
                }
                Console.WriteLine();
            }
            else
            {
                for (int j = 1; j <= c; j++)
                {
                    if (c == 4 && j==1 && i==2)
                    {
                        Console.Write(nextFibonacci + " ");
                        continue;
                    }
                    firstTribonacci = secondTribonacci;
                    secondTribonacci = thirdTribonacci;
                    thirdTribonacci = fourthTribonacci;
                    fourthTribonacci = nextFibonacci;
                    nextFibonacci = firstTribonacci + secondTribonacci + thirdTribonacci + fourthTribonacci;
                    Console.Write(nextFibonacci + " ");
                }
                Console.WriteLine();
            }
        }                   
    }   
}

