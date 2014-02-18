namespace Figures
{
    public class Rectangle : Shape
    {
        public Rectangle(float width,float heigth) : base()
        {
            this.Width = width;
            this.Heigth = heigth;
        }

        public override float Heigth { get;  protected set; }

        public override float Width { get;  protected set; }

        public override float CalculateSurface()
        {
            return this.Width * this.Heigth;
        }
    }
}
