using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class InfestationSpores : Supplement
    {
        private const int Agression = 20;
        private const int Power = -1;

        public InfestationSpores():base()
        {
            this.AggressionEffect = Agression;
            this.PowerEffect = Power;
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if(otherSupplement is InfestationSpores)
            {
                this.AggressionEffect = 0;
                this.PowerEffect = 0;
                
            }
        }
    }
}
