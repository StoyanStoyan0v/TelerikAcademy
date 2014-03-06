using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Supplement: ISupplement
    {
        public virtual void ReactTo(ISupplement otherSupplement)
        {
            
        }

        public int PowerEffect { get; protected set; }


        public int HealthEffect{ get; protected set; }
 

        public int AggressionEffect{ get; protected set; }

    }
}
