using System;
using System.IO;
using System.Text.RegularExpressions;


class RemoveWithTest
{
    //Logic is the same as exercise 8.
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
                    // \w means there are more chars and * means that they are more than 0.
                    string newLine = Regex.Replace(line, @"\btest\w*\b", String.Empty);
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

