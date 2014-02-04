using System;

class Program
{
    static void Main()
    {
        Console.Write("Type your first name: ");
        string firstName = Console.ReadLine();
        Console.Write("Type your last name: ");
        string lastName = Console.ReadLine();   
        Console.Write("Your first and second names: "); 
        Console.WriteLine(firstName + " " + lastName);
    }
}

