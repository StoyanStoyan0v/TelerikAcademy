namespace AcademyRPG
{
    using System.Collections.Generic;
    
    public class Giant : Character, IFighter, IGatherer
    {
        public Giant(string name, Point position) : base(name,position, 0)
        {
            this.HitPoints = 200;
            this.AttackPoints = 150;
        }

        public int AttackPoints { get; private set; }

        public int DefensePoints
        {
            get
            {
                return 80;
            }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
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
                this.AttackPoints += 100;
                return true;
            }
            return false;
        }
    }
}