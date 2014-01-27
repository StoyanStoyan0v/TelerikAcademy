using System;

class OddNumber
{
    static void Main()
    {
        uint n = 0;
        while (n % 2 == 0 || (n < 1 || n > 99999))
        {
            n = uint.Parse(Console.ReadLine());
        }

        long OddNumber = long.Parse(Console.ReadLine());

        for (int i = 1; i <= n - 1; i++)
        {
            long number = long.Parse(Console.ReadLine());
            OddNumber ^= number;
        }

        Console.WriteLine(OddNumber);
    }
}
