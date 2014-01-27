using System;
using System.Globalization;
class AddTime
{
    static void Main()
    {
        Console.Write("Enter date: ");
        string date = Console.ReadLine();
        string[] dayMonthYear = date.Split(new char[] { '.', '/' }, StringSplitOptions.RemoveEmptyEntries);
        DateTime validateDate = new DateTime(int.Parse(dayMonthYear[2]), int.Parse(dayMonthYear[1]), int.Parse(dayMonthYear[0]));
        validateDate = validateDate.AddHours(6);
        validateDate = validateDate.AddMinutes(30);       
        Console.Write(validateDate.ToString("dd MMMM yyyy, H:mm:ss"));
        System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
        Console.WriteLine(validateDate.ToString("(dddd)"));
    }
}

