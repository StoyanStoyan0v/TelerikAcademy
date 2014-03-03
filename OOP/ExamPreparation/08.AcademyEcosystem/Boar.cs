namespace AcademyEcosystem
{
    public class Boar : Animal, ICarnivore, IHerbivore
    {
        private const int InitialSize = 4;
        private const int BoarBiteSize = 2;

        public Boar(string name, Point location) : base(name,location,InitialSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (animal.Size <= this.Size)
                {
                    return animal.GetMeatFromKillQuantity();
                }
            }
            return 0;
        }

        public int EatPlant(Plant p)
        {
            if (p != null)
            {
                this.Size++;
                return p.GetEatenQuantity(BoarBiteSize);
            }

            return 0;
        }
    }
}