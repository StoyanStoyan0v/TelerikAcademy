namespace MatrixUtils
{
    using System;
    using System.Text;
    
    public class Matrix
    {
        private const int DIRECTIONS_COUNT = 8;

        private readonly int[,] matrix;
        private Position currentPosition;
        private Position currentDirection;

        public int this[int row, int col]
        {
            get
            {
                if (!InRange(row, matrix.GetLength(0)) || !InRange(col, matrix.GetLength(1)))
                {
                    throw new IndexOutOfRangeException("Index is outside of the bouundaries of the array!");
                }
                return this.matrix[row, col];
            }
        }

        public int Rows
        {
            get
            {
                return this.matrix.GetLength(0);
            }
        }

        public int Cols
        {
            get
            {
                return this.matrix.GetLength(1);
            }
        }

        public Matrix(int dimensions)
        {
            this.matrix = new int[dimensions, dimensions];
            this.currentPosition = new Position();
            this.currentDirection = Directions.GetInitialDirection();
        }

        public void FillMatrix()
        {
            int cellValue = 0;

            while (true)
            { 
                matrix[currentPosition.X, currentPosition.Y] = ++cellValue;

                if (!CheckForDirection())
                {
                    currentPosition = GetNearestCell();

                    if (matrix[currentPosition.X, currentPosition.Y] != 0)
                    {
                        break;
                    }
                    
                    matrix[currentPosition.X, currentPosition.Y] = ++cellValue;
                }
               
                while (!InRange(currentPosition.X + currentDirection.X, this.Rows) ||
                       !InRange(currentPosition.Y + currentDirection.Y, this.Cols) ||
                       matrix[currentPosition.X + currentDirection.X, currentPosition.Y + currentDirection.Y] != 0)
                {
                    currentDirection = Directions.GetNextDirection(currentDirection);
                }

                currentPosition.X += currentDirection.X;
                currentPosition.Y += currentDirection.Y;              
            }
        }

        private bool CheckForDirection()
        {
            Position currentDirection = Directions.GetInitialDirection();

            for (int i = 0; i < DIRECTIONS_COUNT; i++)
            {
                var nextDirection = Directions.GetNextDirection(currentDirection);
                var nextDirectionX = nextDirection.X;
                var nextDirectionY = nextDirection.Y;

                if (InRange(currentPosition.X + nextDirectionX, this.Rows) && InRange(currentPosition.Y + nextDirectionY, this.Cols) &&
                    this[currentPosition.X + nextDirectionX, currentPosition.Y + nextDirectionY] == 0)
                {
                    return true;
                }

                currentDirection = nextDirection;
            }

            return false;
        }

        private Position GetNearestCell()
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    if (this[i, j] == 0)
                    { 
                        return new Position(i, j);
                    }
                }
            }
            return new Position();
        }

        public void Render()
        {
            Console.WriteLine(this);
        }

        private bool InRange(int index, int dimension)
        {
            return 0 <= index && index < dimension;
        }

        public override string ToString()
        {
            StringBuilder matrixAsStr = new StringBuilder();
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    matrixAsStr.AppendFormat("{0,3}", this[row, col]);
                }
                if (row != this.Rows - 1)
                {
                    matrixAsStr.Append('\n');
                }
            }
            return matrixAsStr.ToString();
        }
    }
}