using System;
using System.Numerics;

class LeastMajorityMultiple
{
    static void Main()
    {
        BigInteger a;
        do
        {
            string number1 = Console.ReadLine();
            a = BigInteger.Parse(number1);

        }
        while (a == 0 || a < 1 || a > 100);

        BigInteger b;
        do
        {
            string number2 = Console.ReadLine();
            b = BigInteger.Parse(number2);

        }
        while (b == a || b == 0 || b < 1 || b > 100);


        BigInteger c;
        do
        {
            string number3 = Console.ReadLine();
            c = BigInteger.Parse(number3);

        }
        while (c == b || c == a || c == 0 || c < 1 || c > 100);


        BigInteger d;
        do
        {
            string number4 = Console.ReadLine();
            d = BigInteger.Parse(number4);
        }
        while (d == c || d == b || d == a || d == 0 || d < 1 || d > 100);


        BigInteger e;
        do
        {
            string number5 = Console.ReadLine();
            e = BigInteger.Parse(number5);
        }
        while (e == d || e == c || e == b || e == a || e == 0 || e < 1 || e > 100);

        int count = 0;
        BigInteger MajorityMultiple = 0;
        BigInteger maxDivisor = a * b * c * d * e;
        for (BigInteger i = 1; i <= maxDivisor; i++)
        {
            if (i % a == 0)
            {
                count++;
            }

            if (i % b == 0)
            {
                count++;
            }

            if (i % c == 0)
            {
                count++;
            }

            if (i % d == 0)
            {
                count++;
            }

            if (i % e == 0)
            {
                count++;
            }

            if (count == 3)
            {
                MajorityMultiple = i;
                break;
            }

            else if (count == 4)
            {
                MajorityMultiple = i;
                break;
            }

            else if (count == 5)
            {
                MajorityMultiple = i;
                break;
            }

            count = 0;
        }
        Console.WriteLine(MajorityMultiple);
    }
}


