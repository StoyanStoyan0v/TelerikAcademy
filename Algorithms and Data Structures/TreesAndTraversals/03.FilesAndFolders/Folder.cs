namespace FilesAndFolders
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    
    public class Folder
    { 
        public string Name { get; set; }

        ///<summary>
        /// Returns the size of the folder in bytes.
        ///</summary>
        public long Size { get; private set; }

        public HashSet<File> Files { get; private set; }

        public HashSet<Folder> Folders { get; private set; }

        public Folder(string name)
        {
            this.Files = new HashSet<File>();
            this.Folders = new HashSet<Folder>();
            this.Name = name;
            this.InitializeFolder(this);
        }

        private void InitializeFolder(Folder directory)
        {
            var files = Directory.GetFiles(directory.Name);
            
            foreach (var file in files)
            {
                File newFile = new File(file);
                this.Size += newFile.Size;
                directory.Files.Add(newFile);
            }

            var directories = Directory.GetDirectories(directory.Name);

            foreach (var dir in directories)
            {
                try
                {
                    Folder folder = new Folder(dir);
                    InitializeFolder(folder);
                    directory.Folders.Add(folder);
                }
                catch (Exception)
                {
                    Console.WriteLine("Cannot access {0}.", dir);
                }
            }
        }

        public Folder GetSubFolder(string name)
        {
            var folders = new Queue<Folder>();

            folders.Enqueue(this);

            while (folders.Count > 0)
            {
                var folder = folders.Dequeue();

                if (folder.Name == name)
                {
                    return folder;
                }

                foreach (var f in folder.Folders)
                {
                    folders.Enqueue(f);
                }
            }

            throw new ArgumentException("Subfolder with such name is not found!");
        }
    }
}