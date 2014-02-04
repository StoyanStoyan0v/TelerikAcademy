using System;

class Eggcelent
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int innerDots = n + 1;
        int outerDots = n-1;

        Console.WriteLine(new string('.', n + 1) + new string('*', n - 1) + new string('.', n + 1));
        for (int i = 1; i < n/2+1; i++)
        {
            Console.WriteLine(new string('.', outerDots)+ "*" + new string('.',innerDots)+"*" + new string ('.',outerDots));
            outerDots -= 2;
            innerDots += 4;
        }
        outerDots += 2;
        innerDots -= 4;

        for (int i = 1; i < n-1; i++)
        {
            Console.Write(".*");
            if (i == n / 2-1 || i == n / 2 )
            {
                for (int j = 1; j <= innerDots; j++)
                {
                    if ((n / 2 - 1) % 2 != 0)
                    {
                        if (i % 2 != 0)
                        {
                            if (j % 2 != 0)
                            {
                                Console.Write("@");
                            }
                            else
                            {
                                Console.Write(".");
                            }
                        }
                        else
                        {
                            if (j % 2 == 0)
                            {
                                Console.Write("@");
                            }
                            else
                            {
                                Console.Write(".");
                            }
                        }
                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            if (j % 2 != 0)
                            {
                                Console.Write("@");
                            }
                            else
                            {
                                Console.Write(".");
                            }
                        }
                        else
                        {
                            if (j % 2 == 0)
                            {
                                Console.Write("@");
                            }
                            else
                            {
                                Console.Write(".");
                            }
                        }
                    }
                }
            }
            else
            {
                Console.Write(new string('.',innerDots));
            }
            Console.Write("*.");
            Console.WriteLine();
        }
        for (int i = 1; i < n/2 + 1; i++)
        {
            Console.WriteLine(new string('.', outerDots) + "*" + new string('.', innerDots) + "*" + new string('.', outerDots));
            outerDots += 2;
            innerDots -= 4;
        }



        Console.WriteLine(new string('.', n + 1) + new string('*', n - 1) + new string('.', n + 1));
    }
}

