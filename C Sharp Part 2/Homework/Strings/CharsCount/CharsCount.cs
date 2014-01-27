using System;
using System.Text;

class CharsCount
{
    static void PrintCounts(string text)
    {
        int[] counts = new int['z' - 'a' + 1];
        for (int i = 0; i < text.Length; i++)
        {

            if (text[i] >= 'a' && text[i] <= 'z')
            {
                counts[text[i] - 'a']++;
            }
        }

        for (int i = 0; i < counts.Length; i++)
        {
            if (counts[i] != 0)
            {
                Console.WriteLine("{0} - {1} times", (char)(i + 'a'), counts[i]);
            }
        }
    }

    static void Main()
    {
        string text = Console.ReadLine().ToLower();        
        PrintCounts(text);
    }
}

