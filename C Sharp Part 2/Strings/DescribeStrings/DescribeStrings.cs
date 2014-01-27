using System;
using System.IO;
using System.Text;

class DescribeStrings
{
    static void Main()
    {
        string content = File.ReadAllText("description.txt");
        Console.WriteLine(content);
    }
}

