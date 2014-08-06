﻿namespace ComputersSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public interface IHardDriver
    {
        void SaveData(int address, string data);

        string LoadData(int address);
    }
}