using System;
using System.Numerics;

class TrailingZeros
{
    static void Main()
    {
        Console.Write("N= ");
        string input = Console.ReadLine();
        int nFactoriel = int.Parse(input);
        int trailingZeros = nFactoriel / 5;
        for (int i = 1; i <= nFactoriel; i++)
        {
            if (i % 25 == 0)
            {
                trailingZeros++;
            }
        }
        BigInteger sumFactoriel = 1;
        for (int i = 1; i <= nFactoriel; i++)
        {
            sumFactoriel *= i;
        }
        Console.Write("Trailing zeros: ");
        Console.WriteLine("{0} -> {1}",sumFactoriel,trailingZeros);
    }
}

