using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Weapon : Supplement
    {
        private const int Power = 10;
        private const int Agression = 3;

        public Weapon()
        {
            
        }
        public override void ReactTo(ISupplement otherSupplement)
        {
            if(otherSupplement is WeaponrySkill)
            {
                this.PowerEffect = Power;
                this.AggressionEffect = Agression;
            }
        }

    }
}
