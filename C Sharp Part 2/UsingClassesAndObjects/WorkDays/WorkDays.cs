using System;

class WorkDays
{
    //Keep all the holidays in global variable.
    static string[] holidays = {"1/1","3/3","5/1","5/6","5/24/","9/6","9/22","12/24","12/25","12/26"};
    static DateTime ConvertToDate()
    {
        //Convert string into a valid date.

        Console.Write("Enter a date (use dd.MM.YYYY format): ");
        string date = Console.ReadLine();
        string[] dayMonthYear = date.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
        int day = int.Parse(dayMonthYear[0]);
        int month = int.Parse(dayMonthYear[1]);
        int year = int.Parse(dayMonthYear[2]);
        DateTime someDate = new DateTime(year, month, day);
        return someDate;
    }

    static bool CheckDay(string day)
    {
        //Check whether the day is working or holiday.
        bool isHoliday = false;
        for (int i = 0; i < holidays.Length; i++)
        {
            if(day==holidays[i])
            {
                isHoliday = true;
                break;
            }
        }

        return isHoliday;
    }

    static int WorkingDays(DateTime now,DateTime futureDate)
    {
        //Get all the dates from now to the date pointed.
        TimeSpan days = futureDate - now;
        int daysNumber = (int)days.TotalDays;
        int totalDays = daysNumber;

        //Start adding days to the current and check it.
        for (int i = 1; i <= totalDays; i++)
        {
            DateTime currentDate = now.AddDays(i);
            string weekDay = currentDate.DayOfWeek.ToString();

            //Check if it is a day of the weekend.
            if (weekDay == "Saturday" || weekDay == "Sunday")
            {
                daysNumber--;
                continue;
            }

            //Make the date into a string and check for it in the array with the holidays.
            string day = currentDate.Month + "/" + currentDate.Day;
            bool isHoliday = CheckDay(day);

            if (isHoliday)
            {
                daysNumber--; //If the date is holiday, reduce the total days.
            }
        }

        return daysNumber;
    }

    static void Main()
    {
        DateTime now = DateTime.Now;
        DateTime futureDate = ConvertToDate();

        int workingDays = WorkingDays(now, futureDate);
        Console.WriteLine("From {0} to {1}, there are {2} working days.",now,futureDate,workingDays);

    }   
}

