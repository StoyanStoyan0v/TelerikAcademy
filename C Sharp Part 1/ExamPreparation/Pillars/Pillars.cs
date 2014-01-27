using System;

class Pillars
{
    //Score 80/100
    static void Main()
    {
        
        byte[] number = new byte[8];
        int leftBits = 0;
        int rightBits = 0;
        int col = 0;

        for (int i = 0; i < number.Length; i++)
        {
            number[i] = byte.Parse(Console.ReadLine());
        }

        for (int pos = 0; pos <= 7; pos++)
        {
            rightBits = 0;
            leftBits = 0;

            for (int i = pos-1; i >= 0; i--)
            {

                for (int num = 0; num < number.Length; num++)
                {
                    if ((number[num] >> i) % 2 != 0)
                    {
                        rightBits++;
                    }
                }
            }

            for (int i = pos+1; i <= 7; i++)
            {
                for (int num = 0; num < number.Length; num++)
                {
                    if ((number[num] >> i) % 2 != 0)
                    {
                        leftBits++;
                    }
                }
            }
            if (rightBits == leftBits)
            {
                col = pos;
                Console.WriteLine(col);
                Console.WriteLine(leftBits);   
                break;
            }
            if (pos == 6)
            {
                Console.WriteLine("No");
            }
        }
    }
}

