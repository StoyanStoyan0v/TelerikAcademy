using System;

class SumWithAccuracy
{
    static void Main()
    {
        int maxDenominator = int.Parse(Console.ReadLine());
        float sum = 1.0f;
        for (int i = 2; i <= maxDenominator; i++)
        {
            sum += 1.0f / i;
            Console.WriteLine("{0:0.000}", sum);
        }
        
    }
}

