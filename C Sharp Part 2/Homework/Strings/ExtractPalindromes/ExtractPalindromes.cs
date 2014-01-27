using System;
using System.Text;

class Palindromes
{
    static void ExtractPalindromes(string []words)
    {
        for (int i = 0; i < words.Length; i++)
        {
            StringBuilder left = new StringBuilder();
            StringBuilder right = new StringBuilder();

            for (int l = 0; l < words[i].Length/2; l++)
            {
                left.Append(words[i][l]);
            }

            for (int r =words[i].Length-1; r > words[i].Length/2; r--)
            {
                right.Append(words[i][r]);
            }
            
            if(left.ToString()==right.ToString())
            {
                Console.WriteLine(words[i]);
            }
        }
    }

    static void Main()
    {
        Console.WriteLine("Enter some text: ");
        string input = Console.ReadLine();
        string[] words = input.Split(new char[]{' ',',','.','?','-','!'},StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine("Palindromes: ");
        ExtractPalindromes(words);
    }
}