using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KukataIsDancing
{
    class Program
    {
        static char[,] array = { { 'R', 'B', 'R' }, { 'B', 'G', 'B' }, { 'R', 'B', 'R' } };
        
        static void Main(string[] args)
        {
            char result = array[1, 1];
            int n = int.Parse(Console.ReadLine());
            List<string> output = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string lines = Console.ReadLine();
                result =GetResult(lines,1,1);
                switch (result)
                {
                    case 'R': output.Add("RED"); break;
                    case 'B': output.Add("BLUE"); break;
                    case 'G': output.Add("GREEN"); break;
                }
            }

            foreach (string line in output)
            {
                Console.WriteLine(line);
            }

        }

        static char GetResult(string line, int start, int end)
        {
            char lastDirection = 'u';
            char result = array[start, end];
            for (int i = 0; i < line.Length; i++)
            {
                StringBuilder direction = new StringBuilder();
                while (i!=line.Length && line[i]!='W')
                {
                    direction.Append(line[i]);
                    i++;
                }

                if(i==line.Length)
                {
                    break;
                }
                if(direction.Length==0)
                {
                    result = Move(ref start, ref end, lastDirection, result);
                } 
                else
                {
                    for (int j = 0; j < direction.Length; j++)
                    {
                        if(direction[j]=='L')
                        {
                            switch (lastDirection)
                            {
                                case 'u': lastDirection = 'l'; break;
                                case 'l': lastDirection='d'; break;
                                case 'r':lastDirection='u'; break;
                                case 'd':lastDirection='r'; break;
                            }
                        }
                        else
                        {
                            switch (lastDirection)
                            {
                                case 'u': lastDirection = 'r'; break;
                                case 'l': lastDirection = 'u'; break;
                                case 'r': lastDirection = 'd'; break;
                                case 'd': lastDirection = 'l'; break;
                            }
                        }
                    }
                    result = Move(ref start, ref end, lastDirection, result);
                    direction.Clear();
                }
            }
            return result;
        }

        static char Move(ref int start, ref int end, char lastDirection, char result)
        {
            switch (lastDirection)
            {
                case 'u': try
                    {
                        result = array[start - 1, end];
                        start--;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        result = array[2, end];
                        start = 2;
                    }; break;
                case 'l':
                    try
                    {
                        result = array[start, end - 1];
                        end--;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        result = array[start, 2];
                        end = 2;
                    }; break;
                case 'r':
                    try
                    {
                        result = array[start, end + 1];
                        end++;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        result = array[start, 0];
                        end = 0;
                    }; break;
                case 'd':
                    try
                    {
                        result = array[start + 1, end];
                        start++;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        result = array[0, end];
                        start = 0;
                    }; break;
            }
            return result;
        }
    }
}
