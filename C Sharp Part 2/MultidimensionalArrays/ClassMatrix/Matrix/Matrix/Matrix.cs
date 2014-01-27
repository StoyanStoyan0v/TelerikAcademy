using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public class Matrix
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
}


