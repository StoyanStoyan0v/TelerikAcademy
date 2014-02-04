using System;

class PrintSumForGivenNAndX
{
    static void Main()
    {
        Console.Write("n= ");
        string nNmb = Console.ReadLine();
        Console.Write("x= ");
        string xNmb = Console.ReadLine();
        uint n = uint.Parse(nNmb);
        uint x = uint.Parse(xNmb);
        double sum = 1.0;
        uint factoriel = 1;
        for (uint i = 1; i <= n; i++)
        {
            factoriel *=i;
            sum += factoriel / Math.Pow(x, i);
        }
        Console.WriteLine(sum);
    }
}

