using System;
using System.Text;
using System.IO;

class MaximalSumMatrix
{
    static string inputFilePath;
    static string outputFilePath;
    static int squareDimensions;
    static int[,] matrix;
    static int maxSum = int.MinValue;

    static void ReadDimensions(ref int n, ref int dimensions) //Read both the initial and output matrices dimensions.
    {
        StreamReader reader = new StreamReader(inputFilePath);
        using (reader)
        {
            //Read only the next to lines to get the information for the dimensions.
            int line = 0;
            string lineRead = reader.ReadLine();
            while (line < 3)
            {
                line++;

                if (line == 1)
                {
                    n = int.Parse(lineRead);
                }
                else if (line == 2)
                {
                    dimensions = int.Parse(lineRead);
                }
                lineRead = reader.ReadLine();
            }
        }
    }

    static void ReadMatrix() //Read the matrix.
    {
        StreamReader reader = new StreamReader(inputFilePath);
        char[] separators = { ' ', ',' };
       
        using (reader)
        {

            //Get all the lines but the first two.
            int row=0;
            int line = 0;           
            string rowAsText = reader.ReadLine();
            while (row < matrix.GetLength(0))
            {
                line++;

                if (line > 2)
                {
                    //Split the row of numbers into an array of strings and parse each of them to the corresponding matrix cell.
                    string[] numbersAsStrings = rowAsText.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    for (int col = 0; col < numbersAsStrings.Length; col++)
                    {
                        matrix[row, col] = int.Parse(numbersAsStrings[col]);
                    }
                    row++;
                }
                rowAsText = reader.ReadLine();
            }
        }       
    } 

    static void MaximumSumSquare()
    {
        int startRow = 0;
        int startCol = 0;

        //Check subareas starting from every possible element in the matrix.
        for (int row = 0; row < matrix.GetLength(0) - squareDimensions; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - squareDimensions; col++)
            {
                //Calculate sum of the submatrix.
                int currentSum = 0;
                for (int i = row; i < row + squareDimensions; i++)
                {
                    for (int j = col; j < col + squareDimensions; j++)
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
        //Get square
        Square(startRow, startCol);
    }

    static void Square(int startRow, int startCol)
    {
        for (int row = startRow; row < startRow + squareDimensions; row++)
        {
            string rowAsString = null; //Keep the row of numbers as string.
            for (int col = startCol; col < startCol + squareDimensions; col++)
            {
                rowAsString+= matrix[row, col]+" ";
            }

            //Pass the row to the file writing method.
            WriteToFile(rowAsString);
        }
        WriteToFile(maxSum.ToString());//Write the sum to the file.
    }

    static void WriteToFile(string content) 
    {
        // Making an instance of the writing class, call the constructor with the apending variable givin it "true" value.
        // This way each of the incoming rows will be written one after one instead of removing the lines on the first row.

        StreamWriter writer = new StreamWriter(outputFilePath, true); 
        using(writer)
	    {
            writer.WriteLine(content);
        }
    }

    static void Main()
    {
        Console.Write("Enter the path to file with the matrix: ");
        inputFilePath = Console.ReadLine(); //matrix.txt
        Console.Write("Enter the path to the file to be created with the max sum: ");
        outputFilePath = Console.ReadLine();
        int n=0;
        squareDimensions = 0;
        ReadDimensions(ref n, ref squareDimensions); //Pass the references of the variable to change their values.
        matrix = new int[n, n];
        ReadMatrix();
        MaximumSumSquare();
        Console.WriteLine("The result is exported to the file!");
    }
}

