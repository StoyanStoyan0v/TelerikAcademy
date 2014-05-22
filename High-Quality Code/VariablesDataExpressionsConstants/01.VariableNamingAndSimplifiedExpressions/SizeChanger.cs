namespace VariableNamingAndSimplifiedExpressions
{
    using System;

    public class Size
    {
        private double width, heigth;

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Width cannot be a negative number.");
                }
                this.width = value;
            }
        }

        public double Heigth
        {
            get
            {
                return this.heigth;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Heigth cannot be a negative number.");
                }
                this.heigth = value;
            }
        }

        public Size(double width, double heigth)
        {
            this.width = width;
            this.heigth = heigth;
        }
    }

    public static class SizeChanger
    {
        public static Size GetRotatedSize(Size size, double rotationAngle)
        {
            double width = Math.Abs(Math.Cos(rotationAngle)) * size.Width +
                           Math.Abs(Math.Sin(rotationAngle)) * size.Heigth;
            double heigth = Math.Abs(Math.Sin(rotationAngle)) * size.Width +
                            Math.Abs(Math.Cos(rotationAngle)) * size.Heigth;
            return new Size(width, heigth);
        }
    }
}