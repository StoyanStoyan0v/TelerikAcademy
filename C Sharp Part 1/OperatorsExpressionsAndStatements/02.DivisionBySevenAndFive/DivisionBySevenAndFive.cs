using System;

class DivisionBySevenAndFive
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        bool isDividedWithoutRemainder = (number % 5 == 0 && number % 7 == 0);
        Console.WriteLine(isDividedWithoutRemainder);
    }
}

