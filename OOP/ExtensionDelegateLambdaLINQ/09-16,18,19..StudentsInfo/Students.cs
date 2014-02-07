namespace StudentsInfo
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Students
    {

        public Students()
        {

        }

        public Students(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string FN { get; set; }

        public string Tel { get; set; }

        public string Email { get; set; }

        public List<int> Marks { get; set; }

        public sbyte GroupNumber { get; set; }

        public Group Group { get; set; }

        public override string ToString()
        {
            return string.Format("Full name: {0,-17}",
                this.FirstName + " " + this.LastName);
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
