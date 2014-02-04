using System;

class DigitName
{
    static void Main()
    {
        byte parseDigit=20; //The variable which will be parsed is outside because it's used by the loop to set the conditions.

        //This loop will make the program asking for a digit if it is outside the scope of 0 to 9.
        while (parseDigit < 0 || parseDigit > 9) 
        {
            string digit = Console.ReadLine();
            parseDigit = byte.Parse(digit);
            switch (parseDigit)
            {
                case 0: Console.WriteLine("The digit is zero."); break;
                case 1: Console.WriteLine("The digit is one."); break;
                case 2: Console.WriteLine("The digit is two."); break;
                case 3: Console.WriteLine("The digit is three."); break;
                case 4: Console.WriteLine("The digit is four."); break;
                case 5: Console.WriteLine("The digit is five."); break;
                case 6: Console.WriteLine("The digit is six."); break;
                case 7: Console.WriteLine("The digit is seven."); break;
                case 8: Console.WriteLine("The digit is eight."); break;
                case 9: Console.WriteLine("The digit is nine."); break;               
                default: Console.WriteLine("You have entered too many digits. Enter one digit: "); break;
            }
        }
    }
}

