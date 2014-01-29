using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRES4Numbers
{
    class Program
    {
        static int count = 0;
        static int[,] matrix;

        static void Main(string[] args)
        {
            string dimensions = Console.ReadLine();
            string[] actualDimensions = Console.ReadLine().Split(' ');
            int n = int.Parse(actualDimensions[0])+1;
            int m = int.Parse(actualDimensions[1])+1;
            matrix = new int[n, m];

            int x = int.Parse(Console.ReadLine());
            for (int i = 0; i < x; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                if(int.Parse(line[0])<matrix.GetLength(0) && int.Parse(line[1])<matrix.GetLength(1))
                matrix[int.Parse(line[0]), int.Parse(line[1])] = 1;
            }

            GetPath(0, 0);
            Console.WriteLine(count);

        }

        private static void GetPath(int row, int col)
        {
            if (row == matrix.GetLength(0)-1 && col == matrix.GetLength(1)-1)
            {
                count++;
                return;
            }   
            else if(row>matrix.GetLength(0)-1||col>matrix.GetLength(1)-1 )
            {
                return;
            }
            else if(matrix[row,col]==1)
            {
                return;
            }
            else
            {
                GetPath(row + 1, col);
                GetPath(row, col + 1);
            }
        }
    }
}
