using System;
using System.Text.RegularExpressions;

class ExtractEMails
{
    static void ExtractAddresses(string text)
    {
        Console.WriteLine("E-mail adresses: ");

        MatchCollection matches = Regex.Matches(text, @"[\w.]{2,20}@[\w]{2,20}[.]{1}[\w.]{2,6}");
        foreach (var match in matches)
        {
            Console.WriteLine(match.ToString());
        }
    }

    static void Main()
    {
        string text = Console.ReadLine();
        ExtractAddresses(text);
    }
}

