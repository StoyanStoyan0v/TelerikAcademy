namespace AcademyRPG
{
    using System.Collections.Generic;
    using System.Linq;
    
    public class Ninja : Character, IFighter, IGatherer
    {
        public Ninja(string name, Point position, int owner) : base(name, position, owner)
        {
            this.HitPoints = 1;
            this.AttackPoints = 0;
        }

        public int AttackPoints { get; private set; }

        public int DefensePoints
        {
            get
            {
                return int.MaxValue;
            }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.OrderByDescending(target => target.HitPoints).ToList().Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                this.AttackPoints += resource.Quantity * 2;
                return true;
            }

            if (resource.Type == ResourceType.Lumber)
            {
                this.AttackPoints += resource.Quantity;
                return true;
            }

            return false;
        }
    }
}