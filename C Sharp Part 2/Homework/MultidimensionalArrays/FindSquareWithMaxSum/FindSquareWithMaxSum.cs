using System;

class FindSquareWithMaxSum
{
    static int rows;
    static int cols;
    static int squareDimensions;
    static int[,] matrix;
    static int maxSum = int.MinValue;

    static void PrintSquare(int startRow, int startCol)
    {
        for (int row = startRow; row < startRow+squareDimensions; row++)
        {
            for (int col = startCol; col < startCol+squareDimensions; col++)
            {
                Console.Write("{0,3}",matrix[row,col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine("Maximum sum: {0}",maxSum);
    }

    static void ReadMatrix()
    {
        char[] separators = {' ',','};        
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

    static void MaximumSumSquare()
    {       
        int startRow = 0;
        int startCol = 0;

        //Check subareas starting from every possible element in the matrix.
        for (int row = 0; row < matrix.GetLength(0)-squareDimensions; row++)
        {          
            for (int col = 0; col < matrix.GetLength(1)-squareDimensions; col++)
            {
                //Calculate sum of the submatrix.
                int currentSum = 0;
                for (int i = row; i < row+squareDimensions; i++)
                {
                    for (int j = col; j < col+squareDimensions; j++)
                    {
                        currentSum += matrix[i, j];
                    }
                }

                //If the sum is greater than the current max, keep the new max and the starting element of the submatrix.
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    startRow = row;
                    startCol = col;
                }

            }
        }
        //Print the submatrix.
        PrintSquare(startRow, startCol);
    }

    static void Main()
    {
        Console.Write("Matrix height: ");
        rows = int.Parse(Console.ReadLine());
        Console.Write("Matrix width: ");
        cols = int.Parse(Console.ReadLine());
        Console.Write("Dimensions of the square submatrix with maximum sum: ");
        squareDimensions = int.Parse(Console.ReadLine());
        matrix = new int[rows, cols];
        Console.WriteLine();
        ReadMatrix();
        Console.WriteLine();
        Console.WriteLine("Submatrix with maximum sum: ");
        MaximumSumSquare();
    }
}

