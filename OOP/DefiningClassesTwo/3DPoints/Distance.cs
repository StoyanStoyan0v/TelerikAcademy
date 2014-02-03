using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DPoints
{
    public static class Distance
    {
        public static double CalculateDistance(Point3D p1, Point3D p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y  - p2.Y) * (p1.Y - p2.Y) + (p1.Z - p2.Z) * (p1.Z - p2.Z));
        }
    }
}
