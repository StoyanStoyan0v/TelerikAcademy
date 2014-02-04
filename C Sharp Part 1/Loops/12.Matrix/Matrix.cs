using System;

class Matrix
{
    static void Main()
    {
        string input = Console.ReadLine();
        int matrixBoarder = int.Parse(input);
        for (int i = 1; i <= matrixBoarder; i++)
        {
            for (int j = i; j < matrixBoarder+i; j++)
            {
                Console.Write("{0,3}",j);
            }
            Console.WriteLine();            
        }
    }
}

