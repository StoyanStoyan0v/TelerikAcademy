using System;

namespace FlyweightPattern
{
    public interface IAlien
    {
        string Shape { get; }//intrinsic state

        Color GetColor(int madLevel);//extrinsic state
    }
}