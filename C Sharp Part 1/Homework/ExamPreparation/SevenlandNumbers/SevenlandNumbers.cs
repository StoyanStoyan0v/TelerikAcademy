using System;

class SevenlandNumbers
{
    static void Main()
    {
        int k = int.Parse(Console.ReadLine());
        int digit = k % 10;
        int tens = (k/10)%10;
        int hundreds=k/100;

        if (digit == 6)
        {
            if (hundreds != 6)
            {
                if (tens != 6)
                {
                    k = hundreds*100 + (tens + 1) * 10;
                }
                else
                {
                    k = (hundreds + 1) * 100;
                }
            }
            else
            {
                if (tens != 6)
                {
                    k = 600 + (tens + 1) * 10;
                }
                else
                {
                    k = 1000;
                }
            }

        }
        else
        {
            k++;
        }
        
        Console.WriteLine(k);      
    }
}

