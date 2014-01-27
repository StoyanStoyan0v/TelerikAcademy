using System;
using System.IO;
using System.Text;
class ReadFile
{
    static void PrintFileContents()
    {
        Console.Write("Enter file's directory: ");
        string filePath = Console.ReadLine();
        try
        {
            string contents = File.ReadAllText(filePath); //Read file.
            Console.WriteLine(contents); 
        }
        catch(ArgumentException)
        {
            Console.WriteLine("The path of the file is zero length, contains only white space or contains invalid characters.");
        }
        catch(PathTooLongException)
        {
            Console.WriteLine("The path is too long.");
        }
        catch(DirectoryNotFoundException)
        {
            Console.WriteLine("The file cannot be located.");
        }
        catch(FileNotFoundException)
        {
            Console.WriteLine("File is not found.");
        }
        catch(NotSupportedException)
        {
            Console.WriteLine("Path is in invalid format!");
        }
        catch(IOException)
        {
            Console.WriteLine("The file is being used by another process.");
        }
        catch(UnauthorizedAccessException)
        {
            Console.WriteLine("Acces to the directory or the file is restricted.");
        }
    }


    static void Main()
    {
        PrintFileContents();
    }
}

