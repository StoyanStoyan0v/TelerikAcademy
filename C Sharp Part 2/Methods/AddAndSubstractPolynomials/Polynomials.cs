using System;
using System.Collections.Generic;

//Check Tests.txt file for tests... input data must be without intervals between the coefficients or operators...
class Polynomials
{    
    static List<int> polynomial = new List<int>();

    static int CoefficientsLength(string[] sub)
    {
        int length = 0;

        for (int i = 0; i < sub.Length; i++)
        {

            int currentLength = 0;
            if (sub[i][sub[i].Length - 1] == 'x')
            {
                currentLength = 2;
            }
            else if (sub[i].Length >= 3 && sub[i][sub[i].Length - 3] == 'x')
            {
                currentLength = int.Parse((sub[i][sub[i].Length - 1]).ToString());
            }
            else
            {
                currentLength = 1;
            }

            if (currentLength > length)
            {
                length = currentLength;
            }
        }
        length++;
        return length;
    }

    static List<int> PolynomialsAdd(string[] sub,string polynomialStr)
    {

        int length = CoefficientsLength(sub);

        polynomial = new List<int>(length);
        for (int i = 0; i < polynomial.Capacity; i++)
        {
            polynomial.Add(0);
        }

        int counter = 0;

        for (int i = 0; i < sub.Length; i++)
        {
            string num = null;
            for (int j = 0; j < sub[i].Length; j++)
            {
                if (sub[i][j] != 'x')
                {
                    num += sub[i][j];

                }
                else
                {
                    if (j == 0 || (j == 1 && sub[i][j - 1] == '-'))
                    {
                        num += "1";
                    }
                    break;
                }
            
            }
           
            int number = int.Parse(num);
            if (polynomialStr[counter] == '-')
            {
                number *= -1;
            }

            if(counter!=0)
            {
                counter++;
            }
            if (i != sub.Length - 1)
            {
                counter += sub[i].Length;
            }
            else
            {
                counter++;
            }
 
            if (sub[i].Length >= 3 && sub[i][sub[i].Length - 3] == 'x')
            {
                polynomial[int.Parse((sub[i][sub[i].Length - 1]).ToString())] += number;
            }
            else if (sub[i][sub[i].Length - 1] == 'x')
            {
                polynomial[1] += number;
            }
            else
            {
                polynomial[0] += number;
            }
        }
        return polynomial;
    }  

    static int[] MultiplyPolynomials(List<int>firstPoly,List<int>secondPoly)
    {
        int [] result = new int [firstPoly.Count+secondPoly.Count-1];

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = 0;
        }

        for (int i = 0; i < firstPoly.Count; i++)
        {
            for (int j = 0; j < secondPoly.Count; j++)
            {
                int position = i + j;
                result[position] += (firstPoly[i] * secondPoly[j]);
            }
        }
        return result;
    }

    static void PrintResult(int[] coefficients)
    {
        Console.Write("Coefficients starting from the lowest power: ");
        Console.WriteLine(string.Join(" ", coefficients));

        Console.Write("The final polynom: ");
        for (int i = coefficients.Length - 1; i >= 0; i--)
        {
            if (i == 0)
            {
                Console.Write("{0}", coefficients[i]);
            }
            else if (i == 1)
            {
                if (coefficients[i - 1] >= 0)
                {
                    Console.Write("{0}x+", coefficients[i]);
                }
                else
                {
                    Console.Write("{0}x", coefficients[i]);
                }

            }
            else
            {
                if (coefficients[i - 1] >= 0)
                {
                    Console.Write("{0}x^{1}+", coefficients[i], i);
                }
                else
                {
                    Console.Write("{0}x^{1}", coefficients[i], i);
                }
            }
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        Console.Write("Enter the first polynom: ");
        string firstPolynom = Console.ReadLine();
        Console.Write("Enter the second polynom: ");
        string secondPolynom = Console.ReadLine();
        Console.Write("Enter \"+\" to add the polynoms or \"-\" to subtract them: ");
        string operation = Console.ReadLine();

        if (operation == "+")
        {
             string polynomialString;polynomialString = firstPolynom + "+" + secondPolynom;
            string[] subPolynomials = polynomialString.Split(new char[] { '+', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> coefficients = PolynomialsAdd(subPolynomials,polynomialString);
            PrintResult(coefficients.ToArray());
        }
        else if(operation=="-")
        {
            string polynomialString;polynomialString = firstPolynom + "-" + secondPolynom;
            string[] subPolynomials = polynomialString.Split(new char[] { '+', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> coefficients = PolynomialsAdd(subPolynomials,polynomialString);
            PrintResult(coefficients.ToArray());
        }
        else
        {
            string[] subPolynomialsFirst = firstPolynom.Split(new char[] { '+', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> coefficientsFirst = PolynomialsAdd(subPolynomialsFirst,firstPolynom);
            string[] subPolynomialsSecond = secondPolynom.Split(new char[] { '+', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> coefficientsSecond = PolynomialsAdd(subPolynomialsSecond,secondPolynom);
            int[] multipliedPolynomials = MultiplyPolynomials(coefficientsFirst, coefficientsSecond);
            PrintResult(multipliedPolynomials);
        }
    }   
}
