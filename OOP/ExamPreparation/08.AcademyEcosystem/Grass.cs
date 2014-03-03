namespace AcademyEcosystem
{
    public class Grass : Plant
    {
        private const int InitialGrassSize = 2;

        public Grass(Point location) : base(location, InitialGrassSize)
        {
        }

        public override void Update(int time)
        {
            if (this.IsAlive)
            {
                this.Size += time;
            }
        }
    }
}