using System;
using System.IO;
using System.Text.RegularExpressions;

class ReplaceWholeWords
{
    static void ReplaceWords(string filePath)
    {
        StreamReader reader = new StreamReader(filePath);
        StreamWriter writer = new StreamWriter("temp.txt");
        using (reader)
        {
            using (writer)
            {
                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    //The logic is similar to the previous exercise's.
                    //Here using the regular expresions (see the used libraries above), searching is limited to whole words only.
                    string newLine = Regex.Replace(line,@"\bstart\b", "finish");
                    writer.WriteLine(newLine);
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
        ReplaceWords(readFilePath);
        Console.WriteLine("The file has been changed!");
    }
}

