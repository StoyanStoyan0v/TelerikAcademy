using System;

class Program
{
    static bool CheckBrackets(string str)
    {
        int stack = 0;

        for (int i = 0; i < str.Length && stack >= 0; i++)
        {
            if (str[i] == '(')
            {
                stack++;
            }

            if (str[i] == ')')
            {
                stack--;
            }
        }

        return stack == 0;
    }

    static void Main()
    {
        string line = Console.ReadLine();
        CheckBrackets(line);
        Console.WriteLine(line);
    }
}

