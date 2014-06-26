namespace Maze
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Maze
    {
        private readonly Random randGenerator = new Random();
        private readonly char[,] maze;

        private bool[,] usedCells;       
        private List<Position> paths;
        private LinkedList<Position> currentPath;
        private List<Position> bestPath;
        private bool shortestFound;
        private int shortestPathLength = int.MaxValue;
        private Position startPosition;
        private Position endPosition;

        public int Heigth
        {
            get
            {
                return this.maze.GetLength(0);
            }
        }

        public int Width
        {
            get
            {
                return this.maze.GetLength(1);
            }
        }

        private Position StartingPosition
        {
            get
            {
                return this.startPosition;
            }
            set
            {
                if (!InRange(value.Row, this.Heigth) || !InRange(value.Col, this.Width))
                {
                    throw new IndexOutOfRangeException("Starting position must be inside the maze boundaries.");
                }
                this.startPosition = value;
            }
        }

        private Position EndingPosition
        {
            get
            {
                return this.endPosition;
            }
            set
            {
                if (!InRange(value.Row, this.Heigth) || !InRange(value.Col, this.Width))
                {
                    throw new IndexOutOfRangeException("Ending position must be inside the maze boundaries.");
                }
                this.endPosition = value;
            }
        }

        private char this[int row, int col]
        {
            get
            { 
                return this.maze[row, col];
            }
            set
            { 
                this.maze[row, col] = value;
            }
        }

        public Maze(int heigth, int width, Position startPos, Position endPos)
        {
            this.maze = new char[heigth, width];
            this.StartingPosition = startPos;
            this.EndingPosition = endPos;
        }

        private Maze(char[,] maze, Position startPos, Position endPos)
        {
            this.maze = maze;
            this.StartingPosition = startPos;
            this.EndingPosition = endPos;
        }
        
        public void FillTheMazeRandomly(int density)
        {
            for (int row = 0; row < this.Heigth; row++)
            {
                for (int col = 0; col < this.Width; col++)
                {
                    if ((row == this.StartingPosition.Row && col == this.StartingPosition.Col))
                    {
                        this[row, col] = 'S';
                    }
                    else if (row == this.EndingPosition.Row && col == this.EndingPosition.Col)
                    {
                        this[row, col] = 'E';
                    }
                    else if (randGenerator.Next(10) % density == 0)
                    {
                        this[row, col] = '#';
                    }
                    else
                    {
                        this[row, col] = '-';
                    }
                }
            }
        }

        public Maze FindLargestEmptyArea()
        {
            var tempMazeArr = (char[,])this.maze.Clone();
            var tempMaze = new Maze(tempMazeArr, this.StartingPosition, this.EndingPosition);
            usedCells = new bool[this.Heigth, this.Width]; 
            bestPath = new List<Position>();

            for (int row = 0; row < this.Heigth; row++)
            {
                for (int col = 0; col < this.Width; col++)
                {
                    paths = new List<Position>();
                    FindAllAreas(row, col);
                    if (bestPath.Count < paths.Count)
                    {
                        bestPath = paths;
                    }
                }
            }

            FillPath(tempMaze, bestPath, ' ');

            return tempMaze;
        }

        public Maze FindAllEmptyAreas()
        {
            var tempMazeArr = (char[,])this.maze.Clone();
            var tempMaze = new Maze(tempMazeArr, this.StartingPosition, this.EndingPosition);
            usedCells = new bool[this.Heigth, this.Width]; 
            paths = new List<Position>();

            for (int row = 0; row < this.Heigth; row++)
            {
                for (int col = 0; col < this.Width; col++)
                {
                    FindAllAreas(row, col);
                }
            }

            FillPath(tempMaze, paths, ' ');
            return tempMaze;
        }

        public Maze FindAllPaths()
        {
            var tempMazeArr = (char[,])this.maze.Clone();
            var tempMaze = new Maze(tempMazeArr, this.StartingPosition, this.EndingPosition);
            currentPath = new LinkedList<Position>();
            paths = new List<Position>();

            FindPaths(this.StartingPosition.Row, this.StartingPosition.Col, false);

            FillPath(tempMaze, paths, ' ');
            return tempMaze;
        }
        
        public Maze FindShortestPath()
        {
            var tempMazeArr = (char[,])this.maze.Clone();
            var tempMaze = new Maze(tempMazeArr, this.StartingPosition, this.EndingPosition);
            shortestFound = false;
            currentPath = new LinkedList<Position>();
            bestPath = new List<Position>();

            FindPaths(this.StartingPosition.Row, this.StartingPosition.Col, true);

            FillPath(tempMaze, bestPath, ' ');

            return tempMaze;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            for (int row = 0; row < this.Heigth; row++)
            {
                for (int col = 0; col < this.Width; col++)
                { 
                    output.AppendFormat("[{0}]",this.maze[row, col]);
                }
                output.AppendLine();
            }
            return output.ToString();
        }
        
        private void FindAllAreas(int row, int col)
        {
            if (!InRange(row, this.Heigth) || !InRange(col, this.Width) || this[row, col] == '#' || this.usedCells[row, col])
            { 
                return;
            }
            else
            {
                paths.Add(new Position() { Row = row, Col = col });
                this.usedCells[row, col] = true;                         
                FindAllAreas(row + 1, col);
                FindAllAreas(row - 1, col);
                FindAllAreas(row, col + 1);
                FindAllAreas(row, col - 1);
            }
        }

        private void FindPaths(int row, int col, bool isSearchedShortest)
        {
            if (!InRange(row, this.Heigth) || !InRange(col, this.Width) || this[row, col] == '#')
            { 
                return;
            }
            else if (shortestFound)
            {
                return;
            }
            else if (this[row, col] == 'E')
            {
                if (isSearchedShortest)
                {
                    if (shortestPathLength > currentPath.Count)
                    { 
                        bestPath = currentPath.ToList();
                        shortestPathLength = bestPath.Count;
                    }

                    if (bestPath.Count == Math.Abs(this.StartingPosition.Row - this.EndingPosition.Row) +
                        Math.Abs(this.StartingPosition.Col - this.EndingPosition.Col))
                    {
                        shortestFound = true;
                    }
                }
                else
                {
                    var nonDuplicated = currentPath.Where(x => !paths.Any(y => y.Row == x.Row && y.Col == x.Col));
                    paths.AddRange(nonDuplicated);
                }
            }
            else
            {
                if (this[row, col] != 'S')
                {
                    currentPath.AddLast(new Position() { Row = row, Col = col });
                }
               
                this[row, col] = '#';
                
                FindPaths(row + 1, col, isSearchedShortest);
                FindPaths(row - 1, col, isSearchedShortest);
                FindPaths(row, col + 1, isSearchedShortest);
                FindPaths(row, col - 1, isSearchedShortest);

                if (row == 0 && col == 0)
                {
                    this[row, col] = 'S';
                }
                else
                {
                    this[row, col] = '-';
                }
                
                if (currentPath.Count > 0)
                {
                    currentPath.RemoveLast();
                }
            }
        }
        
        private void FillPath(Maze maze, IEnumerable<Position> list, char ch)
        {
            foreach (var position in list)
            {
                maze[position.Row, position.Col] = ch;
            }
        }

        private bool InRange(int pos, int dimension)
        {
            return 0 <= pos && pos < dimension;
        }
    }
}