using System;

class LastDigitName
{
    static string LastDigit(int number)
    {
        string digit=null;
        switch (number%10)
        {
            case 0: digit ="zero";break; 
            case 1: digit = "one"; break;
            case 2: digit = "two"; break; 
            case 3: digit= "three"; break; 
            case 4: digit= "four";break; 
            case 5: digit= "five"; break; 
            case 6: digit ="six"; break; 
            case 7: digit ="seven"; break; 
            case 8: digit ="eight"; break; 
            case 9: digit ="nine";break; 
            default: break;
        }
        return digit;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        string digit = LastDigit(number);
        Console.WriteLine("The last digit of number {0} is {1}.",number,digit);
    }
}

