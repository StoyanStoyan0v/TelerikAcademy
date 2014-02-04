using System;

class CatalanNumber
{
    static void Main()
    {

        string catalan;
        ulong catalanNumber = 0;
        bool isNumberPositive = false;
        Console.Write("n= ");
        while (!isNumberPositive)
        {
            try
            {
                isNumberPositive = true;
                catalan = Console.ReadLine();
                catalanNumber = ulong.Parse(catalan);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Enter a non-negative number!");
                Console.Write("n= ");
                isNumberPositive = false;
            }
        }

        // The expression ((2n)!)/((n+1)!*n!) = (2n*2n-1*.....*n+1)/(n+1)! so first calculate (2n*2n-1*.....*n+1):
        double firstSum = 1.0;
        for (ulong i = 2*catalanNumber; i > catalanNumber; i--)
        {
            firstSum *= i;
        }
        
        //Now calculate (n+1)!:
        double secondSum = 1.0;
        for (ulong i = 1; i <= catalanNumber + 1; i++)
        {
            secondSum *= i;
        }
        Console.WriteLine("Cn= "+ (firstSum/secondSum));

    }
}

