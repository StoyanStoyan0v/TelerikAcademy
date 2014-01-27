using System;
using System.IO;
using System.Text;

class ReplaceOccurances
{
    
    static void ReplaceWords(string filePath)
    {
        StreamReader reader = new StreamReader(filePath);
        StreamWriter writer = new StreamWriter("temp.txt");
        using (reader)
        {
            using (writer)
            {
                for (string line = reader.ReadLine(); line != null; line=reader.ReadLine())
                {
                    //Read a line replace words and write the new line to a file.
                    string newLine = line.Replace("start","finish");
                    writer.WriteLine(newLine);
                }
            }
        }

        //Delete the initial file and move the written file renaming it with the initial file's name.
        //This way it is like the initial file has been changed.
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

