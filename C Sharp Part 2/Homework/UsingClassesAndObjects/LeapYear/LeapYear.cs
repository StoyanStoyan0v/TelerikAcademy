using System;

class LeapYear
{
    static void Main()
    {
        Console.Write("Enter year: ");
        int year = int.Parse(Console.ReadLine());
        Console.WriteLine("Is {0} year leap: {1}",year,DateTime.IsLeapYear(year));
    }
}

