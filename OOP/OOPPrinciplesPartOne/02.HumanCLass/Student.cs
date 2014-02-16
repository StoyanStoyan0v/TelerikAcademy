namespace HumanCLass
{
    using System;

    public class Student : Human
    {
        private string firstName;
        private string lastName;
        private sbyte grade;

        public Student(string firstName, string lastName, sbyte grade) : base(firstName,lastName)
        {
            this.Grade = grade;
        }

        public override string FirstName
        {
            get
            {
                return this.firstName;
            }
            protected set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Student's first name cannot be empty!");
                }
                this.firstName = value;
            }
        }

        public override string LastName
        {
            get
            {
                return this.lastName;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Student's last name cannot be empty!");
                }
                this.lastName = value;
            }
        }
        public sbyte Grade
        {
            get
            {
                return this.grade;
            }
            set
            {
                if(value<1 || value>12)
                {
                    throw new ArgumentException("The student's grade cannot be a value lesser than 1 and greater than 12!");
                }
                this.grade = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0,-20} | Grade: {1}", this.FirstName + " " + this.LastName, this.Grade);
        }
    }
}
