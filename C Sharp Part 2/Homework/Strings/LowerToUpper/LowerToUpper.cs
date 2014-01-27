using System;
using System.Text.RegularExpressions;

class LowerToUpper
{
    static string ModifyText(string text)
    {
        int startIndex = text.IndexOf("<upcase>");
        int endIndex = text.IndexOf("</upcase>");
        while (startIndex!=-1)
        {
            string subToUpper = text.Substring(startIndex+8,endIndex-(startIndex+8)).ToUpper();
            string sub = text.Substring(startIndex, endIndex-startIndex+9);
            text = text.Replace(sub,subToUpper);
            startIndex = text.IndexOf("<upcase>");
            endIndex = text.IndexOf("</upcase>");
        }
        return text;
    }

    static void Main()
    {
        string text = Console.ReadLine();
        text = ModifyText(text);
        Console.WriteLine(text);
    }
}

