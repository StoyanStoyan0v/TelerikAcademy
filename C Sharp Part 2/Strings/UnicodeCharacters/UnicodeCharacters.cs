using System;
using System.Text;

class UnicodeCharacters
{
    static string StringInUnicode(string text)
    {
        string template="\\u{0:X4}";
        string unicode = String.Empty;
        foreach (char c in text)
        {
            unicode+=String.Format(template,(int)c);
        }
        return unicode;
    }
    
    static void Main()
    {
        Console.Write("Enter text: ");
        string input = Console.ReadLine();
        string unicode = StringInUnicode(input);
        Console.WriteLine("Text in unicode: "+unicode);
    }
}

