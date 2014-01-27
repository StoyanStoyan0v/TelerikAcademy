using System;

class CheckBit
{
    static void Main()
    {

        int v = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        int mask = 1 << p;
        bool isTheThirdBitEquialToOne = ((v & mask) >> p == 1);
        Console.WriteLine(isTheThirdBitEquialToOne); 
    }
}

