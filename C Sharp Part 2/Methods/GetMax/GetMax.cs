using System;

class GetMax
{
    static int GetMaxNum(int firstNum,int secondNum)
    {
        int higherNum = 0;
        if (firstNum>=secondNum)
        {
            higherNum = firstNum;
        }
        else
        {
            higherNum=secondNum;
        }
        return higherNum;
    }

    static void Main()
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());
        int thirdNumber = int.Parse(Console.ReadLine());

        int highestNumber = GetMaxNum(firstNumber, secondNumber);//Invoke the method to compare the first two variable.
        highestNumber = GetMaxNum(highestNumber,thirdNumber);//Invoke the method again to compare the current highest and the third number.

        Console.WriteLine("Highest number: {0}", highestNumber);
    }
}

