using System;

class PrintASCII
{
    static void Main()
    {

        for (int i = 0; i <= 255; i++)
        {
            Console.Write("{0,3} -> {1,3},   ", i, Convert.ToChar(i));
            if (i % 5 == 0 && i!=0)
            {
            Console.WriteLine();
            }
        }
    }
}

