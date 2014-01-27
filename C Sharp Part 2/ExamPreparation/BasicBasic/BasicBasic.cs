using System;
using System.Collections.Generic;
using System.Text;

class BasicBasic
{
    static int x = 0, v = 0, w = 0, y = 0, z = 0;
    static List<string> lines = new List<string>();
    static StringBuilder output = new StringBuilder();

    static void FilList()
    {
        
        string line = Console.ReadLine();
        while (line!="RUN")
        {
            lines.Add(line.Trim());
            line = Console.ReadLine();
            if(line.Contains("RUN"))
            {

                lines.Add(line.Trim());
            }           
        }
        
    }

    static int CheckVariable(string word)
    {
        switch (word.Trim())
        {
            case "X": return x;
            case "V": return v;
            case "Y": return y;
            case "W": return w;
            case "Z": return z;
            default: return int.Parse(word);
        }
    }

    static bool CheckExpression(string expression)
    {
        string[] operandsAndOperator = expression.Split(new char[] { '=','<','>' }, StringSplitOptions.RemoveEmptyEntries);
        int firstOperand = CheckVariable(operandsAndOperator[0].Trim());
        int secondOperand = CheckVariable(operandsAndOperator[1].Trim());

        if(expression.Contains("="))
        {
            return firstOperand == secondOperand;
        }
        else if(expression.Contains("<"))
        {
            return firstOperand < secondOperand;
        }
        else
        {
            return firstOperand > secondOperand;
        }

    }

    static void ChangeValues(string expression)
    {
        string[] operandsAndOperator = expression.Split(new char[] { '=', '+' }, StringSplitOptions.RemoveEmptyEntries);

        if (operandsAndOperator.Length == 2)
        {
            if ((operandsAndOperator[1].Contains("−") && operandsAndOperator[1].IndexOf('−') != 0) || (operandsAndOperator[1].Contains("-") && operandsAndOperator[1].IndexOf('-') != 0))
            {
                string[] split = operandsAndOperator[1].Split(new char[] { '−','-' }, StringSplitOptions.RemoveEmptyEntries);
                int firstOperand = CheckVariable(split[0].Trim());
                int secondOperand = CheckVariable(split[1].Trim());
                if (operandsAndOperator[0].Trim() == "X")
                {
                    x = firstOperand - secondOperand;
                }
                else if (operandsAndOperator[0].Trim() == "V")
                {
                    v = firstOperand - secondOperand;
                }
                else if (operandsAndOperator[0].Trim() == "Y")
                {
                    y = firstOperand - secondOperand;
                }
                else if (operandsAndOperator[0].Trim() == "W")
                {
                    w = firstOperand - secondOperand;
                }
                else if (operandsAndOperator[0].Trim() == "Z")
                {
                    z = firstOperand - secondOperand;
                }
            }
            else
            {
                int operand = CheckVariable(operandsAndOperator[1].Trim());
                if (operandsAndOperator[0].Trim() == "X")
                {
                    x = operand;
                }
                else if (operandsAndOperator[0].Trim() == "V")
                {
                    v = operand;
                }
                else if (operandsAndOperator[0].Trim() == "Y")
                {
                    y = operand;
                }
                else if (operandsAndOperator[0].Trim() == "W")
                {
                    w = operand;
                }
                else if (operandsAndOperator[0].Trim() == "Z")
                {
                    z = operand;
                }
            }
        }
        else 
        {            
            int firstOperand = CheckVariable(operandsAndOperator[1].Trim());
            int secondOperand = CheckVariable(operandsAndOperator[2].Trim());
                        
            if (operandsAndOperator[0].Trim() == "X")
            {
                x = firstOperand + secondOperand;
            }
            else if (operandsAndOperator[0].Trim() == "V")
            {
                v = firstOperand + secondOperand;
            }
            else if (operandsAndOperator[0].Trim() == "Y")
            {
                y = firstOperand + secondOperand;
            }
            else if (operandsAndOperator[0].Trim() == "W")
            {
                w = firstOperand + secondOperand;
            }
            else if (operandsAndOperator[0].Trim() == "Z")
            {
                z = firstOperand + secondOperand;
            }
            
        }       
    }

    static void Main()
    {
        FilList();
        bool isGoTo = false;
        int nextId = 0;
        int position = 0;
        while (isGoTo || (!lines[position].Contains("STOP") && !lines[position].Contains("RUN")))
        {
            int id = int.Parse(lines[position].Substring(0,lines[position].IndexOf(' ')));

            if(isGoTo && id!=nextId)
            {
                position++;
                continue;
            }
            else if(id==nextId)
            {
                isGoTo = false;
                if(lines[position].Contains("STOP"))
                {
                    break;
                }
            }
            
            if (lines[position].Contains("PRINT"))
            {               
                output.AppendLine(CheckVariable(lines[position][lines[position].Length - 1].ToString()).ToString());
            }
            else if (lines[position].Contains("IF"))
            {
                int start = lines[position].IndexOf("IF")+2;
                int end = lines[position].IndexOf("THEN");
                if (CheckExpression(lines[position].Substring(start, end - start).Trim()))
                {
                    if(lines[position].Contains("GOTO"))
                    {
                        string[] lineAsArray = lines[position].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        nextId = int.Parse(lineAsArray[lineAsArray.Length - 1]);
                        isGoTo = true;
                        position = -1;
                       
                    }
                    else if(lines[position].Contains("PRINT"))
                    {
                        output.Append(CheckVariable(lines[position][lines[position].Length - 1].ToString())+" ");
                    }
                    else
                    {
                        int index = lines[position].IndexOf("THEN")+4;
                        string expression = lines[position].Substring(index);
                        ChangeValues(expression);
                    }
                }           
            }
            else if(lines[position].Contains("CLS"))
            {
                output.Clear();
            }
            else if (lines[position].Contains("GOTO"))
            {
                string[] lineAsArray = lines[position].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                nextId = int.Parse(lineAsArray[lineAsArray.Length - 1]);
                isGoTo = true;
                position = -1;

            }
            else
            {
                int index = lines[position].IndexOf(' ');     
                ChangeValues(lines[position].Substring(index+1));
            }

            position++;
        }
        Console.WriteLine(output.ToString());       
    }    
}

