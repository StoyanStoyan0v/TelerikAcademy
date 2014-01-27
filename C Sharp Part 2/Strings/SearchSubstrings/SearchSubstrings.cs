using System;
using System.Text;

class SearchSubstrings
{
    static int GetCount(string text, string substring)
    {
        string lowerText = text.ToLower();
        string lowerSubstring = substring.ToLower();
        int counter = 0;
        int index = lowerText.IndexOf(substring, 0, StringComparison.OrdinalIgnoreCase);       
        while (index!=-1)
	    {
	         counter++;
             index = lowerText.IndexOf(substring, index + 1);
	    }
        return counter;
    }

    static void Main()
    {
        string text = Console.ReadLine();
        string substring = Console.ReadLine();
        int count = GetCount(text, substring);
        Console.WriteLine(count);
    }
}

