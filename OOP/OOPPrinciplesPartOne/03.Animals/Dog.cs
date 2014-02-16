namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, float age, string sex) : base(name,age)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public override string ProduceSound()
        {
            return "wof";
        }
    }
}
