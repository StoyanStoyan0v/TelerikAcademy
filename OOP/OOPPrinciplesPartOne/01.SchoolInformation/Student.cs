namespace SchoolInformation
{
    using System;

    public class Student : People, ICommentable
    {
        private int? id;

        public Student(string name, int id) : base(name)
        {
            this.id = id;
        }

        public int? Id
        {
            get
            {
                return this.id;
            }
            private set
            {
                if(value == null || value <0)
                {
                    throw new ArgumentException("The ID number cannot be negative ot empty!");
                }
                this.id = value;
            }
        }

       

        public override string ToString()
        {
            return string.Format("Name: {0} | ID: {1} | {2}", this.Name, this.Id, 
                this.Comment != null ? "Comment: " + this.Comment : null);
        }
    }
}
