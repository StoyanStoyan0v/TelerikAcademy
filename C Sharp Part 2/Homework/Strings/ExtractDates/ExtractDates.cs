using System;
using System.Globalization;
using System.Text.RegularExpressions;

class ExtractEMails
{
    static void ExtractAddresses(string text)
    {
        Console.WriteLine("Dates: ");       

        MatchCollection matches = Regex.Matches(text, @"[\w]{2}[.]{1}[\w]{2}[.]{1}[\w]{4}");
        foreach (var match in matches)
        {
            Console.WriteLine(DateTime.ParseExact(match.ToString(),"dd.MM.yyyy",CultureInfo.CurrentCulture));
        }
        

    }

    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
        string text = Console.ReadLine();
        ExtractAddresses(text);
    }
}
