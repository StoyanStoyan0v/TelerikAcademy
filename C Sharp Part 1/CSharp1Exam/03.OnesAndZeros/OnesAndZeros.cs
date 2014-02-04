using System;

class OnesAndZeros
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        for (int j = 0; j < 5; j++)
        {
            if (j == 0 || j == 4)
            {
                for (int i = 15; i >= 0; i--)
                 {
                    if ((number >> i) % 2 == 0)
                    {
                        Console.Write("###");
                    }
                    else
                    {
                        if (j != 4)
                        {
                            Console.Write(".#.");
                        }
                        else
                        {
                            Console.Write("###");
                        }
                    }
                    if (i != 0)
                    {
                        Console.Write(".");
                    }
                }
            }
            else
            {
                for (int i = 15; i >= 0; i--)
                {
                    if ((number >> i) % 2 == 0)
                    {
                        Console.Write("#.#");
                    }
                    else
                    {
                        if (j != 1)
                        {
                            Console.Write(".#.");
                        }
                        else
                        {
                            Console.Write("##.");
                        }
                    }
                    if (i != 0)
                    {
                        Console.Write(".");
                    }
                }
            }
            Console.WriteLine();
        }
        
    }
}

