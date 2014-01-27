using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

class ExtractAndSort
{
    //Keep the words and their matching countes in a dictionary.
    static Dictionary<string, int> words = new Dictionary<string, int>();

    static void ExtractWordsCount(string filePath, string wordsFilePath)
    {        
        try
        {
            string[] wordsFromFile = File.ReadAllLines(wordsFilePath);
            string wordsForChecking = @"\b(" + string.Join("|", wordsFromFile) + @")\b";                       

            StreamReader reader = new StreamReader(filePath);   
            using (reader)
            {
                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    //Keep all the words to look for in a variable.
                    Regex regex = new Regex(wordsForChecking, RegexOptions.IgnoreCase);

                    //Start searching the lines for each of the words until there are no more chars.
                    Match match = regex.Match(line);
                    while (match.Success)
                    {
                        if (match.Value != "")
                        {
                            //If word is found try to search it in the dictionary (key) and increase the counter value.
                            try
                            {
                                words[match.Value]++;
                            }
                            catch (KeyNotFoundException) //If the word(key) is not found, put it in the dictionary with count of 1.
                            {

                                words[match.Value] = 1;
                            }
                        }
                        
                        match = match.NextMatch(); //Check the next match.
                    }
                                                       
                }
            }

        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static void WriteWordsToFile(string filePath)
    {
        try
        {
            StreamWriter writer = new StreamWriter(filePath);
            using (writer)
            {
                writer.WriteLine("Words found in the file in descending order: ");

                //Sort the words in descending order. LINQ query is used (see using libraries above).
                //Print the words line by line.
                foreach (KeyValuePair<string, int> item in words.OrderByDescending(key => key.Value))
                {
                    string line = item.Key + "-" + item.Value + " times";
                    writer.WriteLine(line);
                }
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (PathTooLongException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        
    }

    static void Main()
    {
        Console.Write("Enter the path to the file to be read: ");
        string readFilePath = Console.ReadLine();
        Console.Write("Enter the path to the file with words: ");
        string wordsFilePath = Console.ReadLine();
        Console.Write("Enter path to file to write the sorted words: ");
        string outputFilePath = Console.ReadLine();
        ExtractWordsCount(readFilePath, wordsFilePath);
        WriteWordsToFile( outputFilePath);
        Console.WriteLine("Result has been written to the file.");
    }
}

