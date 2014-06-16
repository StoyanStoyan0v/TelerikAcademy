namespace MatrixUtils
{
    using System;

    public class MatrixRunner
    {
        private const string NUMBER_INPUT_MSG = "Enter a positive number ";
        private const string WRONG_INPUT_MSG = "You haven't entered a correct positive number";
        private const int MAX_MATRIX_DIMENSIONS = 100;

        static void Main(string[] args)
        {
            Console.WriteLine(NUMBER_INPUT_MSG);
            int n = GetNumber();
            Matrix matrix = new Matrix(n);
            matrix.FillMatrix();
            matrix.Render();
        }

        private static int GetNumber()
        { 
            string input = Console.ReadLine();
            int n;
            while (!int.TryParse(input, out n) || n < 0 || n > MAX_MATRIX_DIMENSIONS)
            {
                Console.WriteLine(WRONG_INPUT_MSG);
                input = Console.ReadLine();
            }
            return n;
        }
    }
}