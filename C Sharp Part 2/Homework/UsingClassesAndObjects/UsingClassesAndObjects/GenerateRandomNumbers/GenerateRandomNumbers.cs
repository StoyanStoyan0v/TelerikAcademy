using System;

class GenerateRandomNumbers
{
    static void Main()
    {
        //The random generator must be out of the loop to give different numbers (different seeds).
        //If it is in the loop it will generate the same number 10 times (numbers from a same seed).
        Random randomGenerator = new Random();

        for (int i = 0; i < 10; i++)
        {            
            int randomNumber = randomGenerator.Next(99,201);
            Console.WriteLine("Random number: "+randomNumber);
        }
    }
}

