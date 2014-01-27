using System;

class BinaryDigitsCount
{
    static void Main()
    {
        uint b = uint.Parse(Console.ReadLine());
        uint n = uint.Parse(Console.ReadLine());
        uint[] numbers = new uint[n];
        int counter = 0;
        int lastPos = 0;

        for (int i = 0; i < n; i++)
        {
            numbers[i] = uint.Parse(Console.ReadLine());
        }

       
        for (int j = 0; j < n; j++)
        {
            for (int i = 31; i >= 0; i--)
            {
                if ((numbers[j] >> i) % 2 != 0)
                {
                    lastPos = i;
                    break;
                }
            }

            for (int i = 0; i <= lastPos; i++)
            {
                if ((numbers[j] >> i) % 2 == b)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
            counter = 0;
        }        
    }
}

