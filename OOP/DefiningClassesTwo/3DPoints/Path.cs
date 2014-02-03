using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DPoints
{
    public class Path 
    {
        private List<Point3D> path;

        public Path()
        {
            path = new List<Point3D>();
        }

        public Path(Point3D p1, Point3D p2) : this()
        {
            path = new List<Point3D>() {p1, p2};
        }


        public void AddPoint(Point3D p)
        {
            path.Add(p);
        }

        public override string ToString()
        {
            StringBuilder pt = new StringBuilder();
            for (int i = 0; i < path.Count; i++)
            {
                pt.Append(string.Format("({0}, {1}, {2}) ",path[i].X,path[i].Y,path[i].Z));
            }

            return pt.ToString();
        }
    }
}
