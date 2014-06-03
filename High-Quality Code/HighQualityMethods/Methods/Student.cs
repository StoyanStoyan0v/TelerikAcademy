using System;

namespace Methods
{
    class Student
    {
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name cannot be null or empty!");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last name cannot be null or empty!");
                }
                this.lastName = value;
            }
        }
        
        public string OtherInfo { get; set; }

        public Student()
        {
        }

        public Student(string firstName, string lastName) : this()
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        
        public bool IsOlderThan(Student other)
        {
            try
            {
                var thisBirthDate = this.OtherInfo.Substring(this.OtherInfo.Length - 10);
                var otherBirthDate = other.OtherInfo.Substring(other.OtherInfo.Length - 10);

                DateTime firstDate =
                    DateTime.Parse(thisBirthDate);
                DateTime secondDate =
                    DateTime.Parse(otherBirthDate);
                return firstDate > secondDate;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid string for DateTime parsing!");
            }
        }
    }
}