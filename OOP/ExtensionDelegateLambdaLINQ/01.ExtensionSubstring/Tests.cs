using System;
using System.Text;
using ExtensionSubstring;

internal static class Tests
{
    /*Implement an extension method Substring(int index, int length) for the class StringBuilder that returns 
     *new StringBuilder and has the same functionality as Substring in the class String.*/

    static void Main()
    {
        StringBuilder sentence = new StringBuilder("It rains cats and dogs!");
        Console.WriteLine(sentence.Substring(9, 3));
        Console.WriteLine(sentence.Substring(18, 3));
    }
}

