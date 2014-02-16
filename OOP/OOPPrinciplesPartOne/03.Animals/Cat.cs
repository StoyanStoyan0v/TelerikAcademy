namespace Animals
{
    public abstract class Cat : Animal
    {
        public Cat(string name, float age) : base(name,age)
        {

        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
