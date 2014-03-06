using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Tank : Unit
    {
        private const int BasePower = 25;
        private const int BaseHealth = 20;
        private const int BaseAgression = 25;
        
        public Tank(string id) :base(id,UnitClassification.Mechanical,Tank.BaseHealth,Tank.BasePower,Tank.BaseAgression)
        {

        }
    }
}
