using System;

class CoefficientsOfQuadraticEquation
{
    static void Main()
    {
        Console.Write("a= ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b= ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("c= ");
        double c = double.Parse(Console.ReadLine());
        double det = Math.Sqrt(Math.Pow(b, 2) - 4 * a * c);
        Console.WriteLine("({0})x^2+({1})x+({2})=0",a,b,c);
        if (a != 0)
        {
            if (b != 0)
            {
                if (c != 0)
                {
                    if (det >= 0)
                    {
                        if (det > 0)
                        {
                            Console.Write("x1= ");
                            Console.WriteLine((((-b) + det)) / 2);
                            Console.Write("x2= ");
                            Console.WriteLine((((-b) - det)) / 2);
                        }
                        else
                        {
                            Console.Write("x1=x2= ");
                            Console.WriteLine((-b) / 2 * a);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No real roots!");
                    }
                }
                else
                {
                    Console.WriteLine("x1= 0");
                    Console.Write("x2= ");
                    Console.WriteLine((-b) / a);
                }
            }
            else
            {
                Console.Write("x1= ");
                Console.WriteLine(-(Math.Sqrt((-c) / a)));
                Console.Write("x2= ");
                Console.WriteLine(Math.Sqrt((-c) / a));
            }
        }
        else
        {
            if (b != 0)
            {
                Console.Write("x= ");
                Console.WriteLine((-c) / b);
            }
            else
            {
                Console.WriteLine("No real roots!");
            }
        }
    }
}

