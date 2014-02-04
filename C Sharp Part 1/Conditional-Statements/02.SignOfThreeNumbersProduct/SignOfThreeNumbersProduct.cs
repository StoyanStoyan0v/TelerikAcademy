using System;

class SignOfThreeNumbersProduct
{
    static void Main()
    {
        string firstNumber = Console.ReadLine();
        string secondNumber = Console.ReadLine();
        string thirdNumber = Console.ReadLine();
        int numberOne = int.Parse(firstNumber);
        int numberTwo = int.Parse(secondNumber);
        int numberThree = int.Parse(thirdNumber);
        Console.Write("The product of {0},{1} and {2}",firstNumber,secondNumber,thirdNumber);

        //First check if the first number is negative, positive or zero and then proceed to the product of the other two.
        if (numberOne > 0)
        {            
            if ((numberTwo > 0 && numberThree > 0) || (numberTwo < 0 && numberThree < 0))
            {
                Console.WriteLine(" is positive.");
            }           
            else if (numberThree != 0 && numberTwo != 0) 
            {
                Console.WriteLine(" is negative.");
            }                
            else
            {
                Console.WriteLine(" is unsigned (zero).");
            }
        }
        else if (numberOne < 0)
        {
            if ((numberTwo > 0 && numberThree < 0) || (numberTwo < 0 && numberThree > 0))
            {
                Console.WriteLine(" is positive.");
            }
            else if (numberThree != 0 && numberTwo != 0)
            {
                Console.WriteLine(" is negative.");
            }
            else
            {
                Console.WriteLine(" is unsigned (zero).");
            }
        }
        else
        {
            Console.WriteLine(" is unsigned (zero).");
        }
    }
}

