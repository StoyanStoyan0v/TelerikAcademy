using System;

class NFacTimesKFacDividedByKMinusNFac
{
    static void Main()
    {
        uint n = 0;
        uint k = 0;
        Console.WriteLine("Enter valuse for k and n (1<k<n): ");

        while (n < 1 || n >= k)
        {
            Console.Write("k= ");
            string kNumber = Console.ReadLine();
            k = uint.Parse(kNumber);

            Console.Write("n= ");
            string nNumber = Console.ReadLine();
            n = uint.Parse(nNumber);           
        }
        uint result = 1;
        for (uint j = k; j > k-n; j--)
        {
            result *= j; 
        }
        for (uint i = n; i > 0; i--)
        {
            result *= i;
        }
        Console.WriteLine("n!*k!/(k-1)!= {0}",result);
    }
}

