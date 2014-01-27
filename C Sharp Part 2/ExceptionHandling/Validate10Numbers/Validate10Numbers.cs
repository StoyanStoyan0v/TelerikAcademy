using System;

class Validate10Numbers
{
    static void ReadNumber(int start, int end)
    {
        for (int i = 1; i <= 10; i++)
        {
            try
            {
                Console.Write("Enter {0} number:", i);
                byte number = byte.Parse(Console.ReadLine());
                if (number < start || number >= end)
                {
                    Console.WriteLine("Invalid number!");
                }
                else
                {
                    Console.WriteLine("Number: " + number);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid number!");
            }

        }
    }

    static void Main()
    {
        ReadNumber(1, 100);
    }
}

