using System;
using System.Collections.Generic;

class MaxEquialSequenceInMatrix
{
    //Usage of global variables avoids using them as parametars if they are local.
    static int rows;
    static int cols;
    static string [,] matrix;
    static int maxCounter = 0;
    static string sequencePositionType = null;
    static List<string> currentSequence = new List<string>();
    static List<string> maxSequence = new List<string>();   

    static void ReadMatrix()
    {
        char[] separators = { ' ', ',' };
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string rowAsText = Console.ReadLine();
            string[] numbersAsStrings = rowAsText.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int col = 0; col < numbersAsStrings.Length; col++)
            {
                matrix[row, col] = numbersAsStrings[col];
            }
        }
    }
  
    //Recursevely check the elements in the four surrounding directions and return the counter of each, then compare to the current max.
    static int CheckRightNeighbours(int currentCounter, int row, int col)
    {
        if (col == matrix.GetLength(1) || matrix[row, col] != matrix[row, col - 1])
        {
            return currentCounter;
        }
        else
        {
            currentCounter++;
            currentSequence.Add(matrix[row, col]);
            return CheckRightNeighbours(currentCounter, row, col + 1); //Recursively checks the next element.

        }
    } 

    static int CheckBottomNeighbours(int currentCounter, int row, int col)
    {
        if (row == matrix.GetLength(0) || matrix[row, col] != matrix[row - 1, col])
        {
            return currentCounter;
        }
        else
        {
            currentCounter++;
            currentSequence.Add(matrix[row, col]);
            return CheckBottomNeighbours(currentCounter, row + 1, col); //Recursively checks the next element.

        }
    }

    static int CheckBottomLeftNeighbours(int currentCounter, int row, int col)
    {
        if (col < 0 || row==matrix.GetLength(0)  || matrix[row, col] != matrix[row-1, col + 1])
        {
            return currentCounter;
        }
        else
        {
            currentCounter++;
            currentSequence.Add(matrix[row, col]);
            return CheckBottomLeftNeighbours(currentCounter, row + 1, col - 1); //Recursively checks the next element.
        }
    }  

    static int CheckBottomRightNeighbours(int currentCounter, int row, int col)
    {
        if (col == matrix.GetLength(1) || row == matrix.GetLength(0) || matrix[row, col] != matrix[row - 1, col - 1])
        {
            return currentCounter;
        }
        else
        {
            currentCounter++;
            currentSequence.Add(matrix[row, col]);
            return CheckBottomRightNeighbours(currentCounter, row + 1, col + 1); //Recursively checks the next element.
        }
    }

    static void LongestSequenceInMatrix()
    {
        int currentCounter;
        string positionType = null;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {

                //Check the elements on the right.
                currentSequence.Add(matrix[row, col]);
                currentCounter = CheckRightNeighbours(1,row, col+1);
                positionType = "row";
                KeepMaximumSequence(currentCounter,positionType);           
                currentSequence.Clear();

                //Check the elements below.
                currentSequence.Add(matrix[row, col]);
                currentCounter = CheckBottomNeighbours(1, row + 1, col);
                positionType = "column";
                KeepMaximumSequence(currentCounter, positionType);
                currentSequence.Clear();

                //Check the elememnts on the left diagonal.
                currentSequence.Add(matrix[row, col]);
                currentCounter = CheckBottomLeftNeighbours(1, row + 1, col - 1);
                positionType = "diagonal";
                KeepMaximumSequence(currentCounter,positionType);
                currentSequence.Clear();               

                //Check the elements on the right diagonal.
                currentSequence.Add(matrix[row, col]);
                currentCounter = CheckBottomRightNeighbours(1, row + 1, col+1);
                positionType = "diagonal";
                KeepMaximumSequence(currentCounter, positionType);
                currentSequence.Clear();
            }
        }
        PrintMaxSequence();
    }

    static void KeepMaximumSequence(int currentCounter,string positionType)
    {
        if (currentCounter > maxCounter)
        {
            maxCounter = currentCounter;
            sequencePositionType = positionType;
            maxSequence = new List<string>(currentSequence);
        }
    } //Keep the current maximal sequence.

    static void PrintMaxSequence()
    {
        Console.Write("Longest sequnece: ");
        foreach (string word in maxSequence)
        {
            Console.Write("{0} ", word);
        }
        Console.WriteLine();
        Console.WriteLine("Times in a {0} sequence: {1}",sequencePositionType, maxCounter);
    }
   
    static void Main()
    {
        Console.Write("Matrix height: ");
        rows = int.Parse(Console.ReadLine());
        Console.Write("Matrix width: ");
        cols = int.Parse(Console.ReadLine());
        matrix = new string[rows, cols];
        Console.WriteLine();
        ReadMatrix();
        Console.WriteLine();
        LongestSequenceInMatrix();

    }
}

