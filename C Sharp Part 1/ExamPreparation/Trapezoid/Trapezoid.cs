using System;

class Trapezoid
{
    static void Main()
    {
        //First we input a valid variable for the trapezoid dimensions.
        byte n = 0;
        Console.Write("N= ");
        do
        {
            n = byte.Parse(Console.ReadLine());
        }
        while (n < 3 || n > 39);

        //Then we print the lines of the trapezoid.
        byte borderPrintCounter = n;
        for (byte row = 1; row < n; row++)
        {
            if (row == 1)
            {
                for (int colFirst = 0; colFirst < 2 * n; colFirst++)
                {
                    if (colFirst >= n && colFirst <= 2 * n)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }

            for (byte col = 1; col <= 2 * n; col++)
            {

                if (col == borderPrintCounter || col == 2 * n)
                {
                    Console.Write("*");
                    if (col == borderPrintCounter)
                    {
                        borderPrintCounter--;
                    }
                }
                else
                {
                    Console.Write(".");
                }

            }
            Console.WriteLine();
            if (row == n - 1)
            {
                for (int colLast = 1; colLast <= 2 * n; colLast++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }


    }
}
