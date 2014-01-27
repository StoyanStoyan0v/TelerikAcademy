using System;
using System.Text;

class Dictionary
{
    static string GetExplanation(string word, string[] descriptions)
    {
        foreach (string description in descriptions)
        {
            if(description.IndexOf(word+" -")==0)
            {
                return description;
            }
        }
        return "There is no such term in the dictionary";
    }

    static void Main()
    {
        string[] descriptions = {".NET – platform for applications from Microsoft",
                                    "CLR – managed execution environment for .NET",
                                "namespace – hierarchical organization of classes",
                                "C++ - object-oriented programming language influenced C#"};
        Console.Write("Enter a term: ");
        string term = Console.ReadLine();
        string description = GetExplanation(term, descriptions);
        Console.WriteLine(description);
    }
}

