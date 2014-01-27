using System;

class FallDown
{
    static void Main()
    {
        byte[] numbers = new byte[8];
        int mask = 1;
        for (int i = 0; i < 8; i++)
        {
            numbers[i] = byte.Parse(Console.ReadLine());
        }

        for (int pos = 0; pos < 8; pos++)
        {
            for (int j = 6; j >= 0; j--)
            {
                if ((numbers[j] >> pos) % 2 != 0)
                {
                    int moveDown = j;
                    while (moveDown <= 6 && (numbers[moveDown + 1] >> pos) % 2 == 0)
                    {
                        numbers[moveDown + 1] |= (byte)( mask << pos);
                        numbers[moveDown] &= (byte)(~(mask<<pos));
                        moveDown++ ;
                    }
                }
            }
        }
        for (int i = 0; i < 8; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}

