using System;

class HelloName
{
    static void PrintName(string name)
    {
        Console.WriteLine("Hello, {0}!",name);
    }

    static void Main()
    {
        string someName = Console.ReadLine();
        PrintName(someName);
    }
}

