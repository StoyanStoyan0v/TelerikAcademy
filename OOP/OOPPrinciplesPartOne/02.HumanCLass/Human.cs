namespace HumanCLass
{
    public abstract class Human
    {
        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public abstract string FirstName { get; protected set; }

        public abstract string LastName { get; protected set; }
    }
}
