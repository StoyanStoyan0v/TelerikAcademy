namespace AcademyEcosystem
{
    public class Lion : Animal, ICarnivore
    {
        private const int InitialSize = 6;

        public Lion(string name, Point location) : base(name,location,InitialSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null && animal.Size <= this.Size)
            {
                this.Size++;
                return animal.GetMeatFromKillQuantity();
            }
            return 0;
        }
    }
}