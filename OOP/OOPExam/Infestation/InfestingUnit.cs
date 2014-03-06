using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public abstract class InfestingUnit : Unit
    {
        public InfestingUnit(string id, UnitClassification unitType, int health, int power, int aggression) : base(id, unitType, health, power,aggression)
        {
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, 0, int.MaxValue, 0);

            foreach (var unit in attackableUnits.OrderBy(x => x.Health))
            {
                if (unit.Power < optimalAttackableUnit.Power)
                {
                    optimalAttackableUnit = unit;
                    break;
                }
            }

            return optimalAttackableUnit;
        }
    }
}