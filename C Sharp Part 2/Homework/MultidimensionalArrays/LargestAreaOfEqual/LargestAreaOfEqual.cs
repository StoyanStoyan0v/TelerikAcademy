using System;

class LargestAreaOfEqual
{
    static int rows;
    static int cols;
    static bool[,] isVisited;
    static int[,] matrix;
    static int element = 0;
    static int number = 0;
    static int currentCounter = 0;
    static int maxCounter = 0;

    static void ReadMatrix()
    {
        char[] separators = { ' ', ',' };
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string rowAsText = Console.ReadLine();
            string[] numbersAsStrings = rowAsText.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int col = 0; col < numbersAsStrings.Length; col++)
            {
                matrix[row, col] = int.Parse(numbersAsStrings[col]);
            }
        }
    }

    static int FindCurrentArea(int row,int col)
    {
        if(row<0|| col<0 || row==matrix.GetLength(0) || col == matrix.GetLength(1) || isVisited[row,col]==true)
        {
            return currentCounter;
        }

        if (matrix[row, col] == element)
        {
            isVisited[row,col]=true;
            currentCounter++;
            currentCounter = FindCurrentArea(row + 1, col);
            currentCounter = FindCurrentArea(row - 1, col);
            currentCounter = FindCurrentArea(row, col + 1);
            currentCounter = FindCurrentArea(row, col - 1);
            return currentCounter;
        }
        return currentCounter;
    }

    static void AllocateMaxArea()
    {
        for (int row = 0; row < isVisited.GetLength(0); row++)
        {
            for (int col = 0; col < isVisited.GetLength(1); col++)
            {
                currentCounter = 0;
                element = matrix[row, col];
                currentCounter = FindCurrentArea(row, col);
                KeepMaxArea();
            }
        }
        PrintResult();
    }

    static void KeepMaxArea()
    {
        if (currentCounter > maxCounter)
        {
            maxCounter = currentCounter;
            number = element;
        }
    }

    static void PrintResult()
    {
        Console.Clear();
        Console.WriteLine("Matrix height: {0}", rows);
        Console.WriteLine("Matrix width: {0}", cols);
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == number)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(matrix[row, col] + " ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(matrix[row, col] + " ");
                }
            }
            Console.WriteLine();
        }
        Console.ResetColor();
        Console.WriteLine("The largest area is of the element {0} and is found {1} times.", number, maxCounter);
    }

    static void Main()
    {
        Console.Write("Matrix height: ");
        rows=int.Parse(Console.ReadLine());
        Console.Write("Matrix width: ");
        cols = int.Parse(Console.ReadLine());
        isVisited = new bool[rows, cols];
        Console.WriteLine("Enter the matrix values: ");
        matrix = new int[rows, cols];
        ReadMatrix();
        AllocateMaxArea();
    }    
}

