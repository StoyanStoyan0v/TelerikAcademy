using System;

namespace FlyweightPattern
{
    public class LittleAlien : IAlien
    {
        private const string SHAPE = "Little Shape";//intrinsic state

        string IAlien.Shape
        {
            get
            {
                return SHAPE;
            }
        }

        Color IAlien.GetColor(int madLevel)   //extrinsic state
        {
            if (madLevel == 0)
            {
                return Color.Red;
            }
            else if (madLevel == 1)
            {
                return Color.Blue;
            }
            else
            {
                return Color.Green;
            }
        }
    }
}