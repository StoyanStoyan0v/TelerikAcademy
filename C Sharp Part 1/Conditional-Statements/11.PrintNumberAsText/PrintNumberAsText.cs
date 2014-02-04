using System;

class PrintNumberAsText
{
    static void Main()
    {
        ushort parseDigit = 1000; //The variable which will be parsed is outside because it's used by the loop to set the conditions.

        //This loop will make the program asking for a digit if it is outside the scope of 0 to 999.
        while (parseDigit < 0 || parseDigit > 999)
        {
            Console.Write("Enter a number between 0 and 999: ");
            string digit = Console.ReadLine();
            parseDigit=ushort.Parse(digit);           
        }
        Console.Write("Text representation: {0} -> ",parseDigit);
        switch (parseDigit / 100)
        {
            case 1: Console.Write("one hundred and "); break;
            case 2: Console.Write("two hundreds and "); break;
            case 3: Console.Write("three hundreds and "); break;
            case 4: Console.Write("four hundreds and "); break;
            case 5: Console.Write("five hundreds and "); break;
            case 6: Console.Write("six hundreds and "); break;
            case 7: Console.Write("seven hundreds and "); break;
            case 8: Console.Write("eight hundreds and "); break;
            case 9: Console.Write("nine hundreds and "); break;
            default: break;
        }

        switch ((parseDigit / 10) % 10)
        {
            case 0: break;
            case 1:
                {
                    switch (parseDigit % 10)
                    {
                        case 0: Console.Write("ten "); break;
                        case 1: Console.Write("eleven "); break;
                        case 2: Console.Write("twelve "); break;
                        case 3: Console.Write("thirteen "); break;
                        case 4: Console.Write("fourteen "); break;
                        case 5: Console.Write("fifteen "); break;
                        case 6: Console.Write("sixteen "); break;
                        case 7: Console.Write("seventeen "); break;
                        case 8: Console.Write("eighteen "); break;
                        case 9: Console.Write("nineteen "); break;
                    }
                }
                break;
            case 2: Console.Write("twenty "); break;
            case 3: Console.Write("thirty "); break;
            case 4: Console.Write("fourty "); break;
            case 5: Console.Write("fifty "); break;
            case 6: Console.Write("sixty "); break;
            case 7: Console.Write("seventy "); break;
            case 8: Console.Write("eighty "); break;
            case 9: Console.Write("ninty "); break;
            default: break;
        }
        if (parseDigit / 10 % 10 != 1)
        {
            switch (parseDigit % 10)
            {
                case 0:
                    if (parseDigit == 0)
                    {
                        Console.Write("Zero.");
                    }
                    break;
                case 1: Console.Write("one"); break;
                case 2: Console.Write("two"); break;
                case 3: Console.Write("three"); break;
                case 4: Console.Write("four"); break;
                case 5: Console.Write("five"); break;
                case 6: Console.Write("six"); break;
                case 7: Console.Write("seven"); break;
                case 8: Console.Write("eight"); break;
                case 9: Console.Write("nine"); break;
            }
        }
        Console.WriteLine();
    }
}

