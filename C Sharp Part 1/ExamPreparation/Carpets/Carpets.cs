using System;

class Carpets
{
    static void Main()
    {
        byte n = 1;
        while (n % 2 != 0 || (n < 2 || n > 80))
        {
            string input = Console.ReadLine();
            n = byte.Parse(input);
        }
        int dotPrinter = n / 2 - 1;
        int dasthPrinter = n / 2 - dotPrinter;
        for (int i = 1; i <= n/2; i++)
        {         
            if(i%2!=0)
            {
                Console.Write(new string('.', dotPrinter));
                for (int j = 1; j <= dasthPrinter; j++)
			    {
                    if (j != dasthPrinter)
                    {
                        Console.Write("/ ");
                    }
                    else
                    {
                        Console.Write("/");
                    }
			    }                
                for (int j = 1; j <= dasthPrinter; j++)
                {
                    if (j != dasthPrinter)
                    {
                        Console.Write("\\ ");
                    }
                    else
                    {
                        Console.Write("\\");
                    }
                }
                Console.Write(new string('.', dotPrinter));
            }            
            if (i % 2 == 0)
            {
                Console.Write(new string('.', dotPrinter));
                for (int j = 1; j <= dasthPrinter; j++)
                {
                    Console.Write("/ ");
                }

                for (int j = 1; j <= dasthPrinter; j++)
                {
                    Console.Write(" \\");
                }
                Console.Write(new string('.', dotPrinter));
            }
            dotPrinter--;
            if(i%2==0)
            {
                dasthPrinter++;
            }
            Console.WriteLine();
        }

        int oddRow = 1;
        dotPrinter = 0;
        if ((n / 2) % 2 == 0)
        {
            oddRow = 0;
            dasthPrinter--;
        }
        for (int i = 1+oddRow; i <= n / 2 +oddRow; i++)
        {
            if (i % 2 == 0)
            {
                Console.Write(new string('.', dotPrinter));
                for (int j = 1; j <= dasthPrinter; j++)
                {
                    if (j != dasthPrinter)
                    {
                        Console.Write("\\ ");
                    }
                    else
                    {
                        Console.Write("\\");
                    }
                }
                for (int j = 1; j <= dasthPrinter; j++)
                {
                    if (j != dasthPrinter)
                    {
                        Console.Write("/ ");
                    }
                    else
                    {
                        Console.Write("/");
                    }
                }
                Console.Write(new string('.', dotPrinter));
            }
            if (i % 2 != 0)
            {
                Console.Write(new string('.', dotPrinter));
                for (int j = 1; j <= dasthPrinter; j++)
                {
                    Console.Write("\\ ");
                }

                for (int j = 1; j <= dasthPrinter; j++)
                {
                    Console.Write(" /");
                }
                Console.Write(new string('.', dotPrinter));
            }
            dotPrinter++;
            if (i % 2 == 0)
            {
                dasthPrinter--;
            }
            Console.WriteLine();
        }

    }
}

