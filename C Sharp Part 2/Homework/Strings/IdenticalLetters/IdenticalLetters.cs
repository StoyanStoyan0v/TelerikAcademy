using System;
using System.Text;

class IdenticalLetters
{
    static string RemoveIdenticalLetters(string text)
    {
        StringBuilder newText = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            if (i == text.Length - 1 || text[i] != text[i + 1])
            {
                newText.Append(text[i]);
            }
        }

        return newText.ToString();
    }

    static void Main()
    {
        string text = Console.ReadLine().ToLower();
        text = RemoveIdenticalLetters(text);
        Console.WriteLine(text);
    }
}
