using System;

class GreatestCommonDivisor
{
    static void Main()
    {
        string firstNumber = Console.ReadLine();
        int numberOne = int.Parse(firstNumber);
        string secondNumber = Console.ReadLine();
        int numberTwo = int.Parse(secondNumber);
        while (numberOne>0)
        {
            if (numberOne < numberTwo)
            {
                int temp = numberOne;
                numberOne = numberTwo;
                numberTwo = temp;
            }
            numberOne = numberOne % numberTwo;
        }
        Console.WriteLine(numberTwo);
    }
}

