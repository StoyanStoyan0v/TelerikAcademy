using System;

class OddOrEven
{
    static void Main()
    {
        Console.Write("Number: ");
        int number = int.Parse(Console.ReadLine());
        bool isNumberEven = number % 2 == 0;
        Console.Write("Is the number even: ");
        Console.WriteLine(isNumberEven);
    }
}

