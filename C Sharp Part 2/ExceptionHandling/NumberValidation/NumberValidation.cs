using System;

class NumberValidation
{
    static void ValidateNumber()
    {
        try
        {
            Console.Write("Enter a number: ");
            uint number = uint.Parse(Console.ReadLine());
            Console.WriteLine("Number: "+number);
        }
        catch(FormatException) //If unparsable string occurs.
        {
            Console.WriteLine("Invalid number.");
        }
        catch(OverflowException) //If the number is  either too small or too large for the parsing type.
        {
            Console.WriteLine("Invalid number.");
        }
        finally
        {
            Console.WriteLine("Goodbye!");
        }
    }

    static void Main()
    {
        ValidateNumber();
    }
}

