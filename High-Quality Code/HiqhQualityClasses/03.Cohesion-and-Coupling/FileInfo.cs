namespace CohesionAndCoupling
{
    using System;
    
    public class FileInfo
    {
        public static string GetFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                throw new ArgumentException("The file has not(an empty) extension!");
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                throw new ArgumentException("The file has not(an empty) name!");
            }

            string extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }
    }
}