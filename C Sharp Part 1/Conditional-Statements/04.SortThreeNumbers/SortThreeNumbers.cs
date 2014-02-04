using System;

class SortThreeNumbers
{
    static void Main()
    {
        string firstNumber = Console.ReadLine();
        string secondNumber = Console.ReadLine();
        string thirdNumber = Console.ReadLine();
        int numberOne = int.Parse(firstNumber);
        int numberTwo = int.Parse(secondNumber);
        int numberThree = int.Parse(thirdNumber);
        if (numberOne > numberTwo && numberOne > numberThree)
        {
            if (numberThree < numberTwo)
            {
                Console.WriteLine("{0} {1} {2}", numberOne, numberTwo, numberThree);
            }
            else
            {
                Console.WriteLine("{0} {1} {2}", numberOne, numberThree, numberTwo);
            }
        }
        else if(numberOne > numberTwo && numberOne < numberThree)
        {
            Console.WriteLine("{0} {1} {2}", numberThree, numberOne, numberTwo);
        }
        else if (numberOne < numberTwo && numberOne < numberThree)
        {
            if (numberTwo > numberThree)
            {
                Console.WriteLine("{0} {1} {2}", numberTwo, numberThree, numberOne);
            }
            else
            {
                Console.WriteLine("{0} {1} {2}", numberThree, numberTwo, numberOne);
            }
        }
        else
        {
            Console.WriteLine("{0} {1} {2}", numberTwo, numberOne, numberThree);
        }
    }
}

