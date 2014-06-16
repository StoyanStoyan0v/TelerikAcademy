namespace School
{
    using System;
    
    public class Student 
    {
        private string name;

        private int id;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Student name cannot be null or empty!","name");
                }
                this.name = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (10000 > value || value > 99999)
                {
                    throw new ArgumentNullException("It should be between 10000 and 99999","id");
                }
                this.id = value;
            }
        }
       
        public Student(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }
       
        public override bool Equals(Object obj)
        {
            Student other = obj as Student;

            if (other == null)
            {
                return false;
            }

            return this.id == other.id;
        }

        
        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }



        public override string ToString()
        {
            return this.Name + " " + this.Id;
        }
    }
}