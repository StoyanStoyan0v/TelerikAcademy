using System;

class Neurons
{
    static void Main()
    {
        int n = 32;
        long[] number = new long[n];
        long mask =1;
        bool isBitReached = false;

        for (int i = 0; i < n; i++)
        {
            number[i] = long.Parse(Console.ReadLine());
            isBitReached = false;
            if (number[i] == (-1))
            {
                n = i;
                break;
            }

            for (int j = 31; j >= 0; j--)
            {
                if (((number[i] >> j) & mask) == 0)
                {
                    if (isBitReached == true)
                    {
                        number[i] |= mask << j;
                    }
                }
                else 
                {
                    if (isBitReached == false && ((number[i] >> (j - 1)& mask) == 0))
                    {                      
                        
                        bool onlyZeroes = true;
                        for (int m = j-2; m >= 0; m--)
                        {
                            if((number[i] >> m & mask) != 0)
                            {
                                onlyZeroes = false;
                            }
                        }
                        if (onlyZeroes == false)
                        {
                            isBitReached = true;
                        }
                        else
                        {
                            isBitReached = false;
                        }
                    }
                    else if (isBitReached == true)
                    {
                        isBitReached = false;
                    }
                    
                    number[i] &= (~(mask << j));

                    
                }
            }
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(number[i]);
        }
    }
}

