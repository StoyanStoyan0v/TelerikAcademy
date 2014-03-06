using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Queen : InfestingUnit
    {
        public const int BaseHealth = 30;
        public const int BasePower = 1;
        public const int BaseAggression = 1;

        public Queen(string id) : base(id,UnitClassification.Psionic,Queen.BaseHealth,Queen.BasePower,Queen.BaseAggression)
        {
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> attackableUnits = units.Where((unit) => unit.Id != this.Id &&
             (InfestationRequirements.RequiredClassificationToInfest(unit.UnitClassification) == UnitClassification.Psionic));

            UnitInfo optimalAttackableUnit = GetOptimalAttackableUnit(attackableUnits);

            if (optimalAttackableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalAttackableUnit, InteractionType.Infest);
            }

            return Interaction.PassiveInteraction;
        }
    }
}