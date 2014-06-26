namespace QueenPuzzle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    class Program
    {
        const int BOARD_SIZE = 8;

        static readonly HashSet<string> solutions = new HashSet<string>();
        static int[,]board;

        static void Main(string[] args)
        {
            board = new int[BOARD_SIZE, BOARD_SIZE];
            Solve(0, 0);
            Console.WriteLine("Total solutions: " + solutions.Count);
            Console.WriteLine("First solution:\n" + solutions.First());
        }

        private static void Solve(int queensCount, int col)
        {
            if (queensCount == BOARD_SIZE)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < BOARD_SIZE; i++)
                {
                    for (int j = 0; j < BOARD_SIZE; j++)
                    {
                        if (board[i, j] != 0)
                        {
                            sb.Append("[ ]");
                        }
                        else
                        {
                            sb.Append("[Q]");
                        }
                    }
                    sb.AppendLine();
                }
                solutions.Add(sb.ToString());
            }
            else
            {
                for (int row = 0; row < BOARD_SIZE; row++)
                {
                    if (board[row, col] == 0)
                    {
                        MarkCells(row, col, 1);
                        Solve(queensCount + 1, col + 1);
                        MarkCells(row, col, -1);
                    }
                }
            }
        }
 
        private static void MarkCells(int row, int col, int mark)
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    if (i == row || j == col || Math.Abs(row - i) == Math.Abs(col - j))
                    {
                        board[i, j] += mark;
                    }

                    if (i == row && j == col)
                    {
                        board[i, j] = 0;
                    }
                }
            }
        }
    }
}