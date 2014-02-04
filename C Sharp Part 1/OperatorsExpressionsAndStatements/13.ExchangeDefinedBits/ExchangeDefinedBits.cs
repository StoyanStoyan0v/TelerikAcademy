using System;

class ExchangeDefinedBits
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        int mask = 1;
        int tempNumber;
        int lowerBitValue;
        int higherBitValue;
        int lowerBit = 3;
        int higherBit = 24;
        Console.WriteLine("Initial number in binary: {0}.", Convert.ToString(number, 2).PadLeft(32, '0'));
        for (int i = 1; i <= 3; i++, lowerBit++, higherBit++)
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
