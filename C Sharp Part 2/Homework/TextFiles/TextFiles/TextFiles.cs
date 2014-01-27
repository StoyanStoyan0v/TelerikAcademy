using System;
using System.Text;
using System.IO;

class TextFiles
{
    static void PrintOddLines(string filePath)
    {
        StreamReader reader = new StreamReader(filePath);
        using (reader)
        {
            int lineNumber = 0;
            string line = reader.ReadLine();
            Console.WriteLine("All odd lines: ");
            while (line!=null)
            {
                lineNumber++;
                if(lineNumber%2==1)
                {
                    Console.WriteLine("Line {0}: {1}",lineNumber,line);
                }
                line = reader.ReadLine();
            }
        }
    }

    static void Main()
    {
        string filePath = Console.ReadLine(); //Example: text.txt (only)
        PrintOddLines(filePath);

    }
}

