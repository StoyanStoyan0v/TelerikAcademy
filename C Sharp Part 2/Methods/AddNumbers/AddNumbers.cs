using System;
using System.Collections.Generic;

class AddBigNumbers
{
    static List<int> ReadArray(List <int> number)
    {
        string arrayAsString = Console.ReadLine();

        for (int i = 0; i < arrayAsString.Length; i++)
        {            
             number.Add(int.Parse((arrayAsString[i]).ToString()));                    
        }
        return number;
    }

    static void EvenNumbersLength(List<int> firstNumber, List<int> secondNumber)
    {
        //This method makes the length of the both numbers equial extending the shorter array filling it with zeros.
        //We make this to avoid adding element from the longer one with missing element from the other.
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

    static int[] SumTwoArrays(List<int>firstArray,List<int> secondArray)
    {
        int[] sum = new int[firstArray.Count];
        int remainder = 0;
        for (int length = firstArray.Count-1; length >= 0; length--)
        {
            //Fill the array with digit: the remainder of the sum between the sum of the both numbers and the previous remainder.
            sum[length] = ((firstArray[length] + secondArray[length])+remainder)%10; 
            //Keep the remainder to be added to the next digit.
            remainder = ((firstArray[length] + secondArray[length]) + remainder) / 10;
        }
        return sum;
    }

    static void PrintResult(int[] sum)
    {
        Console.Write("The sum of both numbers is: ");
      
        for (int i = 0; i < sum.Length; i++)
        {
            Console.Write(sum[i]);
        }
        Console.WriteLine();
       
    }

    static void Main()
    {
        List<int> firstNumber = new List<int>();
        Console.Write("Enter first number: ");
        firstNumber=ReadArray(firstNumber);
        Console.Write("Enter second number: ");
        List<int> secondNumber = new List<int>();
        secondNumber = ReadArray(secondNumber);

        EvenNumbersLength(firstNumber, secondNumber);

        int[] sum = SumTwoArrays(firstNumber, secondNumber);

        PrintResult(sum);
    }   
}

