using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Crossword
{
    static string[] words;
    static StringBuilder wordsInString = new StringBuilder();

    static void Combinations(string[] array, int index, int n )
    {
        if (index == array.Length)
        {
           CheckWords(array);            
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                array[index] = words[i];
                Combinations(array, index + 1, n);
            }
        }
    }

    static void CheckWords(string []currentWords)
    {
        bool isCorrect = true;
       
        for (int i = 0; i < currentWords.Length; i++)
        {
            StringBuilder word = new StringBuilder();
            for (int j = 0; j < currentWords.Length; j++)
            {
                char c = currentWords[j][i];
                word.Append(c);
            }
            if(!wordsInString.ToString().Contains(word.ToString()))
            {
                isCorrect = false;
                break;
            }
        }
        if(isCorrect)
        {
            PrintArray(currentWords);
        }
    }

    static void PrintArray(string[]arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine(arr[i]);
        }
        Environment.Exit(0);
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        words = new string[n * 2];

        for (int i = 0; i < words.Length; i++)
        {
            words[i] = Console.ReadLine();
            wordsInString.Append(words[i] + " ");
        }

        StringBuilder check = new StringBuilder();
        for (int i = 0; i < wordsInString.Length; i+=n+1)
        {
            check.Append(wordsInString[i]);
        }
        if (check.ToString() == "ABCDEFGHIJKL")
        {
            Console.WriteLine("NO SOLUTION!");
        }
        else
        {

            string[] currentNWords = new string[n];
            Array.Sort(words);

            Combinations(currentNWords, 0, n * 2);

            Console.WriteLine("NO SOLUTION!");
        }
    }
}

