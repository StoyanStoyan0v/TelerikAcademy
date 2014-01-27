using System;

class CheckTheThirdBit
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int mask = 1 << 3;
        bool isTheThirdBitEquialToOne = ((number & mask) >> 3 == 1);
        if (isTheThirdBitEquialToOne)
        {
            Console.WriteLine("The third bit is 1.");
        }
        else
        {
            Console.WriteLine("The third bit is 0.");
        }
    }
}

