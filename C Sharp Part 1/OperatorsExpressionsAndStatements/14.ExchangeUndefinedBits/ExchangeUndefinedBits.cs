using System;

class ExchangeUndefinedBits
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number,p,q,k;
        number = int.Parse(Console.ReadLine());
        do
        {
            Console.Write("p= ");
            p = int.Parse(Console.ReadLine());
            Console.Write("q= ");
            q = int.Parse(Console.ReadLine());
            Console.Write("k= ");
            k = int.Parse(Console.ReadLine());
        }
        while ((k - 1) < p && (k - 1) < q && (k - 1) > 32 && (k - 1) < 0 && p > 32 && p < 0 && q > 32 && q < 0);

        int mask = 1;
        int tempNumber;
        int lowerBitValue;
        int higherBitValue;
        int lowerBit = p;
        int higherBit = q;
        Console.WriteLine("Initial number in binary: {0}.", Convert.ToString(number, 2).PadLeft(32, '0'));
        for (int i = 1; i <= k-1; i++, lowerBit++, higherBit++)
        {
            mask <<= lowerBit;
            lowerBitValue = (number & mask) >> lowerBit;
            mask >>= lowerBit;
            mask <<= higherBit;
            higherBitValue = (number & mask) >> higherBit;
            mask >>= higherBit;
            if (lowerBitValue != higherBitValue)
            {
                if (lowerBitValue == 1)
                {
                    tempNumber = number | (mask << higherBit);
                    number = tempNumber ^ (mask << lowerBit);
                }
                else
                {
                    tempNumber = number ^ (mask << higherBit);
                    number = tempNumber | (mask << lowerBit);
                }                
            }            
        }
        Console.WriteLine("New number in binary: {0}.", Convert.ToString(number, 2).PadLeft(32, '0'));
    }
}

