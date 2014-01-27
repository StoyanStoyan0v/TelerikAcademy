using System;

class SieveOfEratosthenes
{
    //Keep our most used variable as globals and avoid giving them as paramethers of the methods everytime...
    static bool[]isPrime;
    static int lastNumber;

    static void PrimeNumbersExtractor()
    {
        //Keep all numbers from 1 to n(lastNumber) in a boolean array as prime initialy..
        isPrime = new bool[lastNumber];
        for (int i = 0; i < lastNumber; i++)
        {
            isPrime[i] = true;
        }

        //Start looping throughout the numbers and change the boolean value to false if the number is not prime.
        //Repeate until we have not a prime number left...
        for (int i = 2; i < Math.Sqrt(lastNumber); i++)
        {
            if (isPrime[i] == true)//If prime continue...
            {
                //Make all power numbers and multiples of the numbers to be not prime and continue with the next prime if such is available..
                for (int j = i * i; j < lastNumber; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }

        PrintResult();
    }

    static void PrintResult()
    {
        Console.Write(1 + " ");
        for (int i = 2; i < lastNumber; i++)
        {
            if (isPrime[i] == true)
            {
                Console.Write("{0} ", i);
            }
        }
        Console.WriteLine();
    }
    static void Main()
    {
        Console.Write("Type N to extract all the prime numbers from 1 to N(excluded): ");
        lastNumber = int.Parse(Console.ReadLine());
        Console.WriteLine();
        PrimeNumbersExtractor();

    }   
}

