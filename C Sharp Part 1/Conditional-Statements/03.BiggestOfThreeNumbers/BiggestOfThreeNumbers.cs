using System;

class BiggestOfThreeNumbers
{
    static void Main()
    {
        string firstNumber = Console.ReadLine();
        string secondNumber = Console.ReadLine();
        string thirdNumber = Console.ReadLine();
        int numberOne = int.Parse(firstNumber);
        int numberTwo = int.Parse(secondNumber);
        int numberThree = int.Parse(thirdNumber);
        if (numberOne > numberTwo)
        {
            if (numberOne > numberThree)
            {
                Console.WriteLine("The biggest number is {0}.", numberOne);
            }
            else
            {
                Console.WriteLine("The biggest number is {0}.", numberThree);
            }
        }
        else if (numberTwo > numberThree)
        {
            Console.WriteLine("The biggest number is {0}.", numberTwo);
        }
        else
        {
            Console.WriteLine("The biggest number is {0}.", numberThree);
        }       
    }
}

