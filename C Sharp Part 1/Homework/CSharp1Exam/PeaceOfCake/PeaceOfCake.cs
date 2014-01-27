using System;

class PeaceOfCake
{
    static void Main(string[] args)
    {
        decimal a = int.Parse(Console.ReadLine());
        decimal b = int.Parse(Console.ReadLine());
        decimal c = int.Parse(Console.ReadLine());
        decimal d = int.Parse(Console.ReadLine());     

        ulong denominator = (ulong)(b * d);
        ulong nominator = (ulong)(d * a + b * c);

        decimal firstFraction = a / b;
        decimal secondFraction = c / d;
        decimal totalCakes = firstFraction + secondFraction;

        if (totalCakes > 1)
        {
            Console.WriteLine((ulong)totalCakes);
            Console.WriteLine("{0}/{1}",nominator,denominator);
        }
        else
        {
            Console.WriteLine("{0:0.0000000000000000000000}",totalCakes);
            Console.WriteLine("{0}/{1}", nominator, denominator);
        }
    }
}

