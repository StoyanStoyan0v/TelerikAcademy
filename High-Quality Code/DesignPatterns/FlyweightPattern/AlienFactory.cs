using System;
using System.Collections.Generic;

namespace FlyweightPattern
{
    public class AlienFactory
    {
        private readonly Dictionary<int, IAlien> list = new Dictionary<int, IAlien>();

        public void SaveAlien(int index, IAlien alien)
        {
            this.list.Add(index, alien);
        }
        
        public IAlien GetAlien(int index)
        {
            return this.list[index];
        }
    }
}