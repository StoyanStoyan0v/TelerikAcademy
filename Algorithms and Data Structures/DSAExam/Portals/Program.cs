using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portals
{
    class Program
    {
        static int[,] maze;

        static bool[,] used;

        static int max = int.MinValue;

        static void Main(string[] args)
        {
            var pos = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            var labSizes = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            maze = new int[labSizes[0], labSizes[1]];
            used = new bool[labSizes[0], labSizes[1]];

            for (int i = 0; i < maze.GetLength(0); i++)
            {
                var row = Console.ReadLine().Split(' ');
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (row[j] == "#")
                    {
                        maze[i, j] = -1;
                    }
                    else
                    {
                        maze[i, j] = int.Parse(row[j].ToString());
                    }
                }
            }
            
            Dfs(pos[0], pos[1], 0);
            Console.WriteLine(max);
        }
        
        private static void Dfs(int x, int y, int count)
        {
            if (x < 0 || y < 0 || x >= maze.GetLength(0) || y >= maze.GetLength(1) || used[x, y])
            {
                if (count > max)
                {
                    max = count;                   
                }
            }
            else
            {
                used[x, y] = true;
                count += maze[x, y];
                Dfs(x - maze[x, y], y, count);
                Dfs(x, y + maze[x, y], count);
                Dfs(x + maze[x, y], y, count);                
                Dfs(x, y - maze[x, y], count);

                used[x, y] = false;
            }
        }
    }
}