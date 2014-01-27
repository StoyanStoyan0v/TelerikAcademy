using System;

class MathExpression
{
    static void Main(string[] args)
    {
        double n, m, p;
        do
        {
            n = double.Parse(Console.ReadLine());
            m = double.Parse(Console.ReadLine());
            p = double.Parse(Console.ReadLine());
        }
        while (m * p == 0 || n - 128.523123123 * p == 0 || n < (-10000000) || n > 10000000 || m < (-10000000) || m > 10000000 || p < (-10000000) || p > 10000000);

        double nominator = n * n + 1 / (m * p) + 1337;
        double denominator = n - (128.523123123) * p;
        Console.WriteLine("{0:F6}", nominator / denominator + Math.Sin((int)m % 180));
    }
}

