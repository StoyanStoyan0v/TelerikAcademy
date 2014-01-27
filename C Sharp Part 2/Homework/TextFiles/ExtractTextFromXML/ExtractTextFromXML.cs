using System;
using System.IO;
using System.Text;

class ExtractTextFromXML
{
    static void ExtractText(string path)
    {
        StreamReader reader = new StreamReader(path);
        using (reader)
        {
            //Read the file char by char.
            for (int i = reader.Read(); i != -1; i=reader.Read())
            {
                //Required words are in between of ">" and "<".So if ">" char is reached, 
                // start keeping the chars until "<" char is reached.
                if(i=='>')
                {
                    string text = string.Empty;

                    i = reader.Read();
                    // -1 means the text is over and a char is not found.
                    while (i!=-1 && i!='<')
                    {
                        text += (char)i;
                        i = reader.Read();
                    }
                    // If the text is not empty, print it on the console trimming the " "y chars.
                    if(!String.IsNullOrWhiteSpace(text)) 
                    {
                        Console.WriteLine(text.Trim());
                    }
                }
            }
        }
    }

    static void Main()
    {
        Console.Write("Enter a path to the file to be read: ");
        string path = Console.ReadLine();
        Console.WriteLine("Text without tags: ");
        ExtractText(path);
    }
}

