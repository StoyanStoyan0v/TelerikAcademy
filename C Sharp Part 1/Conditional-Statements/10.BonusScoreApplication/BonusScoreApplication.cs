using System;

class BonusScoreApplication
{
    static void Main()
    {
        ushort parseDigit = 20; //The variable which will be parsed is outside because it's used by the loop to set the conditions.

        //This loop will make the program always asking for a digit if it is outside the scope of 1 to 9.
        while (parseDigit < 1 || parseDigit > 9)
        {
            string digit = null;
            Console.Write("Enter a valid digit different from 0: ");
            //This loop will make the program asking for a valid digit..
            while (!ushort.TryParse(digit, out parseDigit))
            {
                digit = Console.ReadLine();

                if (ushort.TryParse(digit, out parseDigit))
                {
                    break; //if the parse is valid, end the loop without typing the digit validation request.
                }
                Console.Write("The value is not a digit. Enter a new digit: ");
            }
        }
        switch (parseDigit)
        {
            case 1:
            case 2:
            case 3: parseDigit *= 10; break;
            case 4:
            case 5:
            case 6: parseDigit *= 100; break;
            case 7:
            case 8:
            case 9: parseDigit *= 1000; break;
            default: break;
        }       
        Console.WriteLine("Score: " + parseDigit);
    }
}

