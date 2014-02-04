using System;

class CheckSumOfSubset
{
    static void Main()
    {
        int number1, number2, number3, number4, number5;
        number1 = int.Parse(Console.ReadLine());
        number2 = int.Parse(Console.ReadLine());
        number3 = int.Parse(Console.ReadLine());
        number4 = int.Parse(Console.ReadLine());
        number5 = int.Parse(Console.ReadLine());
        if (number1 + number2 + number3 + number4 + number5 == 0)
        {
            Console.WriteLine("{0}+{1}+{2}+{3}+{4} -> 0", number1, number2, number3, number4, number5);
        }
        else if (number2 + number3 + number4 + number5 == 0)
        {
            Console.WriteLine("{0}+{1}+{2}+{3} -> 0", number2, number3, number4, number5);
        }
        else if (number3 + number4 + number5 == 0)
        {
            Console.WriteLine("{0}+{1}+{2}-> 0", number3, number4, number5);
        }
        else if (number4 + number5 == 0)
        {
            Console.WriteLine("{0}+{1} -> 0", number4, number5);
        }
        else if (number1 + number2 + number3 + number4 == 0)
        {
            Console.WriteLine("{0}+{1}+{2}+{3} -> 0", number1, number2, number3, number4);
        }
        else if(number1 + number2 + number3  == 0)
        {
            Console.WriteLine("{0}+{1}+{2} -> 0", number1, number2, number3);
        }
        else if (number1 + number2 == 0)
        {
            Console.WriteLine("{0}+{1}+{2} -> 0", number1, number2);
        }
        else if ( number2 + number3 + number4  == 0)
        {
            Console.WriteLine("{0}+{1}+{2} -> 0", number2, number3, number4);
        }
        else if (number2 + number3  == 0)
        {
            Console.WriteLine("{0}+{1} -> 0", number2, number3);
        }
        else if (number3 + number4 == 0)
        {
            Console.WriteLine("{0}+{1} -> 0", number3, number4);
        }
        else
        {
            Console.WriteLine("No subsets with sum of 0 was found!");
        }
    }
}

