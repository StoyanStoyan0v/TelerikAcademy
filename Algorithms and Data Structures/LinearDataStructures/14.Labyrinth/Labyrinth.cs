namespace Labyrinth
{
    using System;
    
    class Labyrinth
    {
        private static string[,] lab;

        static void Main(string[] args)
        {
            int startRow = 0, startCol = 0;
            
            FillLabyrinth(ref startRow, ref startCol);
                       
            CalculateDistances(0, startRow, startCol);

            PrintArray();
        }

        private static void FillLabyrinth(ref int startRow, ref int startCol)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            lab = new string[n, m];

            for (int i = 0; i < n; i++)
            {
                string row = Console.ReadLine();
                string[]rowAsChars = row.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < m; j++)
                {
                    if (rowAsChars[j] == "*")
                    {
                        startRow = i;
                        startCol = j;
                    }
                    lab[i, j] = rowAsChars[j];
                }
            }
            Console.WriteLine();
        }

        private static void CalculateDistances(int counter, int row, int col)
        {
            if (row < 0 || col < 0 || row >= lab.GetLength(0) || col >= lab.GetLength(1) || lab[row, col] == "x")
            {
                return;
            }

            if (lab[row, col] == "0" || lab[row, col] == "*" || int.Parse(lab[row, col]) > counter)
            {
                if (lab[row, col] != "*")
                {
                    counter++;
                    lab[row, col] = counter.ToString();
                }

                CalculateDistances(counter, row, col + 1);
          
                CalculateDistances(counter, row - 1, col); 
           
                CalculateDistances(counter, row, col - 1);

                CalculateDistances(counter, row + 1, col);
            }
        }

        private static void PrintArray()
        {
            for (int i = 0; i < lab.GetLength(0); i++)
            {
                for (int j = 0; j < lab.GetLength(1); j++)
                {
                    if (lab[i, j] == "0")
                    {
                        lab[i, j] = "u";
                    }

                    Console.Write(lab[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}