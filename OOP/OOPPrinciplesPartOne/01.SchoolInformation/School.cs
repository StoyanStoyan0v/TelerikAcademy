namespace SchoolInformation
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        private readonly List<Class> classes;

        public School()
        {
            this.classes= new List<Class> ();
        }

        public void AddClass(Class someClass)
        {
            if(classes.Contains(someClass))
            {
                throw new ArgumentException("The school already has such class!");
            }
            this.classes.Add(someClass);
        }

        public void RemoveClass(Class someClass)
        {
            if (!classes.Contains(someClass))
            {
                throw new ArgumentException("The school does not have such class!");
            }
            this.classes.Add(someClass);
        }

        public override string ToString()
        {
            return string.Join(" ",this.classes);
        }
    }
}
