using System;

class NumbersBetweenTwoNumbers
{
    static void Main()
    {
        uint firstNumber = uint.Parse(Console.ReadLine());
        uint secondNumber = uint.Parse(Console.ReadLine());
        int counter = 0;
        for (uint i = firstNumber; i <= secondNumber; i++)
        {
            if (i % 5 == 0)
            {
                counter++;
            }
        }
        Console.WriteLine("({0},{1}) -> {2}",firstNumber,secondNumber,counter );
    }
}

