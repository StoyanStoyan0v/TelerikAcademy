using System;

class URL
{
    static string GetProtocol(string url)
    {
        int index = url.IndexOf('/');
        if(index==-1)
        {
            throw new FormatException("Invalid url!");
        }
        else
        {
            return url.Substring(0,index-1);
        }
    }

    static string GetServer(string url)
    {
        int startIndex = url.IndexOf('/') + 2;
        int endIndex = url.IndexOf('/', startIndex);

        if (endIndex != -1)
        {
            return url.Substring(startIndex, endIndex - startIndex);
        }
        else
        {
            return url.Substring(startIndex);
        }
    }

    static string GetResource(string url)
    {
        int startIndex = url.IndexOf('/', url.IndexOf('/') + 2);

        if (startIndex != -1)
        {
            return url.Substring(startIndex);
        }
        else
        {
            return "Empty resource!";
        }
    }

    static void Main()
    {
        string url = Console.ReadLine();

        try
        {
            Console.WriteLine("Protocol: "+GetProtocol(url));
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        Console.WriteLine("Server: "+GetServer(url));
        Console.WriteLine("Resource: "+GetResource(url));
    }
}

