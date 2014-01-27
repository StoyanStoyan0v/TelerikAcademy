using System;

class NFacDividedByKFac
{
    static void Main()
    {
        uint n=0;
        uint k=0;
        Console.WriteLine("Enter valuse for k and n (1<k<n): ");
        while (k < 1 || k >= n)
        {
            Console.Write("n= ");
            string nNumber = Console.ReadLine();
            n = uint.Parse(nNumber);
            Console.Write("k= ");
            string kNumber = Console.ReadLine();
            k = uint.Parse(kNumber);           
        }

        //n!/k! = n*(n-1)*(n-2)....*(n-k+1)
        uint result = 1;
        for (uint i = n; i > k; i--)
        {
            result *= i;
        }
        Console.WriteLine("n!/k!= {0}",result);
    }
}

