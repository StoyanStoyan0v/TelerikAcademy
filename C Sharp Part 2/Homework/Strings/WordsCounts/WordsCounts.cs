using System;
using System.Text;

class WordsCounts
{
    static void GetWordsCount(string text)
    {
        string[] words = text.Split(new char[] { ' ', ',', '-', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

        Array.Sort(words);

        int counter = 1;
        for (int i = 0; i < words.Length; i++)
        {           
            if (i!=words.Length-1 && words[i] == words[i + 1])
            {
                counter++;
            }
            else
            {
                
                Console.WriteLine("{0} - {1}", words[i], counter);
                counter = 1;
            }
        }
    }

    static void Main()
    {
        string text = Console.ReadLine().ToLower();
        GetWordsCount(text);
    }  
}

