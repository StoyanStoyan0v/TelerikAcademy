using System;

class CheckThirdDigit
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        bool isTheThirdDigitSeven=((number/100)%10==7);
        Console.WriteLine("Is the third digit of the number equial to 7: {0}.",isTheThirdDigitSeven);
    }
}

