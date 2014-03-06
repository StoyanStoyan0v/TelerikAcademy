using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class PowerInhibitor : Supplement
    {
        private const int Effect = 3;

        public PowerInhibitor() : base()
        {
            this.PowerEffect = Effect;
        }
    }

    public class HealthInhibitor : Supplement
    {
        private const int Effect = 3;

        public HealthInhibitor() : base()
        {
            this.HealthEffect = Effect;
        }
    }

    public class AggressionInhibitor : Supplement
    {
        private const int Effect = 3;

        public AggressionInhibitor() : base()
        {
            this.AggressionEffect = Effect;
        }
    }
}