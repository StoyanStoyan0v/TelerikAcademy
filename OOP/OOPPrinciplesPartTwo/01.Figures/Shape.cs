namespace Figures
{
    public abstract class Shape
    {
        public abstract float Width { get; protected set; }

        public abstract float Heigth { get; protected set; }

        public abstract float CalculateSurface();

    }
}
