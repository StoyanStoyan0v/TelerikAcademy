using System;

class UpAndDownGame
{
    static void Main()
    {
        Console.WriteLine("Up and down game: ");

        Random number = new Random();
        int theNumber = number.Next(1, 101);
        int minNumber = 1;
        int maxNumber = 100;

        Console.WriteLine("Guess the number [1,100]!");
        while (true)
        {
            Console.WriteLine("Enter number between {0} and {1}: ",minNumber,maxNumber);
            string input=null;
            int yourNumber;
            while(!int.TryParse(input,out yourNumber))
            {
                input = Console.ReadLine();
                if (!int.TryParse(input, out yourNumber))
                {
                    Console.Write("Enter valid number: ");
                }
            }

            if (yourNumber == theNumber)
            {
                Console.WriteLine("Congratulations! You have guessed the number {0}!",theNumber);
                break;
            }
            else if (yourNumber > theNumber)
            {
                Console.WriteLine("Down!");
                maxNumber = yourNumber;
            }
            else
            {
                Console.WriteLine("Up!");
                minNumber = yourNumber;
            }
            
        }
    }
}

