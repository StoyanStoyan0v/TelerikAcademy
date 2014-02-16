namespace Animals
{
    using System;

    public abstract class Animal : ISound
    {
        private string name;
        private string sex;

        public Animal(string name, float age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Animal name cannot be empty!");
                }
                this.name = value;
            }
        }

        public float Age { get; set; }

        public virtual string Sex
        {
            get
            {
                return this.sex;
            }
            protected set
            {
                if(value.ToLower()!="female" && value.ToLower()!="male")
                {
                    throw new ArgumentException("The sex of the animal cannot be something different than male or female!");
                }
                this.sex = value;
            }
        }

        public abstract string ProduceSound();
    }
}
