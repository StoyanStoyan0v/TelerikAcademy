using System;
//using MatrixLibrary
//You can uncomment the line above and remove the whole class Matrix and it will works because it has been exported as a library...

class Matrix
{
    private int[,] matrix;

    public Matrix(int rows, int cols)
    {
        this.matrix = new int[rows, cols];
    }

    public int Rows
    {
        get
        {
            return this.matrix.GetLength(0);
        }
    }

    public int Columns
    {
        get
        {
            return this.matrix.GetLength(1);
        }
    }

    public int this[int row, int col]
    {
        get
        {
            return this.matrix[row, col];
        }
        set
        {
            this.matrix[row, col] = value;
        }
    }

    public static Matrix operator +(Matrix firstMatrix, Matrix secondMatrix)
    {
        Matrix result = new Matrix(firstMatrix.Rows, firstMatrix.Columns);
        if (firstMatrix.Rows != secondMatrix.Rows || firstMatrix.Columns != secondMatrix.Columns)
        {
            throw new System.InvalidOperationException("Cannot add matrices with different dimensions.");
        }
        else
        {
            for (int row = 0; row < firstMatrix.Rows; row++)
            {
                for (int col = 0; col < firstMatrix.Columns; col++)
                {
                    result[row, col] = firstMatrix[row, col] + secondMatrix[row, col];
                }
            }
            return result;
        }
    }

    public static Matrix operator -(Matrix firstMatrix, Matrix secondMatrix)
    {
        if (firstMatrix.Rows != secondMatrix.Rows || firstMatrix.Columns != secondMatrix.Columns)
        {
            throw new System.InvalidOperationException("Cannot substract matrices with different dimensions.");
        }
        else
        {
            Matrix result = new Matrix(firstMatrix.Rows, secondMatrix.Columns);
            for (int row = 0; row < firstMatrix.Rows; row++)
            {
                for (int col = 0; col < firstMatrix.Columns; col++)
                {
                    result[row, col] = firstMatrix[row, col] - secondMatrix[row, col];
                }
            }
            return result;
        }
    }

    public static Matrix operator *(Matrix firstMatrix, Matrix secondMatrix)
    {
        Matrix result = new Matrix(firstMatrix.Rows, secondMatrix.Columns);
        for (int i = 0; i < result.Rows; i++)
        {
            for (int j = 0; j < result.Columns; j++)
            {
                for (int k = 0; k < firstMatrix.Columns; k++)
                {
                    result[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
                }
            }
        }
        return result;
    }

    public static void ReadMatrix(Matrix matrix)
    {
        for (int row = 0; row < matrix.Rows; row++)
        {
            string rowAsString = Console.ReadLine();
            string[] numbersAsString = rowAsString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int col = 0; col < numbersAsString.Length; col++)
            {
                matrix[row, col] = int.Parse(numbersAsString[col]);
            }
        }
    }

    public override string ToString()
    {
        string result = null;
        for (int row = 0; row < this.Rows; row++)
        {
            for (int col = 0; col < this.Columns; col++)
            {
                result += matrix[row, col] + " ";
            }
            result += Environment.NewLine;
        }
        return result;
    }
}

class MatrixClassTest
{
    static void Main()
    {
        Console.WriteLine("First matrix dimensions: ");
        Console.Write("Height: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Width: ");
        int cols = int.Parse(Console.ReadLine());
        Matrix firstMatrix = new Matrix(rows, cols);
        Console.WriteLine("Enter the first matrix: ");
        Matrix.ReadMatrix(firstMatrix);

        Console.WriteLine("Second matrix dimensions: ");
        Console.Write("Height: ");
        rows = int.Parse(Console.ReadLine());
        Console.Write("Width: ");
        cols = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the second matrix: ");
        Matrix secondMatrix = new Matrix(rows, cols);
        Matrix.ReadMatrix(secondMatrix);

        Console.WriteLine();
        Console.WriteLine("Sum of the both matrices: ");
        try
        {
            Matrix sum = firstMatrix + secondMatrix;
            Console.WriteLine(sum.ToString());
        }
        catch(InvalidOperationException)
        {
            Console.WriteLine("Cannot add matrices with different dimensions.");
        }

        Console.WriteLine();
        Console.WriteLine("Difference of the both matrices: ");
        try
        {
            Matrix difference = firstMatrix - secondMatrix;
            Console.WriteLine(difference.ToString());
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Cannot substract matrices with different dimensions.");
        }

        Console.WriteLine();
        Console.WriteLine("Product of the both matrices: ");
        Matrix product = firstMatrix * secondMatrix;
        Console.WriteLine(product.ToString());

    }
}

