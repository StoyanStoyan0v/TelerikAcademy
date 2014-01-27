using System;

class ReverseDigits
{

    static string ReversedNumber(string number)
    {
        char[] numberAsChars = number.ToCharArray(); //Make array of chars from the number represented as string.
        Array.Reverse(numberAsChars); //Reverse the array.
        number = new string(numberAsChars); //Realocate the string with the reversed array of chars.
        return number;
    }

    static void Main()
    {
        Console.Write("Enter number: ");
        string number = Console.ReadLine();
        number = ReversedNumber(number);
        Console.WriteLine("Reversed number: " + number);
    }
}

