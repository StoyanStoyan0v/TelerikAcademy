using System;
using System.Collections;
namespace Students
{
    public class Student
    {
        private int age;
        private string firstName;
        private string lastName;

        public Student(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid name");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid name");
                }
                this.lastName = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Student's age cannot be a negative number!");
                }
                this.age = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName);
        }

        public static void PrintCollection(IEnumerable students)
        {
            foreach (var item in students)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
