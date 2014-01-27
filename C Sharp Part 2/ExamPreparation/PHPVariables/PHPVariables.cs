using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHPVariables
{

    class PHPVariables
    {
        static SortedSet<string> result = new SortedSet<string>();

        static void ExecuteCode(StringBuilder input)
        {            
            bool isOneLineFound = false;
            bool isMultiComFound = false;

            for (int i = 1; i < input.Length-1; i++)
            {
                if (isOneLineFound  || isMultiComFound) 
                {
                    if (isOneLineFound)
                    {
                        if ((input[i]  == '\n'))
                        {
                            isOneLineFound = false;
                        }
                    }
                    else if(isMultiComFound)
                    {
                        if((input[i]+""+input[i+1])=="*/")
                        {
                            isMultiComFound = false;
                        }
                    }

                }
                else
                {
                    if((input[i-1] != '"' || input[i-1]!='\'') && input[i]=='#' || (input[i]+""+input[i+1])=="//")
                    {
                       isOneLineFound=true;
                    }
                    else if ((input[i - 1] != '"' || input[i - 1] != '\'') && (input[i] +""+ input[i + 1]) == "/*")
                    {
                        isMultiComFound = true;
                    }
                    else if ((input[i] == '$' && input[i - 1] != '\\') || (input[i] == '$' && input[i - 2] == '\\'))
                    {
                        ExtractVariable(input, i + 1);
                    }
                }
            }
        }
        
        private static void ExtractVariable(StringBuilder input, int p)
        {
            StringBuilder var = new StringBuilder();
            while (input[p]=='_' || (input[p]>=48 && input[p]<=57)||(input[p]>=65 && input[p]<=90)||input[p]>=97 && input[p]<=122)
            {
                var.Append(input[p]);
                p++;
            }
            result.Add(var.ToString());
        }

        static void Main()
        {
            StringBuilder input = new StringBuilder();
            string line = Console.ReadLine();
            input.AppendLine(line);
            while (!line.Contains("?>"))
            {               
                line = Console.ReadLine();
                input.AppendLine(line);
            }

            ExecuteCode(input);
            Console.WriteLine(result.Count);
            string[] asd = result.ToArray();
            Array.Sort(asd, StringComparer.Ordinal);
            foreach (var item in asd )
            {
                Console.WriteLine(item);
            }            

        }
    }
}
