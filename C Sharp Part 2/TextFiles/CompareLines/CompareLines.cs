using System;
using System.Text;
using System.IO;
   
class CompareLines
{
    static void GetLines(string firstFilePath,string secondFilePath)
    {
        StreamReader reader = new StreamReader(firstFilePath);
        StreamReader secondReader = new StreamReader(secondFilePath);
        int sameLines = 0;
        int differentLines = 0;

        using (reader)
        {
            using(secondReader)
            {
                //Read a line from both files and compare them.
                string line = reader.ReadLine();
                string secondLine = secondReader.ReadLine();
                while (line!=null)
                {
                    if(line==secondLine)
                    {
                        sameLines++;
                    }
                    else
                    {
                        differentLines++;
                    }
                    line = reader.ReadLine();
                    secondLine = secondReader.ReadLine();
                }
            }
        }

        Console.WriteLine("Same lines: " + sameLines);
        Console.WriteLine("Different lines: " + differentLines);

    }

    static void Main()
    {
        string firstPath = Console.ReadLine();
        string secondPath = Console.ReadLine();

        GetLines(firstPath, secondPath);
    }
}

