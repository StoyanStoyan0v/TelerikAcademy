using System;
using System.Text;
using System.IO;

class ConcatenateTextFiles
{
 
    static string ReadFile(string filePath) //Method reading a file.
    {
        StreamReader reader = new StreamReader(filePath);
        string fileContent = null;
        using (reader)
        {
            fileContent = reader.ReadToEnd();
        }
        return fileContent;
    }

    static void WriteToFile(string content, string filePath) //Method writing to a file.
    {
        StreamWriter writer = new StreamWriter(filePath,true);
        using (writer)
        {
            writer.WriteLine(content);
        }
    }

    static void Main()
    {
        Console.Write("Enter the path to the first file to be copied: ");
        string firstFilePath = Console.ReadLine();
        Console.Write("Enter the path to the second file to be copied: ");
        string secondFilePath = Console.ReadLine();
        Console.Write("Enter the path where the final file must be created: ");
        string endFilePath = Console.ReadLine();

        string firstFileContent = ReadFile(firstFilePath);
        string secondFileContent = ReadFile(secondFilePath);
        WriteToFile(firstFileContent, endFilePath);
        WriteToFile(secondFileContent, endFilePath);
        Console.WriteLine("The files are copied into the new file!");

    }
}

