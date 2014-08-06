﻿namespace ComputersSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public interface IVideoCard
    {
        bool IsMonochrome { get; }

        void Draw(string output);
    }
}