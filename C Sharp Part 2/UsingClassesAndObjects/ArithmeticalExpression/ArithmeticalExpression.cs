using System;
using System.Collections.Generic;

class ArithmeticalExpression
{
    static Queue<string> tokens = new Queue<string>();

    static string GetNummeralToken(string formula, string number, ref int i)
    {
        //Get sequentive digital tokens and return a number.
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
        //If there is a function (Ln,Pow,Sqrt) get the length of that function from first "(" to the last ")".
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

        //Itterate through the intiial formula string and check the tokens.
        for (int i = start; i < end; i++)
        {
            //If the token is number add it to the queue.
            number = GetNummeralToken(formula, number, ref i);
            if (number != null)
            {
                tokens.Enqueue(number);
            }
            number = null;

            //If token is "(", add it to the stack.
            if(formula[i]=='(')
            {
                stack.Push(formula[i].ToString());
            }

            //If token is ")", start replacing all the tokens in the stack to the queue until "(" token occur.
            else if(stack.Count!=0 && formula[i]==')')
            {
                while(stack.Peek()!="(")
                {
                    tokens.Enqueue(stack.Pop());
                }
                stack.Pop();
                
            }

            //If token is "*" or "/", "+" or "/", check the top token in the stack.If it is with lower priority, put the new token above it,
            // else replace the the top one in the stack with the new and put the poped one in the queue.
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

            // If the token is "L", "S" or "P, calculate the length of the functuion in the brackets and invoke this method recursevily.
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

        //Check the tokens in the queue and put them in a new queue.
        while(tokens.Count!=0)
        {
            double number = 0.0;
            double firstOperand = 0.0;
            double secondOperand = 0.0;

            //Dequeuen a token and check it, if it is an operator, apply the function to the required operands and put the result 
            // in the new queue.
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

