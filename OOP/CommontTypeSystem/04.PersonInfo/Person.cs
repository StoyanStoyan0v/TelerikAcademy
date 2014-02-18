namespace PersonInfo
{
    using System;
    using System.Linq;
    
    public class Person
    {
        public string Name { get; private set; }

        public int? Age { get; set; }

        public Person(string name, int? age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}\nAge: {1}\n", this.Name, this.Age == null ? "Unspecified age!" : this.Age.ToString());
        }
    }
}