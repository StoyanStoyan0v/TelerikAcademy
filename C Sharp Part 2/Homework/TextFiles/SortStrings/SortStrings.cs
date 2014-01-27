using System;
using System.IO;
using System.Text;

class SortStrings
{
    static string ReadFromFile(string filePath) //Get the words from a file.
    {
        StreamReader reader = new StreamReader(filePath);
        using (reader)
        {
            return reader.ReadToEnd();
        }
    }

    static void WriteArrayToFile(string[] words, string filePath) //Print the words to a file(sorted in this case).
    {
        StreamWriter write = new StreamWriter(filePath, true);
        using (write)
        {
            int index = 0;
            while (index<words.Length)
            {
                write.WriteLine(words[index]);
                index++;
            }
        }
    }

    static void Main(string[] args)
    {
        Console.Write("Enter the path to the file to be read from: ");
        string readFilePath = Console.ReadLine();
        Console.Write("Enter the path to the file to write to: ");
        string writeFilePath = Console.ReadLine();
        string fileContent = ReadFromFile(readFilePath);
        string[] words = fileContent.Split(new char[] { '\r','\n' }, StringSplitOptions.RemoveEmptyEntries);
        Array.Sort(words);
        WriteArrayToFile(words, writeFilePath);
        Console.WriteLine("The words are sorted in the new file!");

    }
}
