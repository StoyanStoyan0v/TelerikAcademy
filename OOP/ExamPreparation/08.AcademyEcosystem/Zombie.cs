namespace AcademyEcosystem
{
    public class Zombie : Animal
    {
        private const int MeatAmount = 10;
        private const int InitialSize = 0;

        public Zombie(string name, Point location) : base(name, location, InitialSize)
        {
        }

        public override int GetMeatFromKillQuantity()
        {
            return MeatAmount;
        }
    }
}