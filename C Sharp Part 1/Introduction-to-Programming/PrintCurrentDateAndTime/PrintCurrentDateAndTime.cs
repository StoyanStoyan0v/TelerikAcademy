using System;

class PrintCurrentDateAndTime
{
    static void Main(string[] args)
    {
        DateTime dateAndTimeNow= DateTime.Now;
        Console.WriteLine(dateAndTimeNow);
        //or simply
        Console.WriteLine(DateTime.Now);
    }
}

