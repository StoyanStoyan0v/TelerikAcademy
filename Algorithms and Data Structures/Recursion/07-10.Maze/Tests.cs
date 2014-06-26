namespace Maze
{
    using System;
    
    public static class Tests
    {
        private static void Main(string[] args)
        {
            Maze maze = new Maze(6, 6, new Position(), new Position() { Row = 5, Col = 5 });
            
            Console.WriteLine("p - path cell");
            Console.WriteLine("e - empty cell");
            Console.WriteLine("Initial maze: ");
            maze.FillTheMazeRandomly(3);
            Console.WriteLine(maze);

            //07. Generate all paths.
            Console.WriteLine("All paths from S to E: ");
            var allPathsMaze = maze.FindAllPaths();
            Console.WriteLine(allPathsMaze);

            //08. Generate shortest path.
            Console.WriteLine("Shortest path from S to E: ");
            var shortestPathMaze = maze.FindShortestPath();
            Console.WriteLine(shortestPathMaze);

            //09.Find largest empty area.
            Console.WriteLine("Largest empty area: ");
            var largestEmptyAreaMaze = maze.FindLargestEmptyArea();
            Console.WriteLine(largestEmptyAreaMaze);

            //10.Find all empty areas.
            Console.WriteLine("All empty areas: ");
            var allEmptyAreasMaze = maze.FindAllEmptyAreas();
            Console.WriteLine(allEmptyAreasMaze);
        }
    }
}