using System;

namespace FlyweightPattern
{
    public class LargeAlien : IAlien
    {
        private const string SHAPE = "Large Shape";//intrinsic state

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
                return Color.Green;
            }
            else if (madLevel == 1)
            {
                return Color.Red;
            }
            else
            {
                return Color.Blue;
            }
        }
    }
}