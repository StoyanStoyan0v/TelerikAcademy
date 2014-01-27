using System;

class WeAllLoveBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        int newP = 0;
        int reversedP = 0;
        int lastPos = 0;
        int mask=0;

        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 31; j >= 0; j--)
            {
                if ((numbers[i] >> j) % 2 != 0)
                {
                    lastPos = j;
                    break;
                }
            }


            for (int j = lastPos, p =0; j >= 0; j--,p++)
            {
                if ((numbers[i] >> j) % 2 != 0)
                {
                    mask=1;
                    reversedP |= mask << p;
                }
            }
            newP = (numbers[i] ^ (~numbers[i])) & reversedP;
            Console.WriteLine(newP);
            reversedP = 0;
                       
        }
    }
}

