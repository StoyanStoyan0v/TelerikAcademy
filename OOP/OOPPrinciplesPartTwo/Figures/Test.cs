namespace Figures
{
    using System;

    class Test
    {
        static void Main(string[] args)
        {
            Shape[] shapes = new Shape[]
            {
                new Circle(5), new Rectangle(3,8), new Triangle(5,5), new Circle(12.5f),
                new Triangle(10,5), new Triangle(9,3), new Circle(12.34f), new Rectangle(8,19), new Rectangle(3.5f,14.75f)
            };

            foreach (Shape shape in shapes)
            {
                Console.WriteLine("Shape: {0,-9} | Area: {1}", shape.GetType().Name, shape.CalculateSurface());
            }
        }
    }
}