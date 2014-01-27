using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleJustification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            StringBuilder input = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Trim().Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);
                input.Append(string.Join(" ",line)+" ");
            }

            StringBuilder output = new StringBuilder();
            StringBuilder currentLine = new StringBuilder();
            int spacesLeft = 0;
            int currenLen = 0;
            int currentSpaces = 0;
            for (int i = 0; i < input.Length; i++)
            {
                currentLine.Append(input[i]);
                if(input[i]==' ')
                {
                    currentSpaces++;
                }
                currenLen++;
                if(currenLen==m)
                {
                    if(input[i+1]!=' ')
                    {
                        currenLen = currentLine.ToString().LastIndexOf(' ');
                        string line = currentLine.ToString().Substring(0,currenLen).Trim();
                        currentLine.Clear();
                        currentLine.Append(line);
                        i -= m - currenLen;
                        
                        if(currentSpaces>1)
                        {
                            spacesLeft = m - currenLen;
                            bool isSpace = false;
                            for (int j = 0; j < currenLen; j++)
                            {
                                if(currentLine[j]==' ' && !isSpace)
                                {
                                    currentLine.Insert(j, ' ');
                                    isSpace = true;
                                    spacesLeft--;
                                    currenLen++;
                                    
                                    if(spacesLeft==0)
                                    {
                                        break;
                                    }
                                        
                                }
                                else if(currentLine[j]!=' ')
                                {
                                    isSpace = false;
                                }
                                if(j==currentLine.Length-1)
                                {
                                    j = -1;
                                }

                            }
                            
                        }
                        output.AppendLine(currentLine.ToString().Trim());
                        currentLine.Clear();
                    }
                    else
                    {
                        output.AppendLine(currentLine.ToString().Trim());
                        currentLine.Clear();
                    }
                    currentSpaces = 0;
                    currenLen = 0;
                    i++;
                }

            }
            if (currentSpaces > 1)
            {
                currenLen = currentLine.ToString().LastIndexOf(' ');
                string damn = currentLine.ToString().Substring(0, currenLen).Trim();
                currentLine.Clear();
                currentLine.Append(damn);
                spacesLeft = m - currenLen;
                bool isValid = false;
                for (int j = 0; j < currenLen; j++)
                {
                    if (currentLine[j] == ' ' && !isValid)
                    {
                        currentLine.Insert(j, ' ');
                        isValid = true;
                        spacesLeft--;
                        currenLen++;

                        if (spacesLeft == 0)
                        {
                            break;
                        }

                    }
                    else if (currentLine[j] != ' ')
                    {
                        isValid = false;
                    }
                    if (j == currentLine.Length - 1)
                    {
                        j = -1;
                    }

                }
            }
            output.Append(currentLine.ToString().Trim());
            Console.WriteLine(output.ToString());

        }
    }
}
