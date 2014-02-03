using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrix
{
    public class Matrix<T>
    {
        private T[,] matrix;

        public Matrix(int rows, int cols)
        {
            this.matrix = new T[rows, cols];
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

        public T this[int row, int col]
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

        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            Matrix<T> result = new Matrix<T>(firstMatrix.Rows, firstMatrix.Columns);
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
                        result[row, col] = (dynamic)firstMatrix[row, col] + (dynamic)secondMatrix[row, col];
                    }
                }
                return result;
            }
        }

        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Rows != secondMatrix.Rows || firstMatrix.Columns != secondMatrix.Columns)
            {
                throw new System.InvalidOperationException("Cannot substract matrices with different dimensions.");
            }
            else
            {
                Matrix<T> result = new Matrix<T>(firstMatrix.Rows, secondMatrix.Columns);
                for (int row = 0; row < firstMatrix.Rows; row++)
                {
                    for (int col = 0; col < firstMatrix.Columns; col++)
                    {
                        result[row, col] = (dynamic)firstMatrix[row, col] - (dynamic)secondMatrix[row, col];
                    }
                }
                return result;
            }
        }

        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            Matrix<T> result = new Matrix<T>(firstMatrix.Rows, secondMatrix.Columns);
            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Columns; j++)
                {
                    for (int k = 0; k < firstMatrix.Columns; k++)
                    {
                        result[i, j] += (dynamic)firstMatrix[i, k] * (dynamic)secondMatrix[k, j];
                    }
                }
            }
            return result;
        }

        public static bool operator true (Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if((dynamic)matrix[i,j]==0 || matrix[i,j] == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool operator false(Matrix<T>matrix)
        {
            return false;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Columns; col++)
                {
                    result.Append(string.Format("{0,8: 0.00}",matrix[row, col]));
                }
                result.AppendLine();
            }
            return result.ToString();
        }
    }
}
