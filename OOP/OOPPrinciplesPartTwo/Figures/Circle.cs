namespace Figures
{
    using System;

    public class Circle : Shape
    {
        public Circle(float width)
            : base()
        {
            this.Width = width;
            this.Heigth = width;
        }

        public override float Heigth { get; protected set; }

        public override float Width { get;  protected set; }

        public override float CalculateSurface()
        {
            return (float)Math.PI * Width * Heigth;
        }
    }
}
