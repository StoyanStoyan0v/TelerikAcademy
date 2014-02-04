using System;
using System.Text;

class CopyrightTriangle
{
    static void Main()
    {
        char ch = '©';
        Console.WriteLine("{0,3}",ch);
        for (int col = 1; col <= 2; col++)
        {
            Console.Write("{0,2}", ch);                                    
        }
        Console.WriteLine();
        for (int col = 1; col <= 5;col++ )
        {
            Console.Write(ch);
        }
        Console.WriteLine();
        Console.WriteLine();
    }
}

