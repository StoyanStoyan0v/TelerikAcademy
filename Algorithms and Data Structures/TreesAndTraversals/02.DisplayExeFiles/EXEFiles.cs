using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace DisplayExeFiles
{
    public class ExeFiles
    {
        private const string DIRECTORY = "D:";
        private const string EXTENSION = "*.exe";
        private static readonly List<string> files = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Enter 'dfs' or 'bfs' to start: ");

            string input = Console.ReadLine();
            if (input == "bfs")
            {
                GetFilesBfs(); //BFS with queue
                Console.WriteLine(string.Join("\n", files));
                Console.WriteLine(files.Count + " file(s) found!");
            }
            else if (input == "dfs")
            {
                files.Clear();
                GetFilesDfs(DIRECTORY); //DFS recursively
                Console.WriteLine(string.Join("\n", files));
                Console.WriteLine(files.Count + " file(s) found!");
            }
            else
            {
                Console.WriteLine("Invalid command! Bye!");
            }
        }

        private static void GetFilesBfs()
        {
            Queue<string> directories = new Queue<string>();
            directories.Enqueue(DIRECTORY);

            while (directories.Count > 0)
            {
                var currentDir = directories.Dequeue();
                try
                {
                    foreach (var dir in Directory.GetDirectories(currentDir))
                    {
                        directories.Enqueue(dir);
                    }
                
                    files.AddRange(Directory.GetFiles(currentDir, EXTENSION));
                }
                catch (Exception)
                {
                    Console.WriteLine("Access to " + currentDir + "is denied!");
                }
            }
        }
      
        private static void GetFilesDfs(string directory)
        {
            var fileExtensions = Directory.GetFiles(directory, EXTENSION);
            files.AddRange(fileExtensions);

            var directories = Directory.GetDirectories(directory);

            foreach (var folder in directories)
            {
                try
                {
                    GetFilesDfs(folder);
                }
                catch (Exception)
                {
                    Console.WriteLine("Access to " + folder + "is denied!");
                }
            }
        }
    }
}