using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DLabyrinth
{
    class Program
    {
        static readonly Queue<Position> queue = new Queue<Position>();

        static char[,,] lab;
        static Position startPos;        
        static int levelsCount;
        static int rowCount;
        static int colsCount;
        static int[,] directions;

        static void Main(string[] args)
        {
            string position = Console.ReadLine();
            var posAsArr = position.Split(' ');
            startPos = new Position(int.Parse(posAsArr[0]),int.Parse(posAsArr[1]),int.Parse(posAsArr[2]),0);

            InitializeLab();
            directions = new int[,] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
            int jumps = BFS();
            Console.WriteLine(jumps);
        }

        static int BFS()
        {
            queue.Enqueue(startPos);
            while (queue.Count > 0)
            {
                var currentPos = queue.Dequeue();
                if (!InRange(currentPos.L, levelsCount))
                {
                    return currentPos.Jumps;
                    
                }
                else
                {
                    if (lab[currentPos.L, currentPos.R, currentPos.C] == 'U')
                    {
                        queue.Enqueue(new Position(currentPos.L + 1, currentPos.R , currentPos.C , currentPos.Jumps + 1));
                    }
                    
                    if (lab[currentPos.L, currentPos.R, currentPos.C] == 'D')
                    {
                        queue.Enqueue(new Position(currentPos.L - 1, currentPos.R , currentPos.C , currentPos.Jumps + 1));
                    }

                    if (lab[currentPos.L, currentPos.R, currentPos.C] == '.')
                    {
                        for (int i = 0; i < directions.GetLength(0); i++)
                        {
                            if (InRange(currentPos.R + directions[i, 0], rowCount) && InRange(currentPos.C + directions[i, 1], colsCount))
                            {
                                queue.Enqueue(new Position(currentPos.L, currentPos.R + directions[i, 0], currentPos.C + directions[i, 1], currentPos.Jumps + 1));
                            }
                        }
                    }
                    lab[currentPos.L, currentPos.R, currentPos.C] = '#';
                }
            }

            return 0;
        }

        private static void InitializeLab()
        {
            var dimensions = Console.ReadLine().Split(' ');
            levelsCount = int.Parse(dimensions[0]);
            rowCount = int.Parse(dimensions[1]);
            colsCount = int.Parse(dimensions[2]);

            lab = new char[levelsCount, rowCount, colsCount];

            for (int i = 0; i < levelsCount; i++)
            {
                for (int j = 0; j < rowCount; j++)
                {
                    var row = Console.ReadLine();

                    for (int k = 0; k < colsCount; k++)
                    {
                        lab[i, j, k] = row[k];
                    }
                }
            }
        }

        private static bool InRange(int pos, int dimension)
        {
            return 0 <= pos && pos < dimension;
        }
    }

    public class Position
    {
        public int L { get; set; }

        public int R { get; set; }

        public int C { get; set; }

        public int Jumps { get; set; }

        public Position(int l, int r, int c, int jumps)
        {
            this.L = l;
            this.R = r;
            this.C = c;
            this.Jumps = jumps;
        }
    }
}