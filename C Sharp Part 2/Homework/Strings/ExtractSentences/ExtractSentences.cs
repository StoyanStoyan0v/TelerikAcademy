using System;
using System.Text;

class ExtractSentences
{
    static void PrintSentences(string text, string word)
    {
        Console.WriteLine("Sentences containing the word \"{0}\": ");
        int startIndex=0;
        int endIndex = text.IndexOf('.');
        while (endIndex!=-1)
        {
            string sentence = text.Substring(startIndex, endIndex-startIndex+1);

            if (sentence.Contains(" " + word + " ")) 
            {
                Console.WriteLine(sentence);
            }

            startIndex = endIndex + 2;
            endIndex = text.IndexOf('.', endIndex + 1);

        }
    }

    static void Main()
    {
        Console.WriteLine("Enter yout text: ");
        string text = Console.ReadLine();
        string word = Console.ReadLine();
        PrintSentences(text, word);
        
    }
}

