using System;

class Lines
{
    static void Main()
    {
        byte[] number = new byte[8];
        int longestLine = 0;
        int countLongest = 1;
        int currentLongest = 0;


        for (int i = 0; i < number.Length; i++)
        {
            number[i] = byte.Parse(Console.ReadLine());
        }

        for (int pos = 0; pos < 8; pos++)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if ((number[i] >> pos) % 2 != 0)
                {
                    currentLongest++;
                    if (currentLongest > longestLine)
                    {
                        longestLine = currentLongest;
                        countLongest = 1;
                    }
                    else if (currentLongest == longestLine)
                    {
                        countLongest++;
                    }
                }
                else
                {
                    currentLongest = 0;
                }
                if (i == 7)
                {
                    currentLongest = 0;
                }
            }
        }

        currentLongest = 0;
        for (int i = 0; i < number.Length; i++)
        {
            for (int pos = 0; pos < 8; pos++)
            {
                if ((number[i] >> pos) % 2 != 0)
                {
                    currentLongest++;
                    if (currentLongest > longestLine)
                    {
                        longestLine = currentLongest;
                        countLongest=1;
                    }
                    else if (currentLongest == longestLine && currentLongest!=1)
                    {
                        countLongest++;
                    }
                }
                else
                {
                    currentLongest = 0;
                }
                if (pos == 7)
                {
                    currentLongest = 0;
                }
            }          
        }
        if (longestLine == 1)
        {
            countLongest = 0;
            for (int pos = 0; pos < 8; pos++)
            {
                for (int i = 0; i < number.Length; i++)
                {
                    if ((number[i] >> pos) % 2 != 0)
                    {
                        countLongest++;
                    }
                }
            }
        }
        Console.WriteLine(longestLine);
        Console.WriteLine(countLongest);      
    }
}

