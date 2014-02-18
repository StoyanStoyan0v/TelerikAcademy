namespace RangeValidation
{
    using System;
    using System.Globalization;
    using System.Linq;
    
    class Tests
    {
        static void Main(string[] args)
        {
            ExecuteNumbersTest();
            ExecuteDataTest();
        }

        private static void ExecuteNumbersTest()
        {
            InvalidRangeException<int> numbersExc = new InvalidRangeException<int>("Enter number between 0 and 1000!", 0, 1000);

            Console.WriteLine("Enter number or enter \"Exit\" to exit!\n");

            string number = Console.ReadLine();
            while (number != "Exit")
            {
                try
                {
                    if (int.Parse(number) < numbersExc.Start || int.Parse(number) > numbersExc.End)
                    {
                        try
                        {
                            throw numbersExc;
                        }
                        catch (InvalidRangeException<int> e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Correct number: " + int.Parse(number));
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("You did not enter a number! Try again:");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The entered value is either too big or too small for the date type! Try again:");
                }
                number = Console.ReadLine();
            }
            Console.WriteLine();
        }

        private static void ExecuteDataTest()
        {
            string dateFormat = "dd.MM.yyyy";
            CultureInfo culture = CultureInfo.InvariantCulture;

            InvalidRangeException<DateTime> dateExc = new InvalidRangeException<DateTime>("Enter date between 01.01.2012 and 31.12.2013",
                DateTime.ParseExact("01.01.2012", dateFormat, culture), DateTime.ParseExact("31.12.2013", dateFormat, culture));

            Console.WriteLine("Enter date (dd.mm.yyyy) or enter \"Exit\" to exit!\n");

            string date = Console.ReadLine();
            while (date != "Exit")
            {
                try
                {
                    DateTime someDate = DateTime.ParseExact(date, dateFormat, CultureInfo.InvariantCulture);
                    if (someDate < dateExc.Start ||
                        someDate > dateExc.End)
                    {
                        try
                        {
                            throw dateExc;
                        }
                        catch (InvalidRangeException<DateTime> e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Correct date: " + DateTime.ParseExact(date, dateFormat, CultureInfo.InvariantCulture));
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("You did not enter a date! Try again:");
                }
                
                date = Console.ReadLine();
            }
        }
    }
}