using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Basic
{
    class BasicLanguage
    {
    

        static void Main()
        {
            StringBuilder input = new StringBuilder();
            string line = Console.ReadLine();
            input.AppendLine(line);
            while (!line.Contains("EXIT;"))
            {
                 line = Console.ReadLine();
                 input.AppendLine(line);
            }

            BasicExecutor code = new BasicExecutor(input);
            code.ExecuteCode();
            code.PrintOutput();

        }   
    }

    class BasicExecutor
    {
        private readonly StringBuilder output;
        private StringBuilder code;

        public BasicExecutor(StringBuilder code)
        {
            output = new StringBuilder();
            this.code=code;
        }

        public void PrintOutput()
        {
            Console.WriteLine(output.ToString());
        }

        private void ExecutePrint(int count, string outputString)
        {          
            if(outputString.Length==0)
            {
                return;
            }
            else
            {
                for (int i = 1; i <= count; i++)
                {
                    output.Append(outputString); 
                }
            }  
        }

        public void ExecuteCode()
        {
            string codeAsString = code.ToString().Trim();
            int totalIterations = 1;
            for (int i = 0; i < codeAsString.Length; i++)
            {
                if(codeAsString[i]=='P')
                {
                    int start = codeAsString.IndexOf('(', i) + 1;
                    int end = codeAsString.IndexOf(')', i);
                    string outputCode = codeAsString.Substring(start, end - start);
                    ExecutePrint(totalIterations, outputCode);
                    i=end;
                    totalIterations=1;

                }
                else if(codeAsString[i]=='F')
                {
                    int start = codeAsString.IndexOf('(', i) + 1;
                    int end = codeAsString.IndexOf(')', i);
                    if(totalIterations==0)
                    {
                        i = end;
                        continue;
                    }
                    string forParams = codeAsString.Substring(start, end - start).Trim();
                    if(forParams.Contains(','))
                    {
                        string[] parameters = forParams.Split(',');
                        int a = int.Parse(parameters[0]);
                        int b = int.Parse(parameters[1]);
                        totalIterations *= (b - a + 1);
                    }
                    else
                    {
                        int a = int.Parse(forParams);
                        totalIterations *= a;
                    }
                    i = end;
                }
                else if (codeAsString[i] == 'E')
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }  
}



