namespace Animals
{
    public class Frog : Animal
    {
        public Frog(string name, float age, string sex) : base(name,age)
        {
            this.Sex = sex;
        }

        public override string ProduceSound()
        {
            return "ribbit";
        }
    }
}
