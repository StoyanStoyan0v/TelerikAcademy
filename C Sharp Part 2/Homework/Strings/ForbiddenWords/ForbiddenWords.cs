using System;

class ForbiddenWords
{
    static string CensoredText(string text, string[] words)
    {
        for (int i = 0; i < words.Length; i++)
        {
            text=text.Replace(words[i], new string('*', words[i].Length));
        }
        return text;

    }

    static void Main()
    {
        Console.WriteLine("Enter uncensored text: ");
        string text = Console.ReadLine();
        string words = Console.ReadLine();
        string []arrayOfWords = words.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        text = CensoredText(text, arrayOfWords);
        Console.WriteLine("Censored text: ");
        Console.WriteLine(text);
    }
}

