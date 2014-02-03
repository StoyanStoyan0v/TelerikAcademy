using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrix
{
    public static class SecondTest
    {
        private static Matrix<string> matrix = new Matrix<string>(3, 3);
        private static Matrix<int> otherMatrix = new Matrix<int>(2, 2);

        static SecondTest()
        {
            matrix[0, 1] = "Some word";
            //Leave all the rest empty

            for (int i = 0; i < otherMatrix.Rows; i++)
            {
                for (int j = 0; j < otherMatrix.Columns; j++)
                {
                    otherMatrix[i, j] = 5;
                }
            }
        }

        public static void ExecuteSecondTest()
        {
            Console.Write("The first matrix ");
            if(matrix)
            {
                Console.WriteLine("has not empty cells!");
            }
            else
            {
                Console.WriteLine("has empty cells!");
            }

            Console.Write("The second matrix ");
            if(otherMatrix)
            {
                Console.WriteLine("has not empty cells!");
            }
            else
            {
                Console.WriteLine("has empty cells!");
            }
        }
    }
}
