using System;

class CalculateAgeAfter10Years
{
    static void Main()
    {
        bool isFormatValid;
        do
        {
            try
            {
                Console.Write("Enter your current age: ");
                int currentAge = int.Parse(Console.ReadLine());
                isFormatValid = true;
                Console.Write("You will be {0} years old after 10 years.", currentAge + 10);
                Console.WriteLine();
            }
            catch (FormatException)
            {
                isFormatValid = false;
                Console.WriteLine("Please enter a valid number!");
            }
        }
        while (isFormatValid==false);

    }
}

