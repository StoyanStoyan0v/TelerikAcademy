using System;
using System.Collections.Generic;

class ArithmeticalExpression
{
    static Queue<string> tokens = new Queue<string>();

    static string GetNummeralToken(string formula, string number, ref int i)
    {
        for (int j = i; j < formula.Length; j++)
        {
            int digit;
            if (int.TryParse(formula[j].ToString(), out digit))
            {
                number += digit;
            }
            else if (formula[j] == '.')
            {
                number += formula[j].ToString();
            }
            else
            {
                if (i != j)
                {
                    i = j - 1;
                }
                break; 
            }
        }
        
        return number;
    }

    static int CheckFunctionLength(string formula, int start)
    {
        int pos = 0;
        int left = 0;
        int right = 0;
        for (int j = start; j < formula.Length; j++)
        {           
            if (formula[j] == '(')
            {
                left++;
            }

            if (formula[j] == ')')
            {
                right++;
            }

            if (right !=0 && left == right)
            {
                pos = j;
                break;
            }
        }
        return pos;
    }

    static void RPNFormula(string formula, int start,int end)
    {
        
        Stack<string> stack = new Stack<string>();
        string number = null;

        for (int i = start; i < end; i++)
        {
            number = GetNummeralToken(formula, number, ref i);
            if (number != null)
            {
                tokens.Enqueue(number);
            }
            number = null;

            if(formula[i]=='(')
            {
                stack.Push(formula[i].ToString());
            }
            else if(stack.Count!=0 && formula[i]==')')
            {
                while(stack.Peek()!="(")
                {
                    tokens.Enqueue(stack.Pop());
                }
                stack.Pop();
                
            }
            else if (formula[i] == '*' || formula[i] == '/')
            {              
                                   
                if (stack.Count ==0 || stack.Peek()=="+" || stack.Peek()=="-" || stack.Peek()=="(")
                {
                    
                    stack.Push(formula[i].ToString());
                    
                }
                else
                {
                    tokens.Enqueue(stack.Pop());
                    stack.Push(formula[i].ToString());
                }                             
            }
            else if (formula[i] == '+' || formula[i] == '-')
            {
                if(stack.Count==0|| stack.Peek()=="(")
                {
                    stack.Push(formula[i].ToString());
                }
                else
                {
                    tokens.Enqueue(stack.Pop());
                    stack.Push(formula[i].ToString());
                }
            }
            else if(formula[i]=='L')
            {
                int pos = CheckFunctionLength(formula, i)+1;
                RPNFormula(formula,i+2,pos);
                tokens.Enqueue("Ln");
                i = pos - 1;
            }
            else if (formula[i] == 'S')
            {
                int pos = CheckFunctionLength(formula, i) + 1;
                RPNFormula(formula, i + 4, pos);
                tokens.Enqueue("Sqrt");
                i = pos - 1;
            }
            else if (formula[i] == 'P')
            {
                int pos = CheckFunctionLength(formula, i) + 1;
                RPNFormula(formula, i + 3, pos);
                tokens.Enqueue("Pow");
                i = pos - 1;
            }

        }

        while (stack.Count!=0)
        {
            tokens.Enqueue(stack.Pop());
        }
       
    }

    static Stack<string> Result()
    {
        Stack<string> result = new Stack<string>();

        while(tokens.Count!=0)
        {
            double number = 0.0;
            double firstOperand = 0.0;
            double secondOperand = 0.0;

            string token = tokens.Dequeue();
            switch (token)
            {
                case "/": secondOperand = float.Parse(result.Pop());
                    firstOperand = float.Parse(result.Pop());
                    number = firstOperand / secondOperand;
                    result.Push(number.ToString()); break;
                case "*": firstOperand = float.Parse(result.Pop());
                    secondOperand = float.Parse(result.Pop());
                    number = firstOperand * secondOperand;
                    result.Push(number.ToString()); break;
                case "+": firstOperand = float.Parse(result.Pop());
                    secondOperand = float.Parse(result.Pop());
                    number = firstOperand + secondOperand;
                    result.Push(number.ToString()); break;
                case "-": secondOperand = float.Parse(result.Pop());
                    firstOperand = float.Parse(result.Pop());
                    number = firstOperand - secondOperand;
                    result.Push(number.ToString()); break;
                case "Ln": firstOperand = float.Parse(result.Pop());
                    number = Math.Log(firstOperand);
                    result.Push(number.ToString()); break;
                case "Sqrt": firstOperand = float.Parse(result.Pop());
                    number = Math.Sqrt(firstOperand);
                    result.Push(number.ToString()); break;
                case "Pow": secondOperand = float.Parse(result.Pop());
                    firstOperand = float.Parse(result.Pop());
                    number = Math.Pow(firstOperand, secondOperand);
                    result.Push(number.ToString()); break;
                default: number = float.Parse(token);
                    result.Push(number.ToString());
                    break;
            }            
        }
        return result;
    }
    
    static void Main()
    {
        Console.Write("Math expression: ");
        string formula = Console.ReadLine();
        RPNFormula(formula, 0, formula.Length);
        Stack<string> number = Result();
        Console.WriteLine("Result: " + number.Pop());
    }
}

