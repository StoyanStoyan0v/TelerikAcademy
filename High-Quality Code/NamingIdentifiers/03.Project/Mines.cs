namespace Project
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Mines
    { 
        static void Main()
        {
            string command = string.Empty;
            char[,] field = CreateGameField();
            char[,] mines = CreateMines();
            int counter = 0;
            bool isMineExploded = false;
            List<Score> champions = new List<Score>(6);
            int row = 0;
            int col = 0;
            bool gameInProcess = true;
            const int MAX = 35;
            bool isCompleted = false;

            do
            {
                if (gameInProcess)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                                      " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    DrawBoard(field);
                    gameInProcess = false;
                }
                Console.Write("Daj red i kolona : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out col) &&
                        row <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }
                switch (command)
                {
                    case "top":
                        GetResult(champions);
                        break;
                    case "restart":
                        field = CreateGameField();
                        mines = CreateMines();
                        DrawBoard(field);
                        isMineExploded = false;
                        gameInProcess = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (mines[row, col] != '*')
                        {
                            if (mines[row, col] == '-')
                            {
                                UpdateBoard(field, mines, row, col);
                                counter++;
                            }
                            if (MAX == counter)
                            {
                                isCompleted = true;
                            }
                            else
                            {
                                DrawBoard(field);
                            }
                        }
                        else
                        {
                            isMineExploded = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }
                if (isMineExploded)
                {
                    DrawBoard(mines);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
                                  "Daj si niknejm: ", counter);
                    string nickName = Console.ReadLine();
                    Score score = new Score(nickName, counter);
                    if (champions.Count < 5)
                    {
                        champions.Add(score);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < score.Points)
                            {
                                champions.Insert(i, score);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }
                    champions.Sort((Score firstPoints, Score otherPoints) => otherPoints.Name.CompareTo(firstPoints.Name));
                    champions.Sort((Score firstPoints, Score otherPoints) => otherPoints.Points.CompareTo(firstPoints.Points));
                    GetResult(champions);

                    field = CreateGameField();
                    mines = CreateMines();
                    counter = 0;
                    isMineExploded = false;
                    gameInProcess = true;
                }
                if (isCompleted)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    DrawBoard(mines);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string name = Console.ReadLine();
                    Score points = new Score(name, counter);
                    champions.Add(points);
                    GetResult(champions);
                    field = CreateGameField();
                    mines = CreateMines();
                    counter = 0;
                    isCompleted = false;
                    gameInProcess = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void GetResult(List<Score> score)
        {
            Console.WriteLine("\nTo4KI:");
            if (score.Count > 0)
            {
                for (int i = 0; i < score.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii",
                        i + 1, score[i].Name, score[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void UpdateBoard(char[,] field, char[,] mines, int row, int col)
        {
            char neighbourBombs = GetNeighbourBombs(mines, row, col);
            mines[row, col] = neighbourBombs;
            field[row, col] = neighbourBombs;
        }

        private static void DrawBoard(char[,] board)
        {
            int row = board.GetLength(0);
            int col = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < row; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < col; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] CreateMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] bombsField = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    bombsField[i, j] = '-';
                }
            }

            List<int> bombs = new List<int>();
            while (bombs.Count < 15)
            {
                Random random = new Random();
                int rand = random.Next(50);
                if (!bombs.Contains(rand))
                {
                    bombs.Add(rand);
                }
            }

            foreach (int bomb in bombs)
            {
                int col = (bomb / cols);
                int row = (bomb % cols);
                if (row == 0 && bomb != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }
                bombsField[col, row - 1] = '*';
            }

            return bombsField;
        }

        private static char GetNeighbourBombs(char[,] field, int row, int col)
        {
            int neighbourBombs = 0;
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field[row - 1, col] == '*')
                { 
                    neighbourBombs++; 
                }
            }
            if (row + 1 < rows)
            {
                if (field[row + 1, col] == '*')
                { 
                    neighbourBombs++; 
                }
            }
            if (col - 1 >= 0)
            {
                if (field[row, col - 1] == '*')
                { 
                    neighbourBombs++;
                }
            }
            if (col + 1 < cols)
            {
                if (field[row, col + 1] == '*')
                { 
                    neighbourBombs++;
                }
            }
            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (field[row - 1, col - 1] == '*')
                { 
                    neighbourBombs++; 
                }
            }
            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (field[row - 1, col + 1] == '*')
                { 
                    neighbourBombs++; 
                }
            }
            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (field[row + 1, col - 1] == '*')
                { 
                    neighbourBombs++; 
                }
            }
            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (field[row + 1, col + 1] == '*')
                { 
                    neighbourBombs++; 
                }
            }
            return char.Parse(neighbourBombs.ToString());
        }
    }
}