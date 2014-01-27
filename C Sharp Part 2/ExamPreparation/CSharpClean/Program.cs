using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpClean
{
    class Program
    {
        static StringBuilder output = new StringBuilder();
        static bool isComment = false;
        static bool isString = false;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                if (line.Contains('{'))
                {
                    CleanRow(line);
                }
            }
        }

        private static void CleanRow(string line)
        {
            StringBuilder currentLine = new StringBuilder();

            if(line.Contains("*/"))
            {
                isComment = false;
            }

            if (!isComment)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if(isString && line.Contains("*/"))
                    {
                        if (i < line.Length - 2)
                        {
                            i = line.IndexOf("*/") + 2;
                        }
                    }
                    currentLine.Append(line[i]);
                    if (line[i] == ';')
                    {
                        output.Append(currentLine.ToString());
                    }
                    else if (line[i] == '{')
                    {
                        currentLine.Append(line[i]);
                    }
                    else if (i != line.Length - 1 && !isString  && (currentLine[i] + currentLine[i + 1]).ToString() == "/*")
                    {
                        isComment = true;
                        output.Append(currentLine.ToString().Substring(0, i));
                    }
                    else if (line[i] == '"' && line[i] == '@')
                    {
                        isComment = true;
                    }
                    else if (line[i] == '}')
                    {
                        currentLine.Append(line[i]);
                    }
                    else if ((line[i] + line[i]).ToString() == "//")
                    {
                        isComment = true;
                        continue;
                    }
                    else
                    {
                        currentLine.Append(line[i]);
                    }
                }
            }

            output.AppendLine(currentLine.ToString());
        }
    }
}
