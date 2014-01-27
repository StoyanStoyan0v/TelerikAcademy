using System;
using System.Text;

class FillString
{
    static void PrintLine(string input)
    {
        if(input.Length==20)
        {
            Console.WriteLine(input);
        }
        else if(input.Length>20)
        {
            throw new Exception("Your text must be no more than 20 characters. Enter new line: ");
        }
        else
        {
            StringBuilder extendString = new StringBuilder();
            extendString.Append(input);
            extendString.Append('*', 20 - input.Length);
            Console.WriteLine(extendString.ToString());
        }
    }

    static void Main()
    {
        bool isInputValid = false;
        while (!isInputValid)
        {
            try
            {
                string input = Console.ReadLine();               
                PrintLine(input);
                isInputValid = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }                         
    }
}

