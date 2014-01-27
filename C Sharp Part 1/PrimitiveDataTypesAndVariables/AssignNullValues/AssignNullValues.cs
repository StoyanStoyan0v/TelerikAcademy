using System;

class AssignNullValues
{
    static void Main(string[] args)
    {
        int? number = null;
        Console.WriteLine("Integer with \"null\" value: " + number);
        number = 1991;
        Console.WriteLine("Integer with some different value: " + number);
        Console.WriteLine();

        double? newNumber = null;
        Console.WriteLine("This is the new number with \"null\" value: "+newNumber);
        newNumber = 3.3792;
        Console.WriteLine("This is the new number with some different value: " + newNumber);
    }
}

