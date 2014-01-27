using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    
    class Program
    {
        static int[,] matrix;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                string[] row = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(row[j]);
                }
            }

            bool isFound=false;
            long maxSum=long.MinValue;
            for (int i = 0; i < n-2; i++)
            {
                for (int j = 0; j < n-4; j++)
                {
                    long currentSum=0;
                    if(IsValid(i,j))
                    {
                        isFound=true;
                        currentSum = GetSum(i,j);
                    }
                    if(currentSum>maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }

            if(!isFound)
            {
                maxSum=0;
                for (int i = 0; i < n; i++)
                {
                    maxSum += matrix[i, i];
                }
                Console.WriteLine("NO "+maxSum);
            }
            else
            {
                Console.WriteLine("YES "+maxSum);
            }
            
        }

        private static long GetSum(int row, int col)
        {
            return  matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + matrix[row + 1, col + 2] +
                matrix[row + 2, col + 2] + matrix[row + 2, col + 3] +matrix[row + 2, col + 4];                
        }

        private static bool IsValid(int row, int col)
        {
           if(matrix[row,col]!=matrix[row,col+1]-1)
           {
               return false;
           }
           if(matrix[row,col+1]!=matrix[row,col+2]-1)
           {
               return false;
           }
           if(matrix[row,col+2]!=matrix[row+1,col+2]-1)
           {
               return false;
           }
           if(matrix[row+1,col+2]!=matrix[row+2,col+2]-1)
           {
               return false;
           }
           if(matrix[row+2,col+2]!=matrix[row+2,col+3]-1)
           {
               return false;
           }
           if (matrix[row + 2, col + 3] != matrix[row + 2, col + 4] -1)
           {
               return false;
           }

           return true;
        }
    }
}
