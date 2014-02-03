using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrix
{
    class FirstTest
    {
        //First test with some preliminary definied values
        private static Matrix<double> firstMatrix = new Matrix<double>(3, 3);
        private static Matrix<double> secondMatrix = new Matrix<double>(3, 3);


        //Initialize the both matrices in the constructor, so when the class is invoked for first time, the matrices are ready to be used.
        static FirstTest()
        {
            Console.WriteLine("First matrix: ");
            InitializeMatrices(firstMatrix);
            Console.WriteLine("\nSecond matrix: ");
            InitializeMatrices(secondMatrix);
        }

        private static void InitializeMatrices(Matrix<double> matrix)
        {
            for (int row = 0; row < matrix.Rows; row++)
            {
                string rowAsString = Console.ReadLine();
                string[] numbersAsString = rowAsString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < numbersAsString.Length; col++)
                {
                    matrix[row, col] = double.Parse(numbersAsString[col]);
                }
            }
        }

        public static void ExecuteFirstTest()
        {
            Console.WriteLine();
            Console.WriteLine("Sum of the both matrices: ");
            try
            {
                Matrix<double> sum = firstMatrix + secondMatrix;
                Console.WriteLine(sum);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Cannot add the matrices. Inapropriate dimensions!.");
            }

            Console.WriteLine("Difference of the both matrices: ");
            try
            {
                Matrix<double> difference = firstMatrix - secondMatrix;
                Console.WriteLine(difference);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Cannot substract the matrices. Inapropriate dimensions!");
            }

            Console.WriteLine("Product of the both matrices: ");
            try
            {
                Matrix<double> product = firstMatrix * secondMatrix;
                Console.WriteLine(product);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Cannot multiply the matrices. Invalid dimensions!");
            }
        }
    }
}
