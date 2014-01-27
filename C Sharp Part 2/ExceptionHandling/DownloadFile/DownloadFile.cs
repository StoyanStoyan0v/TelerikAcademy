using System;
using System.Net;

class DownloadFile
{
    static void DownloadSomeFile()
    {
        try
        {
            string url = Console.ReadLine(); //Here is the adress only.(with out the file name.
            string file = Console.ReadLine(); //File name.
            WebClient download = new WebClient(); //Create an instance of the WebClinet class.

            download.DownloadFile(url + file, file); //Use download method of the instance, with the adress parameters.
            Console.WriteLine("The file has been successfully downloaded! ");

        }
        catch (ArgumentException)
        {
            Console.WriteLine("You have entered an invalid address.");
        }
        catch(WebException)
        {
            Console.WriteLine("You have entered an invalid address or file does not exist.");
        }

    }
    static void Main(string[] args)
    {
        DownloadSomeFile();
    }
}

