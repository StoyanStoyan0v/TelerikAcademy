namespace _3DPoints
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public static class PathStorage
    {

        static PathStorage()
        {
            //Create the file which is going to be mainupalted. Prevent exceptions.
            StreamWriter createFile = new StreamWriter("paths.txt");
            using (createFile) { }
        }
        public static void SavePath(Path path)
        {
            StreamWriter writer = new StreamWriter("paths.txt",true);

            using (writer)
            {
               writer.WriteLine(string.Join(",",path));
            }
        }

        public static List<string> LoadPaths()
        {
            StreamReader reader = new StreamReader("paths.txt");
            List<string> allPaths = new List<string>();

            try
            {
                using (reader)
                {
                    for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                    {
                        allPaths.Add(line);
                    }
                }
            }
            catch(Exception)
            {
                Console.WriteLine("The current file cannot be manipulated! ");
            }

            return allPaths;
        }

    }
}
