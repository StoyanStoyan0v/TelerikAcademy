using System;
using System.Text;

class ReverseSentence
{
    //Two ways of reversing strings.

    static string Reverse(string sentece) //1st - by reversing an array of chars.
    {
        char[] sentenceAsChars = sentece.ToCharArray();
        Array.Reverse(sentenceAsChars);
        return new string(sentenceAsChars);
    }

    static string SecondReverse(string sentence) //2nd - by using StringBuilder class.
    {
        StringBuilder reversed = new StringBuilder();
        for (int i = sentence.Length-1; i >= 0; i--)
        {
            reversed.Append(sentence[i]);
        }
        return reversed.ToString();
    }

    static void Main()
    {
        string sentence = Console.ReadLine();
       
        string reversedSentence = Reverse(sentence);
        Console.WriteLine("Reversed sentence: "+reversedSentence);

        reversedSentence = SecondReverse(sentence);
        Console.WriteLine("Reversed sentence: "+reversedSentence);

    }
}

