using System;

class WeekdayToday
{
    static void DayOfWeek(string date)
    {
        //Split the date into day, month and year.
        string[] dayMonthYear = date.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
        int day = int.Parse(dayMonthYear[0]);
        int month = int.Parse(dayMonthYear[1]);
        int year = int.Parse(dayMonthYear[2]);

        //Get the date and its day in the week.
        DateTime yourDate = new DateTime(year,month,day);
        DayOfWeek weekDay = yourDate.DayOfWeek;
        Console.WriteLine("{0} is {1}",yourDate,weekDay);
    }

    static void Main()
    {
        Console.Write("Enter a date(use dd.MM.YYYY format): ");
        string date = Console.ReadLine();
        DayOfWeek(date);
    }
}

