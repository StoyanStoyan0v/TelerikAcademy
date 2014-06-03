namespace FilesAndFolders
{
    using System;
    using System.IO;
    
    public class File
    {
        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("File name cannot be null or empty!");
                }
                this.name = value;
            }
        }

        public long Size
        {
            get
            {
                return new FileInfo(this.Name).Length;
            }
        }

        public File(string name)
        {
            this.Name = name;
        }
    }
}