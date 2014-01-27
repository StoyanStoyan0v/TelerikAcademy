using System;
using System.Text.RegularExpressions;

class ReplaceTags
{
    static string Replace(string text)
    {
        text = text.Replace("<a href=\"", "[URL=");
        text = text.Replace("\">", "]");
        text = text.Replace("</a>","[/URL]");
        return text;
    }

    static void Main(string[] args)
    {
        string text = Console.ReadLine();
        Console.WriteLine(Replace(text));
    }
}

