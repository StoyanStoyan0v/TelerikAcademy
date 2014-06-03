namespace CohesionAndCoupling
{
    
    using System;

    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileInfo.GetFileExtension("example"));
            Console.WriteLine(FileInfo.GetFileExtension("example.pdf"));
            Console.WriteLine(FileInfo.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileInfo.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileInfo.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileInfo.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                Geometry.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                Geometry.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Geometry.Width = 3;
            Geometry.Height = 4;
            Geometry.Depth = 5;
            Console.WriteLine("Volume = {0:f2}", Geometry.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", Geometry.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", Geometry.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", Geometry.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", Geometry.CalcDiagonalYZ());
        }
    }
}