using System;

class CompareTwoVariables
{
    static void Main()
    {
        Console.Write("a= ");
        string firstNumber = Console.ReadLine();
        Console.Write("b= ");
        string secondNumber = Console.ReadLine();
        int numberOne = int.Parse(firstNumber);
        int numberTwo = int.Parse(secondNumber);
        int tempNumber=0;   //This variable will keep the first number for using it after the first number is changed to the second one.
        if (numberOne > numberTwo)
        {
            tempNumber = numberOne;
            numberOne = numberTwo;
            numberTwo = tempNumber;
        }
        Console.WriteLine();
        Console.WriteLine("a= {0}",numberOne);
        Console.WriteLine("b= {0}",numberTwo);
    }
}

