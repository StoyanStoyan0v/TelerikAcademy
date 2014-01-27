using System;
using System.IO;
using System.Text;


class DeleteOddLines
{
    static void DeleteLines(string filePath)
    {
        StreamReader reader = new StreamReader(filePath);
        StreamWriter writer = new StreamWriter("temp.txt");
        using (reader)
        {
            using (writer)
            {
                int lineNumber = 0;
                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    lineNumber++;
                    if (lineNumber % 2 == 1)
                    {
                        writer.WriteLine();
                    }
                    else
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }

        File.Delete(filePath);
        File.Move("temp.txt", filePath);
    }

    static void Main()
    {
        Console.Write("Enter the path to the file to be changed: ");
        string readFilePath = Console.ReadLine();
        DeleteLines(readFilePath);
        Console.WriteLine("The file has been changed!");
    }
}

