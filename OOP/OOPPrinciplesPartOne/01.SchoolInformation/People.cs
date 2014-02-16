namespace SchoolInformation
{
    using System;

    public class People : ICommentable
    {
        private string name;
        private string comment;

        public People(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if(String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name cannot be null or empty!");
                }
                this.name=value;
            }
        }

        public string Comment
        {
            get
            {
                return this.comment;
            }
            set
            {
                if (value.Length < 10 || value.Length > 30)
                {
                    throw new ArgumentException("The comment must be between 10 and 30 characters long!");
                }

                this.comment = value;
            }
        }
    }
}
