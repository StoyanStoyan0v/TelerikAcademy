using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Parasite : InfestingUnit
    {
        public const int BaseHealth = 1;
        public const int BaseAggression = 1;
        public const int BasePower = 1;

        public Parasite(string id) : base(id,UnitClassification.Biological, Parasite.BaseHealth, Parasite.BasePower, Parasite.BaseAggression)
        {
        }

      
        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> attackableUnits = units.Where((unit) => unit.Id != this.Id && 
                (InfestationRequirements.RequiredClassificationToInfest(unit.UnitClassification) == UnitClassification.Biological));

            UnitInfo optimalAttackableUnit = GetOptimalAttackableUnit(attackableUnits);

            if (optimalAttackableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalAttackableUnit, InteractionType.Infest);
            }

            return Interaction.PassiveInteraction;
        }

    }
}