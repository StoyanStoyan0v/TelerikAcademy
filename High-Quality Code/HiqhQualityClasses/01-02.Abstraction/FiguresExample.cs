using System;

namespace Abstraction
{
    class FiguresExample
    {
        static void Main()
        {
            Figure[] figures = { new Circle(5), new Rectangle(2, 3) };

            foreach (var figure in figures)
            {
                Console.WriteLine("I am a {0}. My perimeter is {1:f2}. My surface is {2:f2}.",
                   figure.GetType().Name.ToLower(), figure.CalcPerimeter(), figure.CalcSurface());
            }
        }
    }
}