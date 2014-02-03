using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DPoints
{
    class Tests
    {
        static void Main(string[] args)
        {
            
            Point3D p2 = new Point3D(12,5,0);
            Console.WriteLine("p1 " + Point3D.Point0);
            Console.WriteLine("p2 "+ p2);

            double distance = Distance.CalculateDistance(Point3D.Point0, p2);
            Console.WriteLine("Distance between p1 and p2: "+distance);

            Path path1 = new Path();
            path1.AddPoint(Point3D.Point0);
            path1.AddPoint(p2);
            path1.AddPoint(new Point3D(3, 1.4f, -6));
            Path path2 = new Path(new Point3D(5, 2.35f, -12), new Point3D(-3.56f, 0.92f, 4));
            path2.AddPoint(new Point3D(3, 1.4f, -6));
            PathStorage.SavePath(path1);
            PathStorage.SavePath(path2);
            List<string> paths = PathStorage.LoadPaths();
            for (int i = 0; i < paths.Count; i++)
            {
                Console.WriteLine("Path {0}: {1}",i+1,paths[i]); 
            }            
        }
    }
}
