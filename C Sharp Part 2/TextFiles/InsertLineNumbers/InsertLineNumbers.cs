using System;
using System.Text;
using System.IO;

class InsertLineNumbers
{
    static void CopyFileLines(string filePath,string endPath)
    {
        StreamReader reader = new StreamReader(filePath);
        using (reader)
        {
            int lineNumber = 0;
            string line = reader.ReadLine();
            while (line!=null)
            {
                lineNumber++;
                WriteToFile(lineNumber+" " + line,endPath);
                line = reader.ReadLine();
            }
        }
    }

    static void WriteToFile(string content, string filePath)
    {
        StreamWriter writer = new StreamWriter(filePath, true);
        using (writer)
        {
            writer.WriteLine(content);
        }
    }

    static void Main(string[] args)
    {
        Console.Write("Enter the path to be read: ");
        string filePath = Console.ReadLine();
        Console.Write("Enter the path where the final file must be created: ");
        string endFilePath = Console.ReadLine();
        CopyFileLines(filePath, endFilePath);
        Console.WriteLine("Content copied!");
    }
}

