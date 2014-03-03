﻿namespace AcademyEcosystem
{
    public class Wolf : Animal, ICarnivore
    {
        private const int InitialSize = 4;

        public Wolf(string name, Point location)
            : base(name, location, InitialSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (animal.Size <= this.Size || animal.State == AnimalState.Sleeping)
                {
                    return animal.GetMeatFromKillQuantity();
                }
            }

            return 0;
        }
    }
}