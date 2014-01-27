using System;
using System.IO;
using System.Text.RegularExpressions;


class RemoveWords
{
    static void ReplaceWords(string filePath,string wordsFilePath)
    {
        try
        {
            string[] wordsFromFile = File.ReadAllLines(wordsFilePath); // Take all the words from a file to an array.
            string wordsForChecking = @"\b(" + string.Join("|", wordsFromFile) + @")\b"; //Keep the words to check for. 
            StreamReader reader = new StreamReader(filePath);
            StreamWriter writer = new StreamWriter("temp.txt");
            using (reader)
            {
                using (writer)
                {
                    for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                    {
                        //Remove the words, replacing them with empty strings.
                        string newLine = Regex.Replace(line, wordsForChecking, String.Empty);
                        writer.WriteLine(newLine);
                        
                    }
                }
            }

            File.Delete(filePath);
            File.Move("temp.txt", filePath);
        }
        catch(FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        catch(UnauthorizedAccessException e)
        {
            Console.WriteLine(e.Message);
        }                    
        catch(PathTooLongException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
        } 
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
        catch(ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static void Main()
    {
        Console.Write("Enter the path to the file to be changed: ");
        string readFilePath = Console.ReadLine();
        Console.Write("Enter the path to the file with words: ");
        string wordsFilePath = Console.ReadLine();
        ReplaceWords(readFilePath,wordsFilePath);
        Console.WriteLine("The file has been changed!");
    }
}
