using System;

class ExtractBitValue
{
    static void Main()
    {
        Console.Write("v= ");
        int i = int.Parse(Console.ReadLine());
        Console.Write("p= ");
        int p = int.Parse(Console.ReadLine());
        int mask = i >> p;
        int value = mask & 1;
        Console.Write("value= ");
        Console.WriteLine(value);
    }
}

