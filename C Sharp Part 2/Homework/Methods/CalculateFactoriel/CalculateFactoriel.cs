using System;
using System.Collections.Generic;

class CalculateFactoriel
{
    static int[] NFactoriel(int[]array,int n)
    {

        int x = 2;
        while (x<=n)
        {
            array = MultipliedArray(array, x);
            x++;
        }
        return array;
    }

    static int[] MultipliedArray(int[] array, int number)
    {
        int power = 0;
        List <int> sum = new List<int>();
        while (number !=0)
        {
            
            if (number % 10 != 0)
            {
                List<int> product = new List<int>();
                int remainder = 0;

                for (int length = array.Length - 1; length >= 0; length--)
                {
                    int totalProduct = (array[length] * (number % 10) * (int)Math.Pow(10, power)) + remainder;
                    product.Add(totalProduct % 10);
                    remainder = totalProduct / 10;
                }

                if (remainder != 0)
                {
                    product.Add(remainder);
                }

                product.Reverse();
                EvenNumbersLength(sum, product);
                sum = new List<int>(SumTwoArrays(sum, product));

            }            
            number /= 10;
            power++;
        }     
        array = sum.ToArray();
        return array;
    }

    static void EvenNumbersLength(List<int> firstNumber, List<int> secondNumber)
    {
        if (firstNumber.Count > secondNumber.Count)
        {
            secondNumber.Reverse();
            while (secondNumber.Count < firstNumber.Count)
            {
                secondNumber.Add(0);
            }
            secondNumber.Reverse();
        }
        else if (firstNumber.Count < secondNumber.Count)
        {
            firstNumber.Reverse();
            while (firstNumber.Count < secondNumber.Count)
            {
                firstNumber.Add(0);
            }
            firstNumber.Reverse();
        }
    }

    static List<int> SumTwoArrays(List<int> firstArray, List<int> secondArray)
    {
        List<int> sum = new List<int>();
        int remainder = 0;
        for (int length = firstArray.Count - 1; length >= 0; length--)
        {
            sum.Add(((firstArray[length] + secondArray[length]) + remainder) % 10);
            remainder = ((firstArray[length] + secondArray[length]) + remainder) / 10;
        }
        if (remainder != 0)
        {
            sum.Add(remainder);
        }
        sum.Reverse();
        return sum;
    }

    static void Main()
    {
        Console.Write("n= ");
        int n = int.Parse(Console.ReadLine());
        int[] array = { 1 };
        int[] nFactoriel = NFactoriel(array, n);
        Console.Write("n!= ",n);
        Console.WriteLine(string.Join("",nFactoriel));
    }
}

