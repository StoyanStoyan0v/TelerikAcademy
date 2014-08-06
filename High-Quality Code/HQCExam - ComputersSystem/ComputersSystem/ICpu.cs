namespace ComputersSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public interface ICpu
    {
        void SaveRandomNumberToRam(int minNumber, int maxNumber);

        void RenderSquareNumber(IVideoCard videoCard);
    }
}