using System;

class IsNumberPrime
{
    static void Main()
    {
        byte number = 0;
        do
        {
            Console.Write("Enter number between 0 and 100: ");
            number = byte.Parse(Console.ReadLine());
        }
        while(number>100);

        bool isPrime = true; ;
        for (byte i = 2; i < Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                isPrime = false;
                Console.WriteLine("The number is not prime.");
                break;
            }
        }
        if (isPrime)
        {
            Console.WriteLine("The number is prime.");
        }

    }
}

