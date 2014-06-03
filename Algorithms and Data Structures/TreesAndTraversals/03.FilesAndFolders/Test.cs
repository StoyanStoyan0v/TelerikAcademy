namespace FilesAndFolders
{
    using System;
    using System.Linq;

    static class Test
    {
        private const string DIRECTORY = "C:\\WINDOWS\\System32";
        static void Main(string[] args)
        {
            Console.WriteLine("Please wait...");
            Folder windows = new Folder(DIRECTORY);
            //var system32Folder = windows.GetSubFolder("C:\\WINDOWS\\System32");
            Console.WriteLine("All files in {0}:\n{1}", windows.Name, string.Join("\n", windows.Files.Select(name => name.Name)));
            Console.WriteLine(GetSizeInGigabytes(windows.Size));
            Console.WriteLine("Program finnished!");            
        }

        private static string GetSizeInGigabytes(long sizeInBytes)
        {
            return string.Format("Total size: {0:0.00}", (double)sizeInBytes / 1024.00 / 1024.00 / 1024.00) + " GB";
        }
    }
}