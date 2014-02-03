namespace _3DPoints
{
    public struct Point3D
    {
        private static readonly Point3D point0 = new Point3D() { X = 0.0f, Y = 0.0f, Z = 0.0f };

        public Point3D(float x, float y, float z) : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public float X { get;  set; }

        public float Y { get;  set; }

        public float Z { get;  set; }

        public static Point3D Point0
        {
            get { return point0; }
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})",X,Y,Z);
        }
       
    }
}
