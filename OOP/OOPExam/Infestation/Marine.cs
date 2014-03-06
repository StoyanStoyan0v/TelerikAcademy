using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Marine :Human
    {
        public Marine(string id):base(id)
        {
            this.AddSupplement(new WeaponrySkill());
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
             UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, 0, int.MaxValue, 0);

            foreach (var unit in attackableUnits.OrderByDescending(x=>x.Health))
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
