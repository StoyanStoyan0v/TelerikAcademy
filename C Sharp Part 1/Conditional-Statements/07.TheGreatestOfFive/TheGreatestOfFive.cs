using System;

class TheGreatestOfFive
{
    static void Main(string[] args)
    {
        string firstNumber = Console.ReadLine();
        string secondNumber = Console.ReadLine();
        string thirdNumber = Console.ReadLine();
        string fourthNumber = Console.ReadLine();
        string fifthNumber = Console.ReadLine();
        int numberOne = int.Parse(firstNumber);
        int numberTwo = int.Parse(secondNumber);
        int numberThree = int.Parse(thirdNumber);
        int numberFour = int.Parse(fourthNumber);
        int numberFive = int.Parse(fifthNumber);
        Console.WriteLine("\nThe greatest number is: ");

        if (numberOne > numberTwo && numberOne > numberThree && numberOne > numberFour && numberOne > numberFive)
        {
            Console.WriteLine(firstNumber);
        }
        else if(numberTwo > numberOne && numberTwo > numberThree && numberTwo > numberFour && numberTwo > numberFive)
        {
            Console.WriteLine(secondNumber);
        }
        else if(numberThree > numberTwo && numberThree > numberOne && numberThree > numberFour && numberThree > numberFive)
        {
            Console.WriteLine(thirdNumber);
        }
        else if (numberFour > numberTwo && numberFour > numberThree && numberFour > numberOne && numberFour > numberFive)
        {
            Console.WriteLine(fourthNumber);
        }
        else
        {
            Console.WriteLine(fifthNumber);
        }
    }
}

